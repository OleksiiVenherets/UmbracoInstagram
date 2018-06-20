using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Core.Models;
using Umbraco.Web.Mvc;
using UmbracoInstagram.Abstract;
using UmbracoInstagram.Models;
using UmbracoInstagram.Services;

namespace UmbracoInstagram.Controllers
{
    public class MemberController : SurfaceController
    {
        private readonly IAutorizationService _autorizationService;

        public MemberController(IAutorizationService autorizationService)
        {
            _autorizationService = autorizationService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitLogin(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if ( _autorizationService.IsValidate(model))
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    UrlHelper myHelper = new UrlHelper(HttpContext.Request.RequestContext);
                    if (myHelper.IsLocalUrl("/wall/"))
                    {
                        return Redirect("/wall/");
                    }
                    else
                    {
                        return Redirect("/login/");
                    }
                }
                else
                {
                    ModelState.AddModelError("", Umbraco.GetDictionaryValue("LoginError"));
                }
            }
            return CurrentUmbracoPage();
        }

        public ActionResult SignUp(MemberModel model)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();

            var memberService = Services.MemberService;
            if (_autorizationService.IsEmailAddressExists(model.Email))
            {
                ModelState.AddModelError("", Umbraco.GetDictionaryValue("RegisterError"));
                return CurrentUmbracoPage();
            }

            _autorizationService.Register(model);

            Members.Login(model.Email, model.Password);

            return Redirect("/wall/");
        }

        public ActionResult SubmitLogout()
        {
            TempData.Clear();
            Session.Clear();
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}