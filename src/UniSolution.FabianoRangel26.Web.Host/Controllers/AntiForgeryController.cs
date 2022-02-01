using Abp.Web.Security.AntiForgery;
using Microsoft.AspNetCore.Antiforgery;
using UniSolution.FabianoRangel26.Controllers;

namespace UniSolution.FabianoRangel26.Web.Host.Controllers
{
    public class AntiForgeryController : FabianoRangel26ControllerBase
    {
        private readonly IAntiforgery _antiforgery;
        private readonly IAbpAntiForgeryManager _antiForgeryManager;

        public AntiForgeryController(IAntiforgery antiforgery, IAbpAntiForgeryManager antiForgeryManager)
        {
            _antiforgery = antiforgery;
            _antiForgeryManager = antiForgeryManager;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }

        public void SetCookie()
        {
            _antiForgeryManager.SetCookie(HttpContext);
        }
    }
}
