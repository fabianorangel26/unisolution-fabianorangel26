using Abp.Application.Services;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using UniSolution.FabianoRangel26.ContactList.Dto;

namespace UniSolution.FabianoRangel26.ContactList
{
    [AbpAuthorize]
    public class ContactAppService : AsyncCrudAppService<Contact, ContactDto, long, PagedContactResultRequestDto, CreateContactDto, ContactDto>, IContactAppService
    {
        private readonly IMapper _mapper;
        public ContactAppService(IRepository<Contact, long> contactRepository, IMapper mapper)
        : base(contactRepository)
        {
            _mapper = mapper;
        }
        public override async Task<ContactDto> Create(CreateContactDto input)
        {
            CheckCreatePermission();

            var contact = ObjectMapper.Map<Contact>(input);

            await Repository.InsertAsync(contact);

            CurrentUnitOfWork.SaveChanges();

            return _mapper.Map<ContactDto>(contact);
        }
        public override async Task<ContactDto> Update(ContactDto input)
        {
            CheckUpdatePermission();

            var contact = await Repository.GetAsync(input.Id);

            contact.Id = input.Id;
            contact.Name = input.Name;
            contact.Telephone = input.Telephone;
            contact.Email = input.Email;
            contact.IsActive = input.IsActive;

            await Repository.UpdateAsync(contact);

            return await Get(input);
        }

        protected override IQueryable<Contact> CreateFilteredQuery(PagedContactResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword) || x.Telephone.Contains(input.Keyword) || x.Email.Contains(input.Keyword))
                .WhereIf(input.IsActive.HasValue, x => x.IsActive == input.IsActive);
        }

    }
}
