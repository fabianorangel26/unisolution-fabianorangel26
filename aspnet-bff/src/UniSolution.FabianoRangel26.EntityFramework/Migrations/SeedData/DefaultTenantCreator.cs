using System.Linq;
using UniSolution.FabianoRangel26.EntityFramework;
using UniSolution.FabianoRangel26.MultiTenancy;

namespace UniSolution.FabianoRangel26.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly FabianoRangel26DbContext _context;

        public DefaultTenantCreator(FabianoRangel26DbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
