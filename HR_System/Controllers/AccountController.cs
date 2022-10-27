using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_System.Models;
using HR_System.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HR_System.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
        }
        public IActionResult Index()
        {
            return View("CreateAccount");
        }

        public IActionResult SignIn(SignIn signin)
        {
            return View("SignIn");
        }


        public IActionResult NewRole()
        {
            return View("NewRole");
        }

        public async Task<IActionResult> AddRole(RoleModel rolemodel)
        {
            var result=await accountService.AddRole(rolemodel);
            return View("NewRole");
        }




        public async Task<IActionResult> CreateAccount(SignUpModel signUp)
        {
            var result= await accountService.CreateAccount(signUp);
            ViewData["message"] = result;
            return View("CreateAccount");
        }



        public async Task<IActionResult> CheckPassword(SignIn signin)
        {
            var result = await accountService.SignInUser(signin);
            if (result.Succeeded == true)
            {
                //return View("SignIn");
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ViewData["message"] = "Invalid User Name or Password";
                return View("SignIn");
            }
        }

        [Authorize(Roles = "Admin")]
        public IActionResult GetUsers()
        {
            List<ApplicationUser> li = accountService.GetUsers();
            return View("UserList",li);
        }
        
           
        public async Task<IActionResult> UserRole(string UserId,string name)
        {
            ViewData["Name"] = name;
           List<UserRole> li= await accountService.GetRoles(UserId);

            return View(li);
        }

        public async Task<IActionResult> UpdateRole(List<UserRole>liuserRole)
        {
         
            await accountService.updateUserRole(liuserRole);
            List<UserRole> liuserRoles = await accountService.GetRoles(liuserRole[0].UserId);
            return View("UserRole", liuserRoles);
        }



        public IActionResult AccessDenied()
        {
            
            return View();
        }

        public IActionResult Logout()
        {
            accountService.Logout();
            return View("SignIn");
        }
    }
}
