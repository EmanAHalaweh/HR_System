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
    public class CountryController : Controller
    {
        ICountryService CountryService;
        public CountryController(ICountryService iCountryService)
        {
            CountryService = iCountryService;
        }

        public IActionResult Index()
        {
            vmCountry vmcount = new vmCountry();
            vmcount.liCountry = CountryService.loadAll();
            return View("NewCountry", vmcount);
        }



        public IActionResult Save(vmCountry cnt)
        {
            CountryService.insert(cnt.count);
            cnt.liCountry = CountryService.loadAll();
            return View("NewCountry",cnt);
        }
    }
}
