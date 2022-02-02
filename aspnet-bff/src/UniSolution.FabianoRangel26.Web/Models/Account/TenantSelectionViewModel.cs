using System.Collections.Generic;
using Abp.AutoMapper;
using UniSolution.FabianoRangel26.MultiTenancy;

namespace UniSolution.FabianoRangel26.Web.Models.Account
{
    public class TenantSelectionViewModel
    {
        public string Action { get; set; }

        public List<TenantInfo> Tenants { get; set; }

        [AutoMapFrom(typeof(Tenant))]
        public class TenantInfo
        {
            public int Id { get; set; }

            public string TenancyName { get; set; }

            public string Name { get; set; }
        }
    }
}