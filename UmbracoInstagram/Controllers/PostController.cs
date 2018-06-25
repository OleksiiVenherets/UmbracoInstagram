using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly ISystemMembershipService _systemMembershipService;

        public PostController(ICrudPostService crudPostService, ISystemMembershipService systemMembershipService)
        {
            _crudPostService = crudPostService;
            _systemMembershipService = systemMembershipService;
        }

        public ActionResult CreatePost(PostViewModel model, HttpPostedFileBase file)
        {
            model.PostDate = DateTime.Now;
            model.PostImage = Path.GetFullPath(file.FileName); ;
            model.MemberID  = _systemMembershipService.GetMemberId();
            if (ModelState.IsValid)
            {
                _crudPostService.CreatePost(model);
            }
            return RedirectToAction("ShowAllPosts", "Wall");
        }       
    }
}