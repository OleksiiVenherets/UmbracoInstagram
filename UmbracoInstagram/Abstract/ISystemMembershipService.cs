namespace UmbracoInstagram.Abstract
{
    public interface ISystemMembershipService
    {
        bool ValidateUser(string username, string password);
    }
}
