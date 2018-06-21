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
    }
}