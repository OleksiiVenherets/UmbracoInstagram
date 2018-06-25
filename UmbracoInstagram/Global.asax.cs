using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using AutoMapper;
using AutoMapper.Mappers;
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
            builder.RegisterType<AutorizationService>().As<IAutorizationService>();

            builder.RegisterType<SystemMembershipService>().As<ISystemMembershipService>();
            builder.RegisterType<FormAutentificationService>().As<IFormAutentificationService>();
            builder.RegisterType<CrudPostService>().As<ICrudPostService>();

            builder.Register(ctx => new UmbracoContextWrapper(Umbraco.Web.UmbracoContext.Current)).As<IUmbracoContextWrapper>().InstancePerLifetimeScope();

            builder.Register(ctx => ApplicationContext.Current.Services.MemberService).As<IMemberService>().InstancePerLifetimeScope();
            builder.RegisterInstance(ApplicationContext.Current.Services.ContentService).As<IContentService>();
            builder.RegisterInstance(ApplicationContext.Current.Services.MediaService).As<IMediaService>();

            builder.Register(c => {
                var s = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);
                s.CreateMap<Umbraco.Web.PublishedContentModels.Post, Models.PostViewModel>()
                    .ForMember(l => l.PostText, opt => opt.MapFrom(l => l.PostText))
                    .ForMember(l => l.PostDate, opt => opt.MapFrom(l => l.PostDate))
                    .ForMember(l => l.MemberID, opt => opt.MapFrom(l => l.MemberID))
                    .ForMember(l => l.PostImage, opt => opt.Ignore());
                return s;
            }).As<IConfigurationProvider>().SingleInstance();
            builder.RegisterType<MappingEngine>().As<IMappingEngine>();
        }
    }
}