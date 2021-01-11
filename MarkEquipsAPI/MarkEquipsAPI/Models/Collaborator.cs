﻿using MarkEquipsAPI.Models.Base;
using MarkEquipsAPI.Models.Enums;
using System.Collections.Generic;

namespace MarkEquipsAPI.Models
{
    public class Collaborator : BaseEntity
    {
        public string Name { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public LevelPermission Permission { get; set; }
        public List<Reserver> Reservations { get; set; }

    }
}
