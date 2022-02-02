using System.Linq;
using Abp.Application.Editions;
using UniSolution.FabianoRangel26.Editions;
using UniSolution.FabianoRangel26.EntityFramework;

namespace UniSolution.FabianoRangel26.Migrations.SeedData
{
    public class DefaultEditionsCreator
    {
        private readonly FabianoRangel26DbContext _context;

        public DefaultEditionsCreator(FabianoRangel26DbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateEditions();
        }

        private void CreateEditions()
        {
            var defaultEdition = _context.Editions.FirstOrDefault(e => e.Name == EditionManager.DefaultEditionName);
            if (defaultEdition == null)
            {
                defaultEdition = new Edition { Name = EditionManager.DefaultEditionName, DisplayName = EditionManager.DefaultEditionName };
                _context.Editions.Add(defaultEdition);
                _context.SaveChanges();

                //TODO: Add desired features to the standard edition, if wanted!
            }   
        }
    }
}