using System.Collections.Generic;

namespace UniSolution.FabianoRangel26.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
