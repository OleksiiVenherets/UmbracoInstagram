using System.Web.Security;
using UmbracoInstagram.Abstract;

namespace UmbracoInstagram.Services
{
    public class SystemMembershipService : ISystemMembershipService
    {
        public bool ValidateUser(string username, string password)
        {
            return Membership.ValidateUser(username, password);
        }

        public int GetMemberId()
        {
            var member = Membership.GetUser();

            return (int)Membership.GetUser(member.UserName).ProviderUserKey;
        }
    }
}