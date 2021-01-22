using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Models
{
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; }
        public List<UserRole> UserRoles { get; set; }
        public List<Reserver> Reservations { get; set; }

    }
}
