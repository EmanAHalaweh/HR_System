using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_System.Data;

namespace HR_System.services
{
   public interface ICountryService
    {
        public List<Country> loadAll();
        public void insert(Country cnt);
    }
}