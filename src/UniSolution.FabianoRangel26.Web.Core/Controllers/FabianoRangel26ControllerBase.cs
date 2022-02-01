using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace UniSolution.FabianoRangel26.Controllers
{
    public abstract class FabianoRangel26ControllerBase: AbpController
    {
        protected FabianoRangel26ControllerBase()
        {
            LocalizationSourceName = FabianoRangel26Consts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
