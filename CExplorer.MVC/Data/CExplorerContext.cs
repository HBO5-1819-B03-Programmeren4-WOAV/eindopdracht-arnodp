using CExplorer.MVC.Entities;
using Microsoft.EntityFrameworkCore;

namespace CExplorer.MVC.Data
{
    public class CExplorerContext : DbContext
    {
        public CExplorerContext(DbContextOptions<CExplorerContext> options) : base(options)
        {}
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users").HasData(
                new User { Email = "Admin@User.com", Password = "Root", IsAdmin = true, Id = 1 }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
