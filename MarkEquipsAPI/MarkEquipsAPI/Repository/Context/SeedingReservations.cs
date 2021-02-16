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
            if (_userManager.FindByNameAsync("allison").Result == null)
            {
                User user = new User()
                {
                    UserName = "allison",
                    FullName = "Allison Sousa Bahls"
                };
                IdentityResult result = _userManager.CreateAsync
                (user, "pqzmal123").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
            if (_userManager.FindByNameAsync("amanda").Result == null)
            {
                User user = new User() 
                { 
                    UserName = "amanda",
                    FullName = "Amanda Souza"
                    };
                IdentityResult result = _userManager.CreateAsync
                (user, "admin123").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Collaborator").Wait();
                }
            }
            if (_userManager.FindByNameAsync("elizangela").Result == null)
            {
                User user = new User()
                {
                    UserName = "elizangela",
                    FullName = "Elizangela Martins"
                };
                IdentityResult result = _userManager.CreateAsync
                (user, "pqzmal123").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Collaborator").Wait();
                }
            }
            if (_userManager.FindByNameAsync("eline").Result == null)
            {
                User user = new User()
                {
                    UserName = "eline",
                    FullName = "Eline Alburquerque"
                };
                IdentityResult result = _userManager.CreateAsync
                (user, "admin").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Collaborator").Wait();
                }
            }
            if (_userManager.FindByNameAsync("priscila").Result == null)
            {
                User user = new User()
                {
                    UserName = "priscila",
                    FullName = "Priscila Fonseca"
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

            Equipment e1 = new Equipment() { Name = "Projetor Dell", Description = "Projetor com entrada HDMI", Number = 3232 };
            Equipment e2 = new Equipment() { Name = "Projetor LG", Description = "Projetor com entrada VGA", Number = 2321};
            Equipment e3 = new Equipment() { Name = "Laboratório de Informática", Description = "Lab com 30 computadores", Number = 5453};
            Equipment e4 = new Equipment() { Name = "Laboratório de Solos e Nutrição", Description = "Para curso de Zootecnia e Agronomia", Number = 8977 };
            Equipment e5 = new Equipment() { Name = "Caixa de Som Samsumg", Description = "Entrada P2 e USB", Number = 3234};
            Equipment e6 = new Equipment() { Name = "Projetor Brother", Description = "Projetor com entrada HDMI", Number = 2376 };
            Equipment e7 = new Equipment() { Name = "Notebook Dell", Description = "Notebook 2gb RAM entreda VGA e HDMI", Number = 6776};
            Equipment e8 = new Equipment() { Name = "Notebook LG", Description = "Projetor com entrada HDMI", Number = 6765};
            Equipment e9 = new Equipment() { Name = "Caixa de Som Retry", Description = "Entrada P2 e USB", Number = 5675};
            Equipment e10 = new Equipment() { Name = "Projetor Dell 2V", Description = "Projetor com entrada VGA", Number = 4554};

            Schedule m1 = new Schedule() { Id = 1, Period = "Manhã", HourInitial = new TimeSpan(8, 0, 0), HourFinal = new TimeSpan(9, 0, 0) };
            Schedule m2 = new Schedule() { Id = 2, Period = "Manhã", HourInitial = new TimeSpan(9, 0, 0), HourFinal = new TimeSpan(10, 0, 0) };
            Schedule m3 = new Schedule() { Id = 3, Period = "Manhã", HourInitial = new TimeSpan(10, 0, 0), HourFinal = new TimeSpan(11, 0, 0) };
            Schedule t1 = new Schedule() { Id = 4, Period = "Tarde", HourInitial = new TimeSpan(14, 0, 0), HourFinal = new TimeSpan(15, 0, 0) };
            Schedule t2 = new Schedule() { Id = 5, Period = "Tarde", HourInitial = new TimeSpan(15, 0, 0), HourFinal = new TimeSpan(16, 0, 0) };
            Schedule t3 = new Schedule() { Id = 6, Period = "Tarde", HourInitial = new TimeSpan(16, 0, 0), HourFinal = new TimeSpan(17, 0, 0) };
            Schedule n1 = new Schedule() { Id = 7, Period = "Noite", HourInitial = new TimeSpan(18, 0, 0), HourFinal = new TimeSpan(19, 0, 0) };
            Schedule n2 = new Schedule() { Id = 8, Period = "Noite", HourInitial = new TimeSpan(19, 0, 0), HourFinal = new TimeSpan(20, 0, 0) };
            Schedule n3 = new Schedule() { Id = 9, Period = "Noite", HourInitial = new TimeSpan(20, 0, 0), HourFinal = new TimeSpan(21, 0, 0) };

            Reserver r1 = new Reserver() { Id = 1, Date = new DateTime(2021, 1, 10), UserId = 1, Equipment = e1, Schedule = m1, Status = ReserveStatus.RESERVED };
            Reserver r2 = new Reserver() { Id = 2, Date = new DateTime(2021, 2, 12), UserId = 2, Equipment = e9, Schedule = n2, Status = ReserveStatus.RESERVED };
            Reserver r3 = new Reserver() { Id = 3, Date = new DateTime(2021, 1, 20), UserId = 2, Equipment = e2, Schedule = n3, Status = ReserveStatus.RESERVED };
            Reserver r4 = new Reserver() { Id = 4, Date = new DateTime(2021, 3, 15), UserId = 4, Equipment = e4, Schedule = t1, Status = ReserveStatus.RESERVED };
            Reserver r5 = new Reserver() { Id = 5, Date = new DateTime(2021, 4, 12), UserId = 3, Equipment = e7, Schedule = t2, Status = ReserveStatus.RESERVED };
            Reserver r6 = new Reserver() { Id = 6, Date = new DateTime(2021, 1, 17), UserId = 2, Equipment = e10, Schedule = t3, Status = ReserveStatus.RESERVED };
            Reserver r7 = new Reserver() { Id = 7, Date = new DateTime(2021, 1, 17), UserId = 3, Equipment = e10, Schedule = t2, Status = ReserveStatus.RESERVED };
            Reserver r8 = new Reserver() { Id = 8, Date = new DateTime(2021, 1, 10), UserId = 4, Equipment = e3, Schedule = m3, Status = ReserveStatus.RESERVED };
            Reserver r9 = new Reserver() { Id = 9, Date = new DateTime(2021, 1, 16), UserId = 1, Equipment = e4, Schedule = n2, Status = ReserveStatus.RESERVED };
            Reserver r10 = new Reserver() { Id = 10, Date = new DateTime(2021, 1, 18), UserId = 3, Equipment = e5, Schedule = m1, Status = ReserveStatus.RESERVED };
            Reserver r11 = new Reserver() { Id = 11, Date = new DateTime(2021, 1, 30), UserId = 2, Equipment = e6, Schedule = m2, Status = ReserveStatus.RESERVED };
            Reserver r12 = new Reserver() { Id = 12, Date = new DateTime(2021, 1, 28), UserId = 3, Equipment = e7, Schedule = n2, Status = ReserveStatus.RESERVED };
            Reserver r13 = new Reserver() { Id = 13, Date = new DateTime(2021, 1, 21), UserId = 4, Equipment = e8, Schedule = n2, Status = ReserveStatus.RESERVED };
            Reserver r14 = new Reserver() { Id = 14, Date = new DateTime(2021, 1, 21), UserId = 4, Equipment = e9, Schedule = t2, Status = ReserveStatus.RESERVED };

            _context.Equipments.AddRange(e1, e2, e3, e4, e5, e6, e7, e8, e9, e10);
            _context.Schedules.AddRange(m1, m2, m3, t1, t2, t3, n1, n2, n3);
            _context.Reservations.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14);
            _context.SaveChanges();

            //, rs15, rs16,rs17,rs18,rs19,rs20,rs21,rs22,rs23, rs24,rs25,rs26,rs27,rs28,rs29,rs30,rs31,rs32

        }


    }
}
