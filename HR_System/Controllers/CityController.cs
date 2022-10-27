using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_System.Data;
using HR_System.Models;
using HR_System.services;
using Microsoft.AspNetCore.Mvc;

namespace HR_System.Controllers
{
    public class CityController : Controller
    {
        ICountryService CountryService;
        ICityService CityService;
        public CityController(ICityService iCityService,ICountryService iCountryService)
        {
             CountryService = iCountryService;
             CityService = iCityService;

        }
        public IActionResult Index()
        {
            vmCountry vmcount = new vmCountry();

            vmcount.liCountry = CountryService.loadAll();
          //  vmcount.licity = CityService.loadAll();

            return View("NewCity",vmcount);
        }

        public IActionResult Save(vmCountry cnt)
        {
            CityService.insert(cnt.city);
   
            cnt.liCountry = CountryService.loadAll();
            cnt.licity = CityService.loadAll();

            return View("NewCity", cnt);
        }
    }
}


