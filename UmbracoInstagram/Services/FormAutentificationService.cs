using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using UmbracoInstagram.Abstract;

namespace UmbracoInstagram.Services
{
    public class FormAutentificationService : IFormAutentificationService
    {
        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        public void SetAuthCookie(string userName, bool isCreatePersistanceCookie)
        {
            FormsAuthentication.SetAuthCookie(userName, isCreatePersistanceCookie);

        }
    }
}