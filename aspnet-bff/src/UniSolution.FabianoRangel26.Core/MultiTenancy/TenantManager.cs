using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using UniSolution.FabianoRangel26.Authorization.Users;
using UniSolution.FabianoRangel26.Editions;

namespace UniSolution.FabianoRangel26.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore
            ) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore
            )
        {
        }
    }
}