using MarkEquipsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using MarkEquipsAPI.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Repository.Context
{
    public class SeedingReservations
    {
        private readonly MarkEquipsContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        public SeedingReservations(MarkEquipsContext context, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("Administrator").Result)
            {
                Role role = new Role() {
                   Name = "Administrator"
                 };
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("Collaborator").Result)
            {
                Role role = new Role()
                {
                    Name = "Collaborator"
                };
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }           
        }

        public void SeedUsers()
        {
            if (_userManager.FindByNameAsync("administrador").Result == null)
            {
                User user = new User()
                {
                    UserName = "administrador",
                    FullName = "Allison Sousa Bahls"
                };
                IdentityResult result = _userManager.CreateAsync
                (user, "pqzmal123").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }
    }
}
