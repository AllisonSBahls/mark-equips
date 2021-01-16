using MarkEquipsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MarkEquipsAPI.Repository.Context
{
    public class MarkEquipsContext : DbContext
    {
        public MarkEquipsContext(){}

        public MarkEquipsContext(DbContextOptions<MarkEquipsContext> options) : base(options){}

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Collaborator> Collaborators { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Reserver> Reservations { get; set; }

    
    }
}
