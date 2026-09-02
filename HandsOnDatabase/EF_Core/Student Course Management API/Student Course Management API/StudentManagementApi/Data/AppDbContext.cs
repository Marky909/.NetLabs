using Microsoft.EntityFrameworkCore;
using StudentManagementApi.Models;
namespace StudentManagementApi.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .Property(s => s.Name) //this is fluent api i am targetting only the name property validation
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Department>().HasData(
                new Department {Id=1,Name="Computer Science", },
                new Department { Id = 2, Name = "Information Technology"}
                );

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1,Name = "Database Managemnet System",Credits=3},
                new Course { Id = 2,Name = "Web Technology",Credits=3}
                );
        }
    }
}
