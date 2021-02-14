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


        public void SeedOther()
        {
            if (_context.Equipments.Any() ||
                _context.Schedules.Any())
            {
                return;
            }

            //, rs15, rs16,rs17,rs18,rs19,rs20,rs21,rs22,rs23, rs24,rs25,rs26,rs27,rs28,rs29,rs30,rs31,rs32

        }


    }
}
