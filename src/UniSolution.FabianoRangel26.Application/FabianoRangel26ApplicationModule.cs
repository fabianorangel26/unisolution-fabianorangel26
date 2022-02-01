using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using UniSolution.FabianoRangel26.Authorization;

namespace UniSolution.FabianoRangel26
{
    [DependsOn(
        typeof(FabianoRangel26CoreModule), 
        typeof(AbpAutoMapperModule))]
    public class FabianoRangel26ApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<FabianoRangel26AuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(FabianoRangel26ApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
