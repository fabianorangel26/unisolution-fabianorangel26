using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using UniSolution.FabianoRangel26.EntityFramework;

namespace UniSolution.FabianoRangel26.Migrator
{
    [DependsOn(typeof(FabianoRangel26DataModule))]
    public class FabianoRangel26MigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<FabianoRangel26DbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}