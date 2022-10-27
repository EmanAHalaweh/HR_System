using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR_System.Models
{
    public class SignUpModel
    {
      
        [Required]
        public string Name { set; get; }
        [Required]
        public DateTime BDate { set; get; }
        [Required]
        public string Email { set; get; }
        [Required]
        public string Username { set; get; }
        [Required]
        [Compare("ConfirmPassword")]
        public string Password { set; get; }
        public string ConfirmPassword { set; get; }
    }

}

