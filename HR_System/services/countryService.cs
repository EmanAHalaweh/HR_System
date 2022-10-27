using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_System.Data;
using Microsoft.EntityFrameworkCore;

namespace HR_System.services
{
    public class countryService:ICountryService
    {
        HRContext context;
        public countryService(HRContext _context)
        {
             context = _context;
        }

        public List<Country> loadAll()
        {
            List<Country> li = context.countries.ToList();
            return (li);
        }


        public void insert(Country cnt)
        {
            context.countries.Add(cnt);
            context.SaveChanges();


        }
    }
}
