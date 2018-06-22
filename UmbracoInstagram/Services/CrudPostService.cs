using ClientDependency.Core.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using umbraco;
using umbraco.NodeFactory;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web;
using UmbracoInstagram.Abstract;
using UmbracoInstagram.Abstract.IModels;
using UmbracoInstagram.Models;

namespace UmbracoInstagram.Services
{
    public class CrudPostService : ICrudPostService
    {
        private readonly IContentService _contentService;
        private readonly IUmbracoContextWrapper _umbracoContextWrapper;
        private readonly IMediaService _mediaService;
        private readonly ISystemMembershipService _systemMembershipService;

        public CrudPostService (IContentService contentService, IUmbracoContextWrapper umbracoContextWrapper, IMediaService mediaService, ISystemMembershipService systemMembershipService)
        {
            _contentService = contentService;
            _umbracoContextWrapper = umbracoContextWrapper;
            _mediaService = mediaService;
            _systemMembershipService = systemMembershipService;
        }

        public void CreatePost(PostViewModel model)
        {
            int currentPageId = _umbracoContextWrapper.GetCurrentPageId();
            IContent currentContent = _contentService.GetById(currentPageId);
            model.ParentId = currentContent.ParentId;
            int userId = 0;
            
            var name = DateTime.Now.ToIsoString();
            var originalPath = Path.GetFullPath(model.PostImage.FileName);
            var newImage = _mediaService.CreateMedia(name, -1, "Image");
            byte[] buffer = System.IO.File.ReadAllBytes(originalPath);
            MemoryStream strm = new MemoryStream(buffer);
            newImage.SetValue("umbracoFile", "myNewImage.png", strm);
            _mediaService.Save(newImage);
           
            var content = _contentService.CreateContent(DateTime.Today.ToString("yy/MM/dd"), model.ParentId, "Post", userId);
            content.SetValue("postImage", newImage.Id);
            content.SetValue("postText", model.PostText);
            content.SetValue("postDate", model.PostDate);
            _contentService.SaveAndPublishWithStatus(content);
        }

        public void DeletePost(string id)
        {
            throw new NotImplementedException();
        }

        public List<GetPostsViewModel> GetPosts()
        {
            IEnumerable <Node> nodes = uQuery.GetNodesByType("post");
            List<Node> newnodes = new List<Node>();
            foreach (var node in nodes)
            {
                if (node.Name != "CreatePost")
                    newnodes.Add(node);
            }

            List<GetPostsViewModel> posts = new List<GetPostsViewModel>();

            UmbracoHelper uHelper = new UmbracoHelper(UmbracoContext.Current);
            foreach (var node in newnodes)
            {
                if (node.HasProperty("postImage"))
                {
                    var content = uHelper.Media(node.GetProperty("postImage").Value);
                    var url = content.umbracoFile;
                    posts.Add(
                        new GetPostsViewModel
                        {
                            PostText = node.GetProperty("postText").Value,
                            PostDate = Convert.ToDateTime(node.GetProperty("postDate").Value),
                            PostImage = url,
                            CreatorId = node.CreatorID
                        });
                }
            }
            return posts;
        }

        public void UpdatePost(IPost model, string id)
        {
            throw new NotImplementedException();
        }
    }
}