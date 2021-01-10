using Microsoft.EntityFrameworkCore;

namespace MarkEquipsAPI.Models.Context
{
    public class MarkEquipsContext : DbContext
    {
        public MarkEquipsContext(){}

        public MarkEquipsContext(DbContextOptions<MarkEquipsContext> options) : base(options){}

        public DbSet<Equipment> Equipments { get; set; }
    }
}
