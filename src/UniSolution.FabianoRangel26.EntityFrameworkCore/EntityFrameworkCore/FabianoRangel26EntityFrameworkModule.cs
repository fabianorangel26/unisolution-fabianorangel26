using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using UniSolution.FabianoRangel26.EntityFrameworkCore.Seed;

namespace UniSolution.FabianoRangel26.EntityFrameworkCore
{
    [DependsOn(
        typeof(FabianoRangel26CoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class FabianoRangel26EntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<FabianoRangel26DbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        FabianoRangel26DbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        FabianoRangel26DbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FabianoRangel26EntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
