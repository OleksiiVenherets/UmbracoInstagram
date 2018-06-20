using Autofac;
using Autofac.Integration.Mvc;
using Umbraco.Core;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Umbraco.Core.Services;
using Umbraco.Web;
using Autofac.Integration.WebApi;
using UmbracoInstagram.Services;
using UmbracoInstagram.Abstract;

namespace UmbracoInstagram.EventHandlers
{
    public class UmbracoInstagramEventHandler: IApplicationEventHandler
    {
        public void OnApplicationInitialized(UmbracoApplicationBase application, ApplicationContext context)
        {
        }

        public void OnApplicationStarting(UmbracoApplicationBase application, ApplicationContext context)
        {
        }

        public void OnApplicationStarted(UmbracoApplicationBase application, ApplicationContext context)
        {
            var builder = new ContainerBuilder();

            // Register all controllers found in this assembly
            builder.RegisterInstance(ApplicationContext.Current).AsSelf();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(typeof(UmbracoApplication).Assembly);// Web API

            // Add types to be resolved
            RegisterTypes(builder, context);

            // Configure Http and Controller Resolvers
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);// web api
            GlobalConfiguration.Configuration.DependencyResolver = resolver; // web api
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }


        private static void RegisterTypes(ContainerBuilder builder, ApplicationContext applicationContext)
        {
            builder.RegisterInstance(applicationContext.Services.MemberService)
                .As<IMemberService>();
            builder.RegisterType<AutorizationService>().As<IAutorizationService>();

        }

    }
}