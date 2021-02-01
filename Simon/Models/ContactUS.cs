using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Simon.Models
{
    public class ContactUS
    {
        [Required(ErrorMessage="Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter comment")]
        public string Message { get; set; }
        public string Address { get; set; }
    }
}