import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter,
  NgModule,
} from "@angular/core";
import { finalize } from "rxjs/operators";
import { BsModalRef } from "ngx-bootstrap/modal";
import { AppComponentBase } from "@shared/app-component-base";
import { CreatePersonDto } from "@shared/service-proxies/dto/people/create-person-dto";
import { PersonServiceProxy } from "@shared/service-proxies/service-proxies";
import { NgxMaskModule } from "ngx-mask";

@Component({
  selector: "app-create-person-dialog",
  templateUrl: "./create-person-dialog.component.html",
  styleUrls: ["./create-person-dialog.component.css"],
})
export class CreatePersonDialogComponent
  extends AppComponentBase
  implements OnInit
{
  @NgModule({
    imports: [NgxMaskModule.forRoot()],
  })
  saving = false;
  person: CreatePersonDto = new CreatePersonDto();
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
    this.person.isActive = true;
  }

  save(): void {
    this.saving = true;

    this._personService
      .create(this.person)
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
