using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web.Mvc;
using UmbracoInstagram.Abstract;
using UmbracoInstagram.Models;

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
                    _autorizationService.SetAuthCookie(model.Username, false);
                    return RedirectToAction("ShowAllPosts", "Wall");
                    //UrlHelper myHelper = new UrlHelper(HttpContext.Request.RequestContext);
                    //if (myHelper.IsLocalUrl("/wall/"))
                    //{

                    //    return Redirect("wall");
                    //}
                    //else
                    //{
                    //    return Redirect("/login/");
                    //}
                }
                else
                {
                    ModelState.AddModelError("", _autorizationService.GetDictionaryValue("LoginError"));
                }
            }
            return CurrentUmbracoPage();
        }

        public ActionResult SignUp(MemberModel model)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();

            if (_autorizationService.IsEmailAddressExists(model.Email))
            {
                ModelState.AddModelError("", _autorizationService.GetDictionaryValue("RegisterError"));
                return CurrentUmbracoPage();
            }

            _autorizationService.Register(model);

            _autorizationService.Login(model.Email, model.Password);
            
            return Redirect("/wall/");
        }

        public ActionResult SubmitLogout()
        {
            TempData.Clear();
            Session.Clear();
            _autorizationService.Logout();

            return Redirect("/");
        }
    }
}