using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using UniSolution.FabianoRangel26.Authorization.Users;
using UniSolution.FabianoRangel26.MultiTenancy;
using UniSolution.FabianoRangel26.Users;
using Microsoft.AspNet.Identity;

namespace UniSolution.FabianoRangel26
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class FabianoRangel26AppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected FabianoRangel26AppServiceBase()
        {
            LocalizationSourceName = FabianoRangel26Consts.LocalizationSourceName;
        }

        protected virtual async Task<User> GetCurrentUserAsync()
        {
            var user = await UserManager.FindByIdAsync(AbpSession.GetUserId());
            if (user == null)
            {
                throw new ApplicationException("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}