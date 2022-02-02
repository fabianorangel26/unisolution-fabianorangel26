using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using UniSolution.FabianoRangel26.EntityFramework;

namespace UniSolution.FabianoRangel26
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(FabianoRangel26CoreModule))]
    public class FabianoRangel26DataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<FabianoRangel26DbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
