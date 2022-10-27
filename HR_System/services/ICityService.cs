using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_System.Data;

namespace HR_System.services
{
   public interface ICityService
    {
        public List<City> loadAll();
        public List<City> loadAll(int countcode);
        public void insert(City cty);

        }
    }
