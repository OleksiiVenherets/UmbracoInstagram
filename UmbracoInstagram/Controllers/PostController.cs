using System.Web.Mvc;

namespace UmbracoInstagram.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult AddPost()
        {
            return View();
        }
    }
}