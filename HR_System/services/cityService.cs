using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_System.Data;
using Microsoft.Extensions.Configuration;

namespace HR_System.services
{
    public class cityService:ICityService
    {

        HRContext context;
        public cityService(HRContext _context)
        {
             context = _context;
        }


        public List<City> loadAll()
        {
            List<City> li = context.cities.ToList();
            return (li);

        }

        public List<City> loadAll(int countcode)
        {
            List<City> li = context.cities.Where(c => c.code == countcode).ToList();
            return (li);

        }

        public void insert( City cty)
        {
            context.cities.Add(cty);
            context.SaveChanges();

        }
    }
}
