using Abp.Application.Services.Dto;

namespace UniSolution.FabianoRangel26.MultiTenancy.Dto
{
    public class PagedTenantResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}

