using System.ComponentModel.DataAnnotations;

namespace UniSolution.FabianoRangel26.Configuration.Dto
{
    public class ChangeUiThemeInput
    {
        [Required]
        [MaxLength(32)]
        public string Theme { get; set; }
    }
}