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
import { PersonDto } from "@shared/service-proxies/dto/people/person-dto";
import { PersonServiceProxy } from "@shared/service-proxies/service-proxies";

@Component({
  selector: "app-edit-person-dialog",
  templateUrl: "./edit-person-dialog.component.html",
  styleUrls: ["./edit-person-dialog.component.css"],
})
export class EditPersonDialogComponent
  extends AppComponentBase
  implements OnInit
{
  saving = false;
  person: PersonDto = new PersonDto();
  id: string;
  documentTypes = [{ id: 1, name: "CPF" }, { id: 2, name: "RG" }, { id: 3, name: "CNH" }];

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public bsModalRef: BsModalRef,
    public _personService: PersonServiceProxy
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._personService.get(this.id).subscribe((result: PersonDto) => {
      this.person = result;
    });
  }
  save(): void {
    this.saving = true;

    this._personService
      .update(this.person)
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
}
