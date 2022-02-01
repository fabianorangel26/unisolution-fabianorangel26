using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using UniSolution.FabianoRangel26.Configuration;
using UniSolution.FabianoRangel26.EntityFrameworkCore;
using UniSolution.FabianoRangel26.Migrator.DependencyInjection;

namespace UniSolution.FabianoRangel26.Migrator
{
    [DependsOn(typeof(FabianoRangel26EntityFrameworkModule))]
    public class FabianoRangel26MigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public FabianoRangel26MigratorModule(FabianoRangel26EntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(FabianoRangel26MigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                FabianoRangel26Consts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FabianoRangel26MigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
