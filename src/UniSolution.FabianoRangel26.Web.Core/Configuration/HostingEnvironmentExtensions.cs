using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace UniSolution.FabianoRangel26.Configuration
{
using Microsoft.AspNetCore.Hosting;

    /// <summary>
    /// Hosting Environment Extensions
    /// </summary>
    public static class HostingEnvironmentExtensions
    {
        /// <summary>
        /// Get App Configuration
        /// </summary>
        /// <param name="env"></param>
        /// <returns></returns>
        public static IConfigurationRoot GetAppConfiguration(this IHostingEnvironment env)
        {
            return AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName, env.IsDevelopment());
        }
    }
}
