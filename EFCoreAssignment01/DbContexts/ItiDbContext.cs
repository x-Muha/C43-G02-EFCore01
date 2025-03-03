using EFCoreAssignment01.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment01.DbContexts
{
    internal class ItiDbContext : DbContext
    {
        public DbSet<Instructor>? Instructors { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Course_Inst>? course_Insts { get; set; }
        public DbSet<Department>? departments { get; set; }
        public DbSet<Student>? students { get; set; }
        public DbSet<Topic>? topic { get; set; }
        public DbSet<Stud_Course>? stud_Courses { get; set; }
        
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ("Server = .; Database = CompanyDb; Trusted_Connection = true; TrustServerCertificate = true");
        }

    }
}
        