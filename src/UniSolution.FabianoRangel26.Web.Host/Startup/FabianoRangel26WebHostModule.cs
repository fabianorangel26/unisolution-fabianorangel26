using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using UniSolution.FabianoRangel26.Configuration;

namespace UniSolution.FabianoRangel26.Web.Host.Startup
{
    [DependsOn(
       typeof(FabianoRangel26WebCoreModule))]
    public class FabianoRangel26WebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public FabianoRangel26WebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FabianoRangel26WebHostModule).GetAssembly());
        }
    }
}
