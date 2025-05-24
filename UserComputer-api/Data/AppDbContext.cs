using Microsoft.EntityFrameworkCore;
using UserComputer_api.Computers.Models;
using UserComputer_api.Users.Models;

namespace UserComputer_api.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Computer> Computers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u=>u.Computers)
                .WithOne(c=>c.Users)
                .HasForeignKey(c=>c.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
