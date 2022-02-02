using Abp.AutoMapper;
using UniSolution.FabianoRangel26.Sessions.Dto;

namespace UniSolution.FabianoRangel26.Web.Models.Account
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}