using System.ComponentModel.DataAnnotations;

namespace UniSolution.FabianoRangel26.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}