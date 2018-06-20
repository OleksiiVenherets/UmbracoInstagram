using Umbraco.Core.Services;
using UmbracoInstagram.Abstract;
using UmbracoInstagram.Models;
using Umbraco.Core.Models;
using System.Web.Security;

namespace UmbracoInstagram.Services
{
    public class AutorizationService : IAutorizationService
    {
        private readonly IMemberService _memberService;

        public AutorizationService(IMemberService memberService)
        {
            _memberService = memberService;
        }

        public bool IsEmailAddressExists(string emailAddress)
        {
            IMember member = _memberService.GetByEmail(emailAddress);
            return member != null && member.Email == emailAddress;
        }

        public bool IsValidate(LoginModel model)
        {
            return Membership.ValidateUser(model.Username, model.Password);
        }

        public void Register(MemberModel model)
        {
            var member = _memberService.CreateMemberWithIdentity(model.Email, model.Email, model.Name, "Member");
            _memberService.Save(member);
            _memberService.SavePassword(member, model.Password);
            _memberService.AssignRole(member.Id, "new");
        }
    }
}