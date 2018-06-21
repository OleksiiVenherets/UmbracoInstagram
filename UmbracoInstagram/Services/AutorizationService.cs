using Umbraco.Core.Services;
using UmbracoInstagram.Abstract;
using UmbracoInstagram.Models;
using Umbraco.Core.Models;

namespace UmbracoInstagram.Services
{
    public class AutorizationService : IAutorizationService
    {
        private readonly IMemberService _memberService;

        private readonly IUmbracoContextWrapper _umbWrapper;

        private readonly ISystemMembershipService _systemMembershipService;

        private readonly IFormAutentificationService _formAutentificationService;

        public AutorizationService(IMemberService memberService, IUmbracoContextWrapper umbWrapper, ISystemMembershipService systemMembershipService, IFormAutentificationService formAutentificationService)
        {
            _memberService = memberService;
            _umbWrapper = umbWrapper;
            _systemMembershipService = systemMembershipService;
            _formAutentificationService = formAutentificationService;
        }

        public bool IsEmailAddressExists(string emailAddress)
        {
            IMember member = _memberService.GetByEmail(emailAddress);
            return member != null && member.Email == emailAddress;
        }

        public bool IsValidate(LoginModel model)
        {
            return _systemMembershipService.ValidateUser(model.Username, model.Password);
        }

        public void Register(MemberModel model)
        {
            var member = _memberService.CreateMemberWithIdentity(model.Email, model.Email, model.Name, "Member");
            _memberService.Save(member);
            _memberService.SavePassword(member, model.Password);
            _memberService.AssignRole(member.Id, "new");
        }

        public bool Login(string login, string pwd)
        {
            var membershipHelper = _umbWrapper.GetMembershipHelper();
            return membershipHelper.Login(login, pwd);
        }

        public void Logout()
        {
            _formAutentificationService.Logout();
        }

        public void SetAuthCookie(string userName, bool isCreatePersistanceCookie)
        {
            _formAutentificationService.SetAuthCookie(userName, isCreatePersistanceCookie);
        }

        public string GetDictionaryValue(string name)
        {
            return _umbWrapper.GetDictionaryValue(name);
        }
    }
}