using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Umbraco.Core;
using Umbraco.Web;
using Umbraco.Web.PublishedCache;
using Umbraco.Web.Routing;
using Umbraco.Web.Security;

namespace UmbracoInstagram.Abstract
{
    public interface IUmbracoContextWrapper
    {
        MembershipHelper GetMembershipHelper();
        ContextualPublishedContentCache GetContentCache();
        UmbracoContext GetCurrentUmbracoContext();
        HttpContextBase GetHttpContext();
        ContextualPublishedMediaCache GetMediaCache();
        RoutingContext GetRoutingContext();
        WebSecurity GetSecurity();
        string GetDictionaryValue(string name);
        int GetCurrentPageId();
    }
}
