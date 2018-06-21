using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmbracoInstagram.Abstract.IModels;

namespace UmbracoInstagram.Abstract
{
    public interface ICrudPostService
    {
        void CreatePost(IPost model);
        IPost GetPost(string id);
        void UpdatePost(IPost model, string id);
        void DeletePost(string id);
    }
}
