using System.Threading.Tasks;
using UniSolution.FabianoRangel26.Configuration.Dto;

namespace UniSolution.FabianoRangel26.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
