using Abp.AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;

namespace UniSolution.FabianoRangel26.ContactList.Dto
{
    [AutoMapTo(typeof(Contact))]
    public class CreateContactDto
    {
        [Required]
        public long PersonId { get; set; }

        [Required]
        [StringLength(Contact.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(Contact.MaxTelephoneLength)]
        public string Telephone { get; set; }

        [Required]
        [StringLength(Contact.MaxEmailLength)]
        public string Email { get; set; }

        public bool IsActive { get; set; }
    }
}
