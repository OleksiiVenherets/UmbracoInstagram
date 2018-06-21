using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace UmbracoInstagram.Abstract.IModels
{
    public interface IPost
    {
        DateTime PostDate { get; }
        IPublishedContent PostImage { get;  }
        string PostText { get; }
    }
}
