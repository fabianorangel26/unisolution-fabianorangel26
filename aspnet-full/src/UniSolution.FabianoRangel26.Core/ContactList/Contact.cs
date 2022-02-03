using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniSolution.FabianoRangel26.People;

namespace UniSolution.FabianoRangel26.ContactList
{
    [Table("ListaContatos")]
    public class Contact : FullAuditedEntity<long>
    {
        public const int MaxNameLength = 128;
        public const int MaxTelephoneLength = 32;
        public const int MaxEmailLength = 512;

        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long Id { get; set; }

        [ForeignKey("Person")]
        [Column("PessoaID")]
        public long PersonId { get; set; }
        public virtual Person Person { get; set; }

        [Column("Contato")]
        [StringLength(MaxNameLength)]
        [Required]
        public string Name { get; set; }

        [Column("Telefone")]
        [StringLength(MaxTelephoneLength)]
        [Required]
        public string Telephone { get; set; }

        [Column("Email")]
        [StringLength(MaxEmailLength)]
        [Required]
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
