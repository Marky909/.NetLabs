using JwtAuthDotNet10.Entities;
using Microsoft.EntityFrameworkCore;
namespace JwtAuthDotNet10.Data
{
    //public class UserDbContext:DbContext
    //{
    //public UserDbContext(DbContextOptions<UserDbContext> options):base(options)
    //{ boring old method of DI

    //}
    public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options) {

        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();
        }

    }

    

}

