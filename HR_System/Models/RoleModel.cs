using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR_System.Models
{
    public class RoleModel
    {
        [Required]
        public string name { set; get; }
    }

}

