using Abp.Application.Services;
using System;
using UniSolution.FabianoRangel26.ContactList.Dto;

namespace UniSolution.FabianoRangel26.ContactList
{
    public interface IContactAppService : IAsyncCrudAppService<ContactDto, long, PagedContactResultRequestDto, CreateContactDto, ContactDto>
    {
    }
}
