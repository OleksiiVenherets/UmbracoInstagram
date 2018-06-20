using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UmbracoInstagram.Models
{
    public class MemberModel
    {
        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "The lenght of psassword must be 10 or more symbols")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required]
        [Compare("Password", ErrorMessage = "Passwords did not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}




