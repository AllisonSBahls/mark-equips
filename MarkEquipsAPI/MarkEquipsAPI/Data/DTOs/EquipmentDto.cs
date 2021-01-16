using System.Collections.Generic;

namespace MarkEquipsAPI.Data.DTOs
{
    public class EquipmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public string ImageURL { get; set; }
        public List<ReserverDto> Reservations { get; set; }

    }
}
