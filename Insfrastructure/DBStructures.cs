using Microsoft.EntityFrameworkCore;
using TestProject.Entity;

namespace TestProject.Insfrastructure
{
    public class DBStructures :DbContext
    {
        public DbSet<Users> users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var SQLCons = "Host=localhost;Database=admin;Username=postgres;Password=Godofwar32";

            optionsBuilder.UseNpgsql(SQLCons);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
              .HasKey(e => e.userid);
           
        }

    }
}
