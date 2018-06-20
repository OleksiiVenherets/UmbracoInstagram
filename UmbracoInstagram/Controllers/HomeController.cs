using System.Web.Mvc;
using Umbraco.Core.Services;

namespace UmbracoInstagram.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}