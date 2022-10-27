using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_System.Models
{
    public class UserRole
    {
        public string RoleName {set; get;}
        public string UserId { set; get; }
        public string RoleId { set; get; }
        public bool IsSelected { set; get; }

    }
}
