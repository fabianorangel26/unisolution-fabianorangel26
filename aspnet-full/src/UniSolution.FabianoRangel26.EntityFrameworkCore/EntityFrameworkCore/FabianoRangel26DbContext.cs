using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using UniSolution.FabianoRangel26.Authorization.Roles;
using UniSolution.FabianoRangel26.Authorization.Users;
using UniSolution.FabianoRangel26.MultiTenancy;

namespace UniSolution.FabianoRangel26.EntityFrameworkCore
{
    using People;
    using UniSolution.FabianoRangel26.ContactList;

    public class FabianoRangel26DbContext : AbpZeroDbContext<Tenant, Role, User, FabianoRangel26DbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }

        public FabianoRangel26DbContext(DbContextOptions<FabianoRangel26DbContext> options)
            : base(options)
        {
        }
    }
}
