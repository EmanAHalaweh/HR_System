using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR_System.Models
{
    public class SignIn
    {
        [Required]
        public string Username { set; get; }
        [Required]
        public string Password { set; get; }
        public bool Remmember { set; get; }

    }
}
