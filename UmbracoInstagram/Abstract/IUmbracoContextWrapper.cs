﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.PublishedCache;
using Umbraco.Web.Routing;
using Umbraco.Web.Security;

namespace UmbracoInstagram.Abstract
{
    public interface IUmbracoContextWrapper
    {
        ContextualPublishedContentCache GetContentCache();
        UmbracoContext GetCurrentUmbracoContext();
        HttpContextBase GetHttpContext();
        ContextualPublishedMediaCache GetMediaCache();
        RoutingContext GetRoutingContext();
        WebSecurity GetSecurity();
        IMemberService GetMemberService();
    }
}
