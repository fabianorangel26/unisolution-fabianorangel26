using Abp.Application.Services;
using Abp.Application.Services.Dto;
using UniSolution.FabianoRangel26.MultiTenancy.Dto;

namespace UniSolution.FabianoRangel26.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
