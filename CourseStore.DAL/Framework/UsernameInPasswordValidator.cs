using CourseWebApi.Model.Auth.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWebApi.DAL.Framework
{
    public class UsernameInPasswordValidator : IPasswordValidator<ApplicationUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<ApplicationUser> manager, ApplicationUser user, string password)
        {
            if (password.Contains(user.UserName, StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "UsernameInPassword",
                    Description = "you can not use your username in your password"
                }));
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }  
}
