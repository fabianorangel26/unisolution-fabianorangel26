using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace UniSolution.FabianoRangel26.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : FabianoRangel26ControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}