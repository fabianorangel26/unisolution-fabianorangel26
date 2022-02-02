using Abp.Application.Services;
using UniSolution.FabianoRangel26.People.Dto;

namespace UniSolution.FabianoRangel26.People
{
    public interface IPersonAppService : IAsyncCrudAppService<PersonDto, long, PagedPersonResultRequestDto, CreatePersonDto, PersonDto>
    {
    }
}
