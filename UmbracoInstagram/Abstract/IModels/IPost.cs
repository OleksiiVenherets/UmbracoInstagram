using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Umbraco.Core.Models;

namespace UmbracoInstagram.Abstract.IModels
{
    public interface IPost
    {
        DateTime PostDate { get; set; }
        HttpPostedFileBase PostImage { get; set; }
        string PostText { get; set; }
        int ParentId { get; set; }
    }
}
