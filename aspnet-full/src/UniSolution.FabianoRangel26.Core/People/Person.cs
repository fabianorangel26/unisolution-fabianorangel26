using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniSolution.FabianoRangel26.People
{
    [Table("Pessoa")]
    public class Person : FullAuditedEntity<long>
    {
        public const int MaxNameLength = 128;

        public const int MaxDocumentLength = 64;

        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public override long Id { get; set; }

        [Required]
        [Column("Nome")]
        [StringLength(MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [Column("Documento")]
        [StringLength(MaxDocumentLength)]
        public string Document { get; set; }

        [Required]
        [Column("TipoDocumento")]
        public int DocumentType { get; set; }
        public bool IsActive { get; set; }
    }
}
