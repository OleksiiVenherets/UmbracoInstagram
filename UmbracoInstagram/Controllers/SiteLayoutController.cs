using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
namespace UmbracoInstagram.Controllers
{
    public class SiteLayoutController : SurfaceController
    {
        public ActionResult RenderHeader()
        {
            return PartialView("~Views/Partials/SiteLayout/_Header.cshtml");
        }

        public ActionResult RenderFooter()
        {
            return PartialView("~Views/Partials/SiteLayout/_Footer.cshtml");
        }
    }
}