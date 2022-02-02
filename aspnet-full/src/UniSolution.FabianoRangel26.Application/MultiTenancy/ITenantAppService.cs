using Abp.Application.Services;
using UniSolution.FabianoRangel26.MultiTenancy.Dto;

namespace UniSolution.FabianoRangel26.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

