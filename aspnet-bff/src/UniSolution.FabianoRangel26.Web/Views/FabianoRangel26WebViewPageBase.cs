using Abp.Web.Mvc.Views;

namespace UniSolution.FabianoRangel26.Web.Views
{
    public abstract class FabianoRangel26WebViewPageBase : FabianoRangel26WebViewPageBase<dynamic>
    {

    }

    public abstract class FabianoRangel26WebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected FabianoRangel26WebViewPageBase()
        {
            LocalizationSourceName = FabianoRangel26Consts.LocalizationSourceName;
        }
    }
}