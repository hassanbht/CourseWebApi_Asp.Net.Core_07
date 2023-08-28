using CourseWebApi.Model.Auth.Entities;
using Microsoft.AspNetCore.Identity;

namespace CourseWebApi.DAL.Framework
{
    public class UsernameInPasswordValidatorBase
    {
        public async Task<IdentityResult> ValidateAsync(UserManager<ApplicationUser> manager, ApplicationUser user, string password)
        {
            if (password.Contains(user.UserName!, StringComparison.OrdinalIgnoreCase))
            {
                return await Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "UsernameInPassword",
                    Description = "you can not use your username in your password"
                }));
            }
            return await Task.FromResult(IdentityResult.Success);
        }
    }
}