using MarkEquipsAPI.Hypermedia;
using MarkEquipsAPI.Hypermedia.Abstract;
using MarkEquipsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Data.DTOs
{
    public class UserDto : ISupportsHyperMedia
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public List<string> Roles { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }

    public class UserReserverDto
    {
        public string FullName { get; set; }
    }
}
