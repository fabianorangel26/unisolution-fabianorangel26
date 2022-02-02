using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;

namespace UniSolution.FabianoRangel26.People.Dto
{
    [AutoMapTo(typeof(Person))]
    public class CreatePersonDto
    {
        [Required]
        [StringLength(Person.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(Person.MaxDocumentLength)]
        public string Document { get; set; }

        [Required]
        public int DocumentType { get; set; }

        public bool IsActive { get; set; }
    }
}