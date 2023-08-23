using CourseWebApi.Model.Auth.Entities;
using Microsoft.AspNetCore.Identity;

namespace CourseWebApi.Model.Services
{
    public interface IIdentity
    {
        Task<ApplicationUser?> FindByNameAsync(string userName);
        Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password);
        Task<IdentityResult> UpdateAsync(ApplicationUser user);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        Task<IList<string>> GetRolesAsync(ApplicationUser user);
        Task<IList<ApplicationUser>> GetAllUserAsync();
    }
}
