﻿using CourseWebApi.BLL.Infra;
using CourseWebApi.Model.Auth.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWebApi.BLL.Auth
{
    public class IdentityService : IIdentity
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityService(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }

        public async Task<ApplicationUser?> FindByNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }
              

        public async Task<IdentityResult> UpdateAsync(ApplicationUser user)
        {
           return await _userManager.UpdateAsync(user);
        }

        public async  Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public  async Task<IList<string>> GetRolesAsync(ApplicationUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<IList<ApplicationUser>> GetAllUserAsync()
        {
            return await _userManager.Users.ToListAsync();
        }
    }
}
