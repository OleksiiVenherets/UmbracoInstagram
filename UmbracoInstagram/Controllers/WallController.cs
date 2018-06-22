using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using UmbracoInstagram.Abstract;

namespace UmbracoInstagram.Controllers
{
    public class WallController: SurfaceController
    {
        private readonly ICrudPostService _crudPostService;
        public WallController(ICrudPostService crudPostService)
        {
            _crudPostService = crudPostService;
        }

        public ActionResult ShowAllPosts()
        {
            var postsList = _crudPostService.GetPosts();
            return View("~/Views/Wall.cshtml", postsList.ToList());
        }
    }
}