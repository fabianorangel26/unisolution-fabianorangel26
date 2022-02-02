using System.Threading.Tasks;
using Abp.Application.Services;
using UniSolution.FabianoRangel26.Sessions.Dto;

namespace UniSolution.FabianoRangel26.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
