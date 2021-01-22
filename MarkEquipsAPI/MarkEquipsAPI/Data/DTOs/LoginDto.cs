using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Data.DTOs
{
    public class LoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }


    }
}
