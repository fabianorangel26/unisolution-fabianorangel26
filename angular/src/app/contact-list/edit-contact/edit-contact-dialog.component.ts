import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { ContactDto } from '@shared/service-proxies/dto/contact-list/contact-dto';
import { ContactServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from "ngx-bootstrap/modal";
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-edit-contact-dialog',
  templateUrl: './edit-contact-dialog.component.html',
  styleUrls: ['./edit-contact-dialog.component.css']
})
export class EditContactDialogComponent extends AppComponentBase implements OnInit {
  saving = false;
  contact: ContactDto = new ContactDto();
  id: string;
  telephoneMask = ['+', '5', '5', ' ', '(', /\d/, /\d/, ')', ' ', /\d/, /\d/, /\d/, /\d/, '-', /\d/, /\d/, /\d/, /\d/];

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public bsModalRef: BsModalRef,
    public _contactService: ContactServiceProxy
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._contactService.get(this.id).subscribe((result: ContactDto) => {
      this.contact = result;
    });
  }
  save(): void {
    this.saving = true;

    this._contactService
      .update(this.contact)
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
