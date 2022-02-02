using UniSolution.FabianoRangel26.Debugging;

namespace UniSolution.FabianoRangel26
{
    public class FabianoRangel26Consts
    {
        public const string LocalizationSourceName = "FabianoRangel26";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "9db3cc51e67b490aabfe70b6b4729861";
    }
}
