using Microsoft.EntityFrameworkCore;

namespace FTDNA_Coding_Task.Data
{
    public class FTDNAContext : DbContext
    {
        public DbSet<Sample> Samples { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=FTDNADb;Integrated Security=True");
        }
    }
}
