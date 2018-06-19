using System.Web.Mvc;
using Umbraco.Web.Mvc;
using UmbracoInstagram.Models;

namespace UmbracoInstagram.Controllers
{
    public class SiteLayoutController : SurfaceController
    {
        public ActionResult RenderHeader()
        {
            return PartialView("~/Views/Partials/SiteLayout/_Header.cshtml");
        }

        public ActionResult RenderFooter()
        {
            return PartialView("~/Views/Partials/SiteLayout/_Footer.cshtml");
        }

        public ActionResult RenderLogin()
        {
            return PartialView("~/Views/Partials/_Login.cshtml", new LoginModel());
        }

        public ActionResult RenderLogout()
        {
            return PartialView("_Logout", null);
        }

        public ActionResult RenderRegister()
        {
            return PartialView("_Register", null);
        }
    }
}