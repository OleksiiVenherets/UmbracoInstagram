using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Services;
using UmbracoInstagram.Abstract;
using UmbracoInstagram.Abstract.IModels;


namespace UmbracoInstagram.Services
{
    public class CrudPostService : ICrudPostService
    {
        private readonly IContentService _contentService;

        public CrudPostService (IContentService contentService)
        {
            _contentService = contentService;
        }

        public void CreatePost(IPost model)
        {
            
        }

        public void DeletePost(string id)
        {
            throw new NotImplementedException();
        }

        public IPost GetPost(string id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePost(IPost model, string id)
        {
            throw new NotImplementedException();
        }
    }
}