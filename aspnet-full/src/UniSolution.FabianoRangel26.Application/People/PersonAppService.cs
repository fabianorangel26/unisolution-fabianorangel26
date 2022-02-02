using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using UniSolution.FabianoRangel26.People.Dto;

namespace UniSolution.FabianoRangel26.People
{
    [AbpAuthorize]
    public class PersonAppService : AsyncCrudAppService<Person, PersonDto, long, PagedPersonResultRequestDto, CreatePersonDto, PersonDto>, IPersonAppService
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="personRepository"></param>
        public PersonAppService(IRepository<Person, long> personRepository, IMapper mapper)
           : base(personRepository)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Create Person Method
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override async Task<PersonDto> Create(CreatePersonDto input)
        {
            CheckCreatePermission();

            var person = ObjectMapper.Map<Person>(input);

            await Repository.InsertAsync(person);

            CurrentUnitOfWork.SaveChanges();

            return _mapper.Map<PersonDto>(person);
        }

        /// <summary>
        /// Update Method
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override async Task<PersonDto> Update(PersonDto input)
        {
            CheckUpdatePermission();

            var person = await Repository.GetAsync(input.Id);

            person.Name = input.Name;
            person.Document = input.Document;
            person.DocumentType = input.DocumentType;
            person.IsActive = input.IsActive;

            await Repository.UpdateAsync(person);

            return await Get(input);
        }

        protected override IQueryable<Person> CreateFilteredQuery(PagedPersonResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword) || x.Document.Contains(input.Keyword))
                .WhereIf(input.IsActive.HasValue, x => x.IsActive == input.IsActive);
        }

    }
}
