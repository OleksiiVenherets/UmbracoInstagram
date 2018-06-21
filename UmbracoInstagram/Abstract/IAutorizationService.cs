using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Services;
using UmbracoInstagram.Models;

namespace UmbracoInstagram.Abstract
{
    public interface IAutorizationService
    {
        void Register(MemberModel model);
        bool IsValidate(LoginModel model);
        bool IsEmailAddressExists(string emailAddress);

        bool Login(string login, string pwd);
    }
}
