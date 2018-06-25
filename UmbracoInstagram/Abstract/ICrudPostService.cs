using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umbraco.NodeFactory;
using Umbraco.Core.Models;
using UmbracoInstagram.Abstract.IModels;
using UmbracoInstagram.Models;

namespace UmbracoInstagram.Abstract
{
    public interface ICrudPostService
    {
        void CreatePost(PostViewModel model);
        List<PostViewModel> GetPosts();
        void UpdatePost(IPost model, string id);
        void DeletePost(string id);
    }
}
