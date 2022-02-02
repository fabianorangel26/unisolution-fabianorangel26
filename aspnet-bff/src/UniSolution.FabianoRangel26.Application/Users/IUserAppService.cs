using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using UniSolution.FabianoRangel26.Roles.Dto;
using UniSolution.FabianoRangel26.Users.Dto;

namespace UniSolution.FabianoRangel26.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}