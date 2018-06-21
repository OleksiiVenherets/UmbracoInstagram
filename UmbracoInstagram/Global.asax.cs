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
        protected override void OnApplicationStarting(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();

            builder.RegisterInstance(ApplicationContext.Current).AsSelf();

            builder.RegisterControllers(typeof(Umbraco.Web.UmbracoContext).Assembly);
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterApiControllers(typeof(Umbraco.Web.UmbracoContext).Assembly);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterFilterProvider();

            // Add types to be resolved
            RegisterTypes(builder);

            // Configure Http and Controller Resolvers
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);// web api
            GlobalConfiguration.Configuration.DependencyResolver = resolver; // web api
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            base.OnApplicationStarting(sender, e);
        }
    
        private static void RegisterTypes(ContainerBuilder builder)
        {
            //builder.RegisterInstance(applicationContext.Services.MemberService).As<IMemberService>();

            builder.RegisterType<AutorizationService>().As<IAutorizationService>();

            builder.RegisterType<SystemMembershipService>().As<ISystemMembershipService>();
            builder.RegisterType<FormAutentificationService>().As<IFormAutentificationService>();
            builder.RegisterType<CrudPostService>().As<ICrudPostService>();

            builder.Register(ctx => new UmbracoContextWrapper(Umbraco.Web.UmbracoContext.Current)).As<IUmbracoContextWrapper>().InstancePerLifetimeScope();

            builder.Register(ctx => ApplicationContext.Current.Services.MemberService).As<IMemberService>().InstancePerLifetimeScope();
            builder.Register(ctx => ApplicationContext.Current.Services.ConsentService).As<IContentService>().InstancePerLifetimeScope();

        }
    }
}