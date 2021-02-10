using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheCakeFactory.Models.ViewModels
{
    public class LoginModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [UIHint("password")] //masks the password
        public string Password { get; set; }
        public string ReturnUrl { get; set; } = "/"; //root url

    }
}
