using Abp.Application.Services.Dto;

namespace UniSolution.FabianoRangel26.ContactList.Dto
{
    public class PagedContactResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
