import { PersonDto } from './../../../shared/service-proxies/dto/people/person-dto';
import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter,
} from "@angular/core";
import { finalize } from "rxjs/operators";
import { BsModalRef } from "ngx-bootstrap/modal";
import { AppComponentBase } from "@shared/app-component-base";
import { CreateContactDto } from "@shared/service-proxies/dto/contact-list/create-contact-dto";
import { ContactServiceProxy, PersonServiceProxy } from "@shared/service-proxies/service-proxies";
import { PersonDtoPagedResultDto } from "@shared/service-proxies/dto/people/person-dto-paged-result-dto";

@Component({
  selector: 'app-create-contact-dialog',
  templateUrl: './create-contact-dialog.component.html',
  styleUrls: ['./create-contact-dialog.component.css']
})
export class CreateContactDialogComponent extends AppComponentBase implements OnInit {
  saving = false;
  contact: CreateContactDto = new CreateContactDto();
  contacts: PersonDto[] = [];
  personSelected: number;
  telephoneMask = ['+', '5', '5', ' ', '(', /\d/, /\d/, ')', ' ', /\d/, /\d/, /\d/, /\d/, '-', /\d/, /\d/, /\d/, /\d/];

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public bsModalRef: BsModalRef,
    public _contactService: ContactServiceProxy,
    public _personService: PersonServiceProxy
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.contact.isActive = true;
    this._personService
    .getAll("", true, 0, 10)
    .subscribe((result: PersonDtoPagedResultDto) => {
      this.contacts = result.items;

    });
  }

  save(): void {
    this.saving = true;

    this._contactService
      .create(this.contact)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l("SavedSuccessfully"));
        this.bsModalRef.hide();
        this.onSave.emit();
      });
  }

  changePerson(){
    const selected: PersonDto = this.contacts.find(prop => prop.id === Number(this.personSelected));
    this.contact.name = selected.name;
    this.contact.personId = selected.id;
  }
}
