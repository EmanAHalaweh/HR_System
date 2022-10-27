using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HR_System.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string name { set; get; }
        public DateTime BDate { set; get; }

    }
}
