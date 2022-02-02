using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using UniSolution.FabianoRangel26.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace UniSolution.FabianoRangel26.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<FabianoRangel26.EntityFramework.FabianoRangel26DbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "FabianoRangel26";
        }

        protected override void Seed(FabianoRangel26.EntityFramework.FabianoRangel26DbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
