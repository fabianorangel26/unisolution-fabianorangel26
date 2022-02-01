using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using UniSolution.FabianoRangel26.Configuration;
using UniSolution.FabianoRangel26.Web;

namespace UniSolution.FabianoRangel26.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class FabianoRangel26DbContextFactory : IDesignTimeDbContextFactory<FabianoRangel26DbContext>
    {
        public FabianoRangel26DbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<FabianoRangel26DbContext>();
            
            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            FabianoRangel26DbContextConfigurer.Configure(builder, configuration.GetConnectionString(FabianoRangel26Consts.ConnectionStringName));

            return new FabianoRangel26DbContext(builder.Options);
        }
    }
}
