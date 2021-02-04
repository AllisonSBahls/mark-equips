using MarkEquipsAPI.Models.Base;
using System.Collections.Generic;

namespace MarkEquipsAPI.Models
{
    public class Equipment : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public List<Reserver> Reservations { get; set; }
    }
}
