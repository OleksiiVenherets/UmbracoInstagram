using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using umbraco;
using umbraco.NodeFactory;
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

        public ActionResult CreatePost(PostViewModel model, HttpPostedFileBase file)
        {
            model.PostDate = DateTime.Now.Date;
            model.PostImage = file;
            if (ModelState.IsValid)
            {
                _crudPostService.CreatePost(model);
            }
            return Redirect("/wall/");
        }       
    }
}