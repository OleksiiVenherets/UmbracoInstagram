using System;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using UmbracoInstagram.Abstract;
using UmbracoInstagram.Abstract.IModels;
using UmbracoInstagram.Models;

namespace UmbracoInstagram.Controllers
{
    public class PostController: SurfaceController
    {
        private readonly ICrudPostService _crudPostService;

        public PostController(ICrudPostService crudPostService)
        {
            _crudPostService = crudPostService;
        }

        public ActionResult CreatePost(IPost model)
        {
            model.PostDate = DateTime.Now.Date;
            if (ModelState.IsValid)
            {
                _crudPostService.CreatePost(model);
            }
            return Redirect("/wall/");
        }
    }
}