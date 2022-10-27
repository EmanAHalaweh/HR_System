using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HR_System.Data;
using HR_System.Models;
using HR_System.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HR_System.Controllers
{
    public class EmployeeController : Controller
    {
        IDepartmentService DepartmentService;
        ICountryService CountryService;
        ICityService CityService;
        IEmployeeService EmployeeService;
        IConfiguration IConfig;

        public EmployeeController(IEmployeeService iEmployeeService,IDepartmentService iDepartmentService,ICityService iCityService, ICountryService iCountryService,IConfiguration _IConfig)
        {
             DepartmentService = iDepartmentService;
             CountryService = iCountryService;
             CityService = iCityService;
             EmployeeService = iEmployeeService;
             IConfig = _IConfig;
        }

        public IActionResult Index()
        {
            vmEmployee vmemp = new vmEmployee(); 
         
            vmemp.liDepartment = DepartmentService.loadAll();
            vmemp.liCountry = CountryService.loadAll();
            vmemp.liCity = CityService.loadAll();
            ViewData["isEdit"] = false;
            return View("Employee",vmemp);
        }

        public IActionResult Save(vmEmployee vmemp)
        {
              ViewData["isEdit"] = false;
            if (ModelState.IsValid == true)
            {
                string name = Guid.NewGuid().ToString()+"."+vmemp.employee.Image.FileName.Split('.')[1];
                string path = Path.Combine(Directory.GetCurrentDirectory(), IConfig["ImageUploadName"], name);
                vmemp.employee.Image.CopyTo(new FileStream(path, FileMode.Create));
                vmemp.employee.path = name;
                EmployeeService.insert(vmemp.employee);
            }

            
            vmemp.liDepartment = DepartmentService.loadAll();
            vmemp.liCountry = CountryService.loadAll();

            int countcode = vmemp.employee.countryId; 
            vmemp.liCity = CityService.loadAll(countcode);

            return View("Employee", vmemp);
        }



        public IActionResult empSearch()
        {
            List<Employee> li = new List<Employee>();
            return View("EmployeeList",li);
        }


        public IActionResult Search()
        {
            string name = Request.Form["txtName"];
            List<Employee> li = EmployeeService.loadAll(name);
           
            return View("EmployeeList", li);

        }

        public IActionResult Delete(int id)
        {
            List<Employee> li = new List<Employee>();
            EmployeeService.delete(id);
            li = EmployeeService.loadAll();
            return View("EmployeeList",li);

        }


        public IActionResult Edit(int id)
        {
            vmEmployee vmemp = new vmEmployee();
            vmemp.employee = EmployeeService.load(id);
            vmemp.liDepartment = DepartmentService.loadAll();
            vmemp.liCountry = CountryService.loadAll();
            
            vmemp.liCity = CityService.loadAll();
            ViewData["isEdit"] = true;
            return View("Employee", vmemp);
        }

        public IActionResult Update(vmEmployee vmemp)
        { 
             ViewData["isEdit"] = true;
            if (ModelState.IsValid == true)
            {
                if (vmemp.employee.Image != null)
                {
                    string name = Guid.NewGuid().ToString() + "." + vmemp.employee.Image.FileName.Split('.')[1];
                    string path = Path.Combine(Directory.GetCurrentDirectory(), IConfig["ImageUploadName"], name);
                    vmemp.employee.Image.CopyTo(new FileStream(path, FileMode.Create));
                    vmemp.employee.path = name;

                }
                EmployeeService.Update(vmemp.employee);
            }


            vmemp.liDepartment = DepartmentService.loadAll();
            vmemp.liCountry = CountryService.loadAll();

            int countcode = vmemp.employee.countryId;
            vmemp.liCity = CityService.loadAll(countcode);

            return View("Employee", vmemp);
        }

        public IActionResult deptemp(int dept_id)
        {

            List<Employee> li = EmployeeService.Ldept(dept_id);

            return View("EmployeeList", li);
            //return RedirectToAction("Index", "Employee", li);

        }

        public IActionResult loadCity(int countcode)
        {
            List<City> liCity = CityService.loadAll(countcode);
            return Json(liCity);
        }
    }
}
