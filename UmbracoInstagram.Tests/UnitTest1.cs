using Moq;
using NUnit.Framework;
using UmbracoInstagram.Abstract;
using UmbracoInstagram.Controllers;
using UmbracoInstagram.Models;
using UmbracoInstagram.Services;

namespace UmbracoInstagram.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var mock = new Mock<IUmbracoContextWrapper>();
            mock.Setup(a => a.GetMemberService());
            
            var memberController = new MemberController(mock.Object);
           
            var expectedResult = "/wall/";
            var newMember = new MemberModel { Name = "qwe", Email = "qwe@gmail.com", Password = "1111111111", ConfirmPassword = "1111111111" };
            var result = memberController.SignUp(newMember);
            Assert.AreEqual(result.ToString(), expectedResult);
        }
    }
}
