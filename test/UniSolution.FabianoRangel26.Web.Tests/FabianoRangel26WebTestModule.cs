using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using UniSolution.FabianoRangel26.EntityFrameworkCore;
using UniSolution.FabianoRangel26.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace UniSolution.FabianoRangel26.Web.Tests
{
    [DependsOn(
        typeof(FabianoRangel26WebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class FabianoRangel26WebTestModule : AbpModule
    {
        public FabianoRangel26WebTestModule(FabianoRangel26EntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FabianoRangel26WebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(FabianoRangel26WebMvcModule).Assembly);
        }
    }
}