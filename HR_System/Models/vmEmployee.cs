using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_System.Data;

namespace HR_System.Models
{
    public class vmEmployee
    {
        public Employee employee { set; get; }
        public List<Department> liDepartment { set; get; }
        public List<Country> liCountry { set; get; }
        public List<City> liCity { set; get; }



    }
}
