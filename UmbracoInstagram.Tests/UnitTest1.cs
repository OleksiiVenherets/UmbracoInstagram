using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Umbraco.Core.Services;
using UmbracoInstagram;
using Umbraco;
using Moq;
using System.Linq;
using UmbracoInstagram.Services;
using Umbraco.Core;
using Umbraco.Web;
using UmbracoInstagram.Controllers;
using UmbracoInstagram.Models;
using Umbraco.Core.Persistence;
using UmbracoInstagram.Abstract;

namespace UmbracoInstagram.Tests
{
    [TestClass]
    public class RegistrationTest
    {
#pragma warning disable CS3002 // Return type is not CLS-compliant
        public UmbracoContext EnsureContext()
#pragma warning restore CS3002 // Return type is not CLS-compliant
        {
            var applicationContext = new ApplicationContext(
                CacheHelper.CreateDisabledCacheHelper(),
                new Umbraco.Core.Logging.ProfilingLogger(Mock.Of<Umbraco.Core.Logging.ILogger>(), Mock.Of<Umbraco.Core.Profiling.IProfiler>()));

            return UmbracoContext.EnsureContext(
                Mock.Of<System.Web.HttpContextBase>(),
                applicationContext,
                new Umbraco.Web.Security.WebSecurity(Mock.Of<System.Web.HttpContextBase>(), applicationContext),
                Mock.Of<Umbraco.Core.Configuration.UmbracoSettings.IUmbracoSettingsSection>(),
                Enumerable.Empty<Umbraco.Web.Routing.IUrlProvider>(),
                true);
        }

        [TestInitialize]
        public void Init()
        {
            EnsureContext();
        }

        [TestMethod]
        public void TestMethod1()
        {
            

            var mock = new Mock<IUmbracoContextWrapper>();

            var autorizationService = new Mock<IAutorizationService>();

            var memberController = new MemberController(autorizationService.Object);

            var expectedResult = "/wall/";
            var newMember = new MemberModel { Name = "qwe", Email = "qwe@gmail.com", Password = "1111111111", ConfirmPassword = "1111111111" };
            var result = memberController.SignUp(newMember);
            Assert.IsInstanceOfType(result, typeof(System.Web.Mvc.RedirectResult));
            var redirectResult = (System.Web.Mvc.RedirectResult)result;
            Assert.AreEqual(redirectResult.Url, expectedResult);

        }

        [TestMethod]
        public void TestMethod2()
        {
            var mock = new Mock<IUmbracoContextWrapper>();

            var autorizationService = new Mock<IAutorizationService>();

            var memberController = new MemberController(autorizationService.Object);

            var newMember = new LoginModel { Username = "zxc@gmail.com",  Password = "1111111111"};
            var result = memberController.SubmitLogin(newMember);
            Assert.IsInstanceOfType(result, typeof(Umbraco.Web.Mvc.UmbracoPageResult));
        }
    }
}