using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorLocal.Data.Models;
using BlazorLocal.Data.ModelsDB;
using BlazorLocal.PageModels;
using BlazorLocal.Pages.AspNetUsers;
using Microsoft.AspNetCore.Identity;

namespace BlazorLocal.Data.Services
{
    public class AspNetUsersService
    {
        private readonly EFRepository<IdentityUser> repo;
        private readonly UserManager<IdentityUser> mUserManager;
        private readonly RoleManager<IdentityRole> mRoleManager;

        public AspNetUsersService(ApplicationDbContext _context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            repo = new EFRepository<IdentityUser>(_context);
            mRoleManager = roleManager;
            mUserManager = userManager;
        }
        public async Task<List<AspNetUsersItemViewModel>> GetAll()
        {
            var result = repo.Get().Select(r => Convert(r)).ToList();

            foreach(var user in result)
            {
                var roles = await mUserManager.GetRolesAsync(user.Item);
                var roleName = roles?.FirstOrDefault();

                if (!string.IsNullOrEmpty(roleName))
                {
                    var role = await mRoleManager.FindByNameAsync(roleName);                   
                    user.RoleName = role.Name;
                }
            }

            return await Task.FromResult(result);
        }


        private AspNetUsersItemViewModel Convert(IdentityUser r)
        { 
            var item = new AspNetUsersItemViewModel(r);          
            return item;
        }

        public void Delete(AspNetUsersItemViewModel item)
        {
            var x = repo.FindById(item.AspNetUsersId);
            repo.Remove(x);
        }

        public async Task Update(AspNetUsersItemViewModel item)
        {
            item.NormalizedEmail = item.Email.ToUpper();
            item.NormalizedUserName = item.UserName.ToUpper();

            await mUserManager.UpdateAsync(item.Item);

            var roles = await mUserManager.GetRolesAsync(item.Item);

            if (!roles.Contains(item.RoleName))
            {
                await mUserManager.RemoveFromRolesAsync(item.Item, roles);
                await mUserManager.AddToRoleAsync(item.Item, item.RoleName);
            }
        }

        public async Task<string> UpdatePassword(AspNetUsersItemViewModel item, string oldPassword, string newPassword)
        {
            var result = await mUserManager.ChangePasswordAsync(item.Item, oldPassword, newPassword);

            return result?.Errors?.FirstOrDefault()?.Description;
        }

        public async Task<AspNetUsersItemViewModel> Create(AspNetUsersItemViewModel item)
        {
            item.NormalizedEmail = item.Email.ToUpper();
            item.UserName = item.Email;
            item.NormalizedUserName = item.Email.ToUpper();
            item.PasswordHash = mUserManager.PasswordHasher.HashPassword(item.Item, item.Password);

            var newItem = repo.Create(item.Item);

            return await Task.FromResult(Convert(newItem));
        }

        public async Task<List<IdentityRole>> GetAllRoles()
        {
            return mRoleManager.Roles.ToList();
        }
    }
}
