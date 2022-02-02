using System.Data.Common;
using System.Data.Entity;
using Abp.DynamicEntityProperties;
using Abp.Zero.EntityFramework;
using UniSolution.FabianoRangel26.Authorization.Roles;
using UniSolution.FabianoRangel26.Authorization.Users;
using UniSolution.FabianoRangel26.MultiTenancy;

namespace UniSolution.FabianoRangel26.EntityFramework
{
    public class FabianoRangel26DbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public FabianoRangel26DbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in FabianoRangel26DataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of FabianoRangel26DbContext since ABP automatically handles it.
         */
        public FabianoRangel26DbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public FabianoRangel26DbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public FabianoRangel26DbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DynamicProperty>().Property(p => p.PropertyName).HasMaxLength(250);
            modelBuilder.Entity<DynamicEntityProperty>().Property(p => p.EntityFullName).HasMaxLength(250);
        }
    }
}
