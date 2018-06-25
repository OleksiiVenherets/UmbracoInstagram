using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using UmbracoInstagram.Abstract.IModels;

namespace UmbracoInstagram.Models
{
    public class PostViewModel : IPost
    {
        public DateTime PostDate { get; set; }
        public string PostImage { get; set; }
        public string PostText { get; set; }
        public int ParentId { get; set; }
        public int MemberId { get; set; }
    }
}