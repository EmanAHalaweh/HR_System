using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_System.Models;
using Microsoft.AspNetCore.Identity;

namespace HR_System.services
{
    public interface IAccountService
    {
        Task<IdentityResult> CreateAccount(SignUpModel signUp);
        Task<SignInResult> SignInUser(SignIn signin);
        Task<IdentityResult> AddRole(RoleModel rolemodel);
        List<ApplicationUser> GetUsers();
      
        Task updateUserRole(List<UserRole> liuserRole);


        Task<List<UserRole>> GetRoles(string UserId);
        Task Logout();
} }
