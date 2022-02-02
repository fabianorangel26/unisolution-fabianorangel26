using Abp.Application.Services.Dto;

namespace UniSolution.FabianoRangel26.People.Dto
{
    public class PagedPersonResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}