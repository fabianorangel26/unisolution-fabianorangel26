using System.Threading.Tasks;
using Abp.Application.Services;
using UniSolution.FabianoRangel26.Configuration.Dto;

namespace UniSolution.FabianoRangel26.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}