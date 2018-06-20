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
        [TestMethod]
        public void TestMethod1()
        {
            var mock = new Mock<IUmbracoContextWrapper>();
            mock.Setup(a => a.GetCurrentUmbracoContext()).Returns(UmbracoContext.Current);
            var context = mock.Object;

            var memberService = ApplicationContext.Current.Services.MemberService;
            var memberController = new MemberController();

            var expectedResult = "/wall/";
            var newMember = new MemberModel { Name = "qwe", Email = "qwe@gmail.com", Password = "1111111111", ConfirmPassword = "1111111111" };
            var result = memberController.SignUp(newMember);
            Assert.AreEqual(result.ToString(), expectedResult);

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
            var memberService = ApplicationContext.Current.Services.MemberService;
            var memberController = new MemberController(new AutorizationService(memberService));

            var expectedResult = "/wall/";
            var newMember = new LoginModel { Username = "testuser@gmail.com",  Password = "1111111111"};
            var result = memberController.SubmitLogin(newMember);
            Assert.AreEqual(result.ToString(), expectedResult);

        }
    }
}


