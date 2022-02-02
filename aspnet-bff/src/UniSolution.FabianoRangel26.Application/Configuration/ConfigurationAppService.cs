using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using UniSolution.FabianoRangel26.Configuration.Dto;

namespace UniSolution.FabianoRangel26.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : FabianoRangel26AppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
