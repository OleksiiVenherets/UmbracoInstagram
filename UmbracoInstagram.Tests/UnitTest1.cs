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
            //mock.Setup(a => a.GetCurrentUmbracoContext()).Returns(UmbracoContext.Current);
            //var context = mock.Object;

            var autorizationService = new Mock<IAutorizationService>();

            //var memberService = ApplicationContext.Current.Services.MemberService;
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
            //var appCtx = ApplicationContext.EnsureContext(
            //    new DatabaseContext(Mock.Of(), Mock.Of(), new SqlSyntaxProviders(new[] { Mock.Of() })),
            //    new ServiceContext(),
            //    CacheHelper.CreateDisabledCacheHelper(),
            //    new ProfilingLogger(
            //        Mock.Of(),
            //        Mock.Of()), true);

            //var ctx = UmbracoContext.EnsureContext(
            //    Mock.Of(),
            //    appCtx,
            //    new Mock(null, null).Object,
            //    Mock.Of(),
            //    Enumerable.Empty(), true);
            var mock = new Mock<IUmbracoContextWrapper>();
            var memberService = new Mock<IMemberService>();
            var systemMembershipService = new Mock<ISystemMembershipService>();
            systemMembershipService.Setup(l => l.ValidateUser(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            var memberController = new MemberController(new AutorizationService(memberService.Object, mock.Object, systemMembershipService.Object));

            var expectedResult = "/wall/";
            var newMember = new LoginModel { Username = "testuser@gmail.com",  Password = "1111111111"};
            var result = memberController.SubmitLogin(newMember);
            Assert.AreEqual(result.ToString(), expectedResult);

        }
    }
}


