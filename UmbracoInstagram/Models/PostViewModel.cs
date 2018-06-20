using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

namespace UmbracoInstagram.Models
{
    public class PostViewModel
    {
        public DateTime PostDate { get; set; }
        public IPublishedContent Image { get; set; }
        public string PostText { get; set; }
    }
}