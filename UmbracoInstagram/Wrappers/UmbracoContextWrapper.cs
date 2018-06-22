using System;
using System.Web;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using Umbraco.Web.PublishedCache;
using Umbraco.Web.Routing;
using Umbraco.Web.Security;
using UmbracoInstagram.Abstract;

namespace UmbracoInstagram.Wrappers
{
    public class UmbracoContextWrapper : IUmbracoContextWrapper
    {
        public UmbracoContext UmbracoContext { get; private set; }

        public UmbracoContextWrapper(UmbracoContext umbContext)
        {
            this.UmbracoContext = umbContext;
        }

        public MembershipHelper GetMembershipHelper()
        {
            return new MembershipHelper(this.UmbracoContext);
        }

        public ContextualPublishedContentCache GetContentCache()
        {
            return this.UmbracoContext.ContentCache;
        }

        public ContextualPublishedMediaCache GetMediaCache()
        {
            return this.UmbracoContext.MediaCache;
        }

        public UmbracoContext GetCurrentUmbracoContext()
        {
            return this.UmbracoContext;
        }

        public HttpContextBase GetHttpContext()
        {
            return this.UmbracoContext.HttpContext;
        }

        public RoutingContext GetRoutingContext()
        {
            return this.UmbracoContext.RoutingContext;
        }

        public WebSecurity GetSecurity()
        {
            return this.UmbracoContext.Security;
        }

        public string GetDictionaryValue(string name)
        {
            var umbracoHelper = new UmbracoHelper();
            return umbracoHelper.GetDictionaryValue(name);
        }

        public int GetCurrentPageId()
        {
            return Convert.ToInt32(this.UmbracoContext.PageId);
        }
    }
}