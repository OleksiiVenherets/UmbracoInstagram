using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Web.Mvc;
using UmbracoInstagram.Models;

namespace UmbracoInstagram.Controllers
{
    public class MemberController : SurfaceController
    {
        public ActionResult RenderLogin()
        {
            return PartialView("_Login", new LoginModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitLogin(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if ( Membership.ValidateUser(model.Username, model.Password))
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
                    ModelState.AddModelError("", "The username or password provided is incorrect.");
                }
            }
            return CurrentUmbracoPage();
        }

        public ActionResult SignUp(MemberModel model)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();

            var memberService = Services.MemberService;
            if (memberService.GetByEmail(model.Email) != null)
            {
                ModelState.AddModelError("", "Member already exists");
                return CurrentUmbracoPage();
            }
            if (model.Password!= model.ConfirmPassword)
            {
                ModelState.AddModelError("", "Passwords did not match");
                return CurrentUmbracoPage();
            }
            var member = memberService.CreateMemberWithIdentity(model.Email, model.Email, model.Name, "Member");

            memberService.Save(member);

            memberService.SavePassword(member, model.Password);

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