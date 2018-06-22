using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoInstagram.Models
{
    public class GetPostsViewModel
    {
        public DateTime PostDate { get; set; }
        public string PostImage { get; set; }
        public string PostText { get; set; }
        public int CreatorId { get; set; }
    }
}