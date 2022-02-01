using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace UniSolution.FabianoRangel26.Localization
{
    public static class FabianoRangel26LocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(FabianoRangel26Consts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(FabianoRangel26LocalizationConfigurer).GetAssembly(),
                        "UniSolution.FabianoRangel26.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
