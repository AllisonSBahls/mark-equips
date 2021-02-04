using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Data.DTOs
{
    public class LoginDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
