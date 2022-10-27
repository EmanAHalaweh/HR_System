using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_System.Data;

namespace HR_System.Models
{
    public class vmCountry
    {
        public Country count { set; get; }
        public List<Country> liCountry { set; get; }
        public City city { set; get; }
        public List<City> licity { set; get; }

    }

}

