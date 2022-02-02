using Abp.MultiTenancy;
using UniSolution.FabianoRangel26.Authorization.Users;

namespace UniSolution.FabianoRangel26.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {
            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}