using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HR_System.Data
{
    [Table("Department")]
    public class Department
    {
        public int Id { set; get; }
       [Required]
        public string name { set; get; }
        public string Description { set; get; }

        public List<Employee> empli { set; get; }

    }
}
