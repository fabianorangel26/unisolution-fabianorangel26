using System.Threading.Tasks;
using Abp.Application.Services;
using UniSolution.FabianoRangel26.Authorization.Accounts.Dto;

namespace UniSolution.FabianoRangel26.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
