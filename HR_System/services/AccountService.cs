using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_System.Models;
using Microsoft.AspNetCore.Identity;

namespace HR_System.services
{
    public class AccountService : IAccountService
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        RoleManager<IdentityRole> roleManager;

        public AccountService(UserManager<ApplicationUser> _userManage,SignInManager<ApplicationUser>_signInManager,RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManage;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }

        public async Task<IdentityResult> CreateAccount(SignUpModel signUp)
        {
            ApplicationUser user = new ApplicationUser();
            user.UserName = signUp.Username;
            user.Email = signUp.Email;
            user.name = signUp.Name;
            user.BDate = signUp.BDate;
            user.PasswordHash = signUp.Password;

           var result=await userManager.CreateAsync(user,signUp.Password);
            return result;

        }

        public async Task<SignInResult> SignInUser(SignIn signin)
        {
            var result = await signInManager.PasswordSignInAsync(signin.Username, signin.Password, signin.Remmember, false);
            return result;
        }


        public async Task<IdentityResult> AddRole(RoleModel rolemodel)
        {
            IdentityRole role = new IdentityRole();
            role.Name = rolemodel.name;
            var result=await roleManager.CreateAsync(role);
            return result;
        }

        public List<ApplicationUser> GetUsers()
        {
            List<ApplicationUser> li = userManager.Users.ToList();
            return li;
        }



        public async Task<List<UserRole>> GetRoles(string UserId) {
            List<IdentityRole> liRole = roleManager.Roles.ToList();
            List<UserRole> liUserRole = new List<UserRole>();
            foreach (IdentityRole item in liRole)
            { UserRole uRole = new UserRole();
                uRole.RoleId = item.Id; 
                uRole.RoleName = item.Name;
                uRole.UserId = UserId;
                uRole.IsSelected=false;
                liUserRole.Add(uRole);
            }


            foreach(UserRole ur in liUserRole)
            {
                var user = await userManager.FindByIdAsync(ur.UserId);
                var roles = await userManager.GetRolesAsync(user);
               foreach(string r in roles)
                {
                    if(r==ur.RoleName)
                    {
                        ur.IsSelected = true;
                    }
                }

            }

            return liUserRole;
        }


        public async Task updateUserRole(List<UserRole>liuserRole){

            foreach(UserRole item in liuserRole)
            {
                var user = await userManager.FindByIdAsync(item.UserId);
                if (item.IsSelected == true)
                {
                    if (await userManager.IsInRoleAsync(user, item.RoleName) == false)
                    {
                        await userManager.AddToRoleAsync(user, item.RoleName);
                    }
                }
                else
                {
                    if (await userManager.IsInRoleAsync(user, item.RoleName) == true)
                    {
                        await userManager.RemoveFromRoleAsync(user, item.RoleName);
                    }
                }
               
            }
        }

        public async Task Logout()
        {
          
            await signInManager.SignOutAsync();
        }

    }
}
