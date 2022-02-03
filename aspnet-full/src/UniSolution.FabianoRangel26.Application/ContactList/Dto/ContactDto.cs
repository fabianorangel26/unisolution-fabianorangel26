using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;

namespace UniSolution.FabianoRangel26.ContactList.Dto
{
    [AutoMapFrom(typeof(Contact))]
    public class ContactDto : FullAuditedEntityDto<long>
    {
        [Required]
        public long PersonId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Telephone { get; set; }

        [Required]
        public string Email { get; set; }

        public bool IsActive { get; set; }
    }
}
