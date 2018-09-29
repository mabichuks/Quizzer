using Microsoft.AspNet.Identity;
using Quizzer.Domain.Entities;
using Quizzer.Web.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quizzer.Web.Models
{
    public class RegisterViewModel
    {

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords Do not match")]
        public string ConfirmPassword { get; set; }

        public string ImageUrl { get; set; }

        [FileTypes("jpg,jpeg,png")]
        public HttpPostedFileBase ImageFile { get; set; }


    }
}