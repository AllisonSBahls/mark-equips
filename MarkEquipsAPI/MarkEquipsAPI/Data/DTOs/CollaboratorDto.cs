using MarkEquipsAPI.Hypermedia;
using MarkEquipsAPI.Hypermedia.Abstract;
using System.Collections.Generic;

namespace MarkEquipsAPI.Data.DTOs
{
    public class CollaboratorDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public int Permission { get; set; }

    }
}
