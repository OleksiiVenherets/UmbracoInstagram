using System.Web.Mvc;
using Umbraco.Web.Mvc;
using UmbracoInstagram.Models;

namespace UmbracoInstagram.Controllers
{
    public class SiteLayoutController : SurfaceController
    {
        private const string _PATH = "~/Views/Partials/";
        public ActionResult RenderHeader()
        {
            return PartialView($"{_PATH}SiteLayout/_Header.cshtml");
        }

        public ActionResult RenderFooter()
        {
            return PartialView($"{_PATH}SiteLayout/_Footer.cshtml");
        }

        public ActionResult RenderLogin()
        {
            return PartialView($"{_PATH}Member/_Login.cshtml", new LoginModel());
        }

        public ActionResult RenderLogout()
        {
            return PartialView($"{_PATH}Member/_Logout.cshtml", null);
        }

        public ActionResult RenderRegister()
        {
            return PartialView($"{_PATH}Member/_Register.cshtml", null);
        }

        public ActionResult RenderError()
        {
            return PartialView($"{_PATH}_Error.cshtml", null);
        }
    }
}