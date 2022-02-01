using Abp.AutoMapper;
using UniSolution.FabianoRangel26.Authentication.External;

namespace UniSolution.FabianoRangel26.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
