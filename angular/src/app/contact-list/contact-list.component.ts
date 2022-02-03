import { Component, Injector } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '@shared/paged-listing-component-base';
import { ContactDto } from '@shared/service-proxies/dto/contact-list/contact-dto';
import { ContactServiceProxy } from '@shared/service-proxies/service-proxies';
import { ContactDtoPagedResultDto } from '@shared/service-proxies/dto/contact-list/contact-dto-paged-result-dto';
import { CreateContactDialogComponent } from './create-contact/create-contact-dialog.component';
import { EditContactDialogComponent } from './edit-contact/edit-contact-dialog.component';
import { finalize } from 'rxjs/operators';

class PagedContactRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}
@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  animations: [appModuleAnimation()],
  styleUrls: ['./contact-list.component.css']
})
export class ContactListComponent extends PagedListingComponentBase<ContactDto> {
  contacts: ContactDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;

  constructor(
    injector: Injector,
    private _modalService: BsModalService,
    private _contactService: ContactServiceProxy
  ) {
    super(injector);
  }

  list(
    request: PagedContactRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._contactService
      .getAll(
        request.keyword,
        request.isActive,
        request.skipCount,
        request.maxResultCount
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: ContactDtoPagedResultDto) => {
        this.contacts = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }

  createContact(): void {
    this.showCreateOrEditContactDialog();
  }

  editContact(contact: ContactDto): void {
    this.showCreateOrEditContactDialog(contact.id);
  }

  showCreateOrEditContactDialog(id?: string): void {
    let createOrEditContactDialog: BsModalRef;
    if (!id || id === '') {
      createOrEditContactDialog = this._modalService.show(
        CreateContactDialogComponent,
        {
          class: 'modal-lg'
        }
      );
    } else {
      createOrEditContactDialog = this._modalService.show(
        EditContactDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id
          }
        }
      );
    }

    createOrEditContactDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  delete(contact: ContactDto): void {
    abp.message.confirm(
      this.l('ContactDeleteWarningMessage', contact.id),
      undefined,
      (result: boolean) => {
        if (result) {
          this._contactService
            .delete(contact.id)
            .pipe(
              finalize(() => {
                abp.notify.success(this.l('SuccessfullyDeleted'));
                this.refresh();
              })
            )
            .subscribe(() => {});
        }
      }
    );
  }
}
