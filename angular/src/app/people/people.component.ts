import { Component, Injector } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '@shared/paged-listing-component-base';
import { PersonDto } from '@shared/service-proxies/dto/people/person-dto';
import { PersonServiceProxy } from '@shared/service-proxies/service-proxies';
import { PersonDtoPagedResultDto } from '@shared/service-proxies/dto/people/person-dto-paged-result-dto';
import { CreatePersonDialogComponent } from './create-person/create-person-dialog.component';
import { EditPersonDialogComponent } from './edit-person/edit-person-dialog.component';
import { finalize } from 'rxjs/operators';

class PagedPeopleRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  selector: 'app-people',
  templateUrl: './people.component.html',
  animations: [appModuleAnimation()],
  styleUrls: ['./people.component.css']
})
export class PeopleComponent extends PagedListingComponentBase<PersonDto> {
  people: PersonDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;
  documentTypes = [{ id: 1, name: "CPF" }, { id: 2, name: "RG" }, { id: 3, name: "CNH" }];

  constructor(
    injector: Injector,
    private _modalService: BsModalService,
    private _personService: PersonServiceProxy
  ) {
    super(injector);
  }

  private getDocumentType(id: number){
    return this.documentTypes.find(prop => prop.id === id)?.name;
  }

  list(
    request: PagedPeopleRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._personService
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
      .subscribe((result: PersonDtoPagedResultDto) => {
        this.people = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }

  createPerson(): void {
    this.showCreateOrEditPersonDialog();
  }

  editPerson(person: PersonDto): void {
    this.showCreateOrEditPersonDialog(person.id);
  }

  showCreateOrEditPersonDialog(id?: string): void {
    let createOrEditPersonDialog: BsModalRef;
    if (!id || id === '') {
      createOrEditPersonDialog = this._modalService.show(
        CreatePersonDialogComponent,
        {
          class: 'modal-lg'
        }
      );
    } else {
      createOrEditPersonDialog = this._modalService.show(
        EditPersonDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id
          }
        }
      );
    }

    createOrEditPersonDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  delete(person: PersonDto): void {
    abp.message.confirm(
      this.l('PersonDeleteWarningMessage', person.id),
      undefined,
      (result: boolean) => {
        if (result) {
          this._personService
            .delete(person.id)
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

