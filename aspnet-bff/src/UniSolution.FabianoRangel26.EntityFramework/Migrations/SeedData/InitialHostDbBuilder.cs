using UniSolution.FabianoRangel26.EntityFramework;
using EntityFramework.DynamicFilters;

namespace UniSolution.FabianoRangel26.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly FabianoRangel26DbContext _context;

        public InitialHostDbBuilder(FabianoRangel26DbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
