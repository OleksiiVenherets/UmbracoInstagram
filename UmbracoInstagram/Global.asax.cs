using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Umbraco.Core;
using Umbraco.Core.Services;
using UmbracoInstagram.Abstract;
using UmbracoInstagram.Services;
using UmbracoInstagram.Wrappers;

namespace UmbracoInstagram
{
    public class Global : Umbraco.Web.UmbracoApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();

            // Register all controllers found in this assembly
            builder.RegisterInstance(ApplicationContext.Current).AsSelf();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(typeof(Global).Assembly);// Web API

            // Add types to be resolved
            RegisterTypes(builder, ApplicationContext.Current);

            // Configure Http and Controller Resolvers
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);// web api
            GlobalConfiguration.Configuration.DependencyResolver = resolver; // web api
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    
        private static void RegisterTypes(ContainerBuilder builder, ApplicationContext applicationContext)
        {
            builder.RegisterInstance(applicationContext.Services.MemberService)
                .As<IMemberService>();
            builder.RegisterType<AutorizationService>().As<IAutorizationService>();
            builder.RegisterType<UmbracoContextWrapper>().As<IUmbracoContextWrapper>();
        }
    }
}