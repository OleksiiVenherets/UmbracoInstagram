using System.Web.Mvc;
using UmbracoInstagram.Models;

namespace UmbracoInstagram.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }

        // GET: Post/Details/5
        public ActionResult ShowPost(int id)
        {
            return View();
        }

        // GET: Post/Create
        public ActionResult CreatePost()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult CreatePost(PostViewModel postViewModel)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }       
    }
}
