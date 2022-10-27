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
    public class DepartmentController : Controller
    {
        IDepartmentService DepartmentService;
        public DepartmentController(IDepartmentService iDepartmentService)
        {
            DepartmentService = iDepartmentService;
        }


        public IActionResult Index()
        {
            ViewData["isEdit"] = false;
            return View("Department");
        }

        public IActionResult save(Department d)
        {
            ViewData["isEdit"] = false;
            DepartmentService.insert(d);
            return View("Department");
        }

        public IActionResult deptSearch()
        {
            List<Department> li = new List<Department>();
            return View("DepartmentList", li);
        }


        public IActionResult Search()
        {
            string name = Request.Form["txtName"];
            List<Department> li = DepartmentService.loadAll(name);
            return View("DepartmentList", li);
        }




        public IActionResult Delete(int id)
        {
            List<Department> li = new List<Department>();
            DepartmentService.delete(id);
            li = DepartmentService.loadAll();
            return View("DepartmentList", li);

        }

        public IActionResult Edit(int Id)
        {
            ViewData["isEdit"] = true;
            Department dept = DepartmentService.load(Id);
            return View("Department", dept);
        }


        public IActionResult update(Department dept)
        {
            ViewData["isEdit"] = true;
            if (ModelState.IsValid == true)
            {
                DepartmentService.Update(dept);
            }

            return View("Department", dept);
        }


    }
}

