using System.Web;
using Umbraco.Web;
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
            return UmbracoContext.Current.ContentCache;
        }

        public ContextualPublishedMediaCache GetMediaCache()
        {
            return UmbracoContext.Current.MediaCache;
        }

        public UmbracoContext GetCurrentUmbracoContext()
        {
            return UmbracoContext.Current;
        }

        public HttpContextBase GetHttpContext()
        {
            return UmbracoContext.Current.HttpContext;
        }

        public RoutingContext GetRoutingContext()
        {
            return UmbracoContext.Current.RoutingContext;
        }

        public WebSecurity GetSecurity()
        {
            return UmbracoContext.Current.Security;
        }
    }
}