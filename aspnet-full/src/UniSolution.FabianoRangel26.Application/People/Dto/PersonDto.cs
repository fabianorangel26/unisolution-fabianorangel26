using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace UniSolution.FabianoRangel26.People.Dto
{
    [AutoMapFrom(typeof(Person))]
    public class PersonDto : FullAuditedEntityDto<long>
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