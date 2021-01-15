using System.Collections.Generic;

namespace MarkEquipsAPI.Data.DTO
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
