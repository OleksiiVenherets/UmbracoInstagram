using AutoMapper;
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
using Umbraco.Web.PublishedContentModels;
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
        private readonly IMappingEngine _mappingEngine;

        public CrudPostService(IContentService contentService, IUmbracoContextWrapper umbracoContextWrapper, IMediaService mediaService, ISystemMembershipService systemMembershipService, IMappingEngine mappingEngine)
        {
            _contentService = contentService;
            _umbracoContextWrapper = umbracoContextWrapper;
            _mediaService = mediaService;
            _systemMembershipService = systemMembershipService;
            _mappingEngine = mappingEngine;
        }

        public void CreatePost(PostViewModel model)
        {
            int currentPageId = _umbracoContextWrapper.GetCurrentPageId();
            IContent currentContent = _contentService.GetById(currentPageId);
            model.ParentId = currentContent.ParentId;

            var newImage = _mediaService.CreateMedia(model.PostDate.ToString(), -1, "Image");
            byte[] buffer = System.IO.File.ReadAllBytes(model.PostImage);
            MemoryStream strm = new MemoryStream(buffer);
            newImage.SetValue("umbracoFile", "myNewImage.png", strm);
            _mediaService.Save(newImage);

            var content = _contentService.CreateContent(DateTime.Today.ToString("yy/MM/dd"), model.ParentId, "Post");

            content.SetValue("postImage", newImage.Id);
            content.SetValue("postText", model.PostText);
            content.SetValue("postDate", model.PostDate);
            content.SetValue("memberID", model.MemberID);
            _contentService.SaveAndPublishWithStatus(content);
        }

        public void DeletePost(string id)
        {
            throw new NotImplementedException();
        }

        public List<PostViewModel> GetPosts()
        {
            List<PostViewModel> renderedPosts = new List<PostViewModel>();

            UmbracoHelper uHelper = _umbracoContextWrapper.GetUmbracoHelper();

            int currentPageId = _umbracoContextWrapper.GetCurrentPageId();
            var thisPage = uHelper.TypedContent(1118);
            var postNodes = thisPage.Children<Post>().ToList();
            postNodes.Remove(postNodes[0]);
            renderedPosts = _mappingEngine.Map<List<Post>, List<PostViewModel>>(postNodes);
            return AddImage(renderedPosts);
        }

        public void UpdatePost(IPost model, string id)
        {
            throw new NotImplementedException();
        }

        private List<PostViewModel> AddImage(List<PostViewModel>  renderedPosts)
        {
            IEnumerable<Node> nodes = uQuery.GetNodesByType("post");
            List<Node> newnodes = new List<Node>();
            foreach (var node in nodes)
            {
                if (node.Name != "CreatePost")
                    newnodes.Add(node);
            }
            UmbracoHelper uHelper = _umbracoContextWrapper.GetUmbracoHelper();

                for (int i = 0; i < renderedPosts.Count(); i++)
                {
                    var content = newnodes[i].GetProperty("postImage");
                    string nodeID = content != null ? content.Value.ToString() : "";
                    string url = "";
                    if (!string.IsNullOrWhiteSpace(nodeID))
                    {
                        var media = uHelper.TypedMedia(nodeID);
                        if (media != null)
                            url = media.Url;
                        renderedPosts[i].PostImage = url;
                    }
                }

            return renderedPosts;
        }
    }

}


