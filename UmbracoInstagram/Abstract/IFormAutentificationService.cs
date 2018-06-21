using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbracoInstagram.Abstract
{
    public interface IFormAutentificationService
    {
        void SetAuthCookie(string userName, bool isCreatePersistanceCookie);
        void Logout();
    }
}
