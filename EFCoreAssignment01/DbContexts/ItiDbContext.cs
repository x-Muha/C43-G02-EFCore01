using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using EFCoreAssignment01.ModelConfigurations;
using EFCoreAssignment01.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

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
                ("Server = .; Database = newItiDatabase; Trusted_Connection = true; TrustServerCertificate = true");
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                        .HasOne(S => S.StudentDepartment)
                        .WithMany(D => D.Students)
                        .HasForeignKey(S => S.DepartmentId)
                        .IsRequired(true);

            #region Many - Many Relationships

            #region Relationship Student - Course

                modelBuilder.Entity<Student>()
                            .HasMany(S => S.StudentCourses)
                            .WithOne(SC => SC.Student)
                            .HasForeignKey(SC => SC.Stud_ID)
                            .IsRequired(true);

                modelBuilder.Entity<Course>()
                            .HasMany(C => C.CourseStudents)
                            .WithOne(CS => CS.Course)
                            .HasForeignKey(CS => CS.Course_ID)
                            .IsRequired(false);
            #endregion

            #region Relationship Instructor - Course (Teach)

                modelBuilder.Entity<Instructor>()
                            .HasMany(I => I.InstructorCourses)
                            .WithOne(IS => IS.Instructor)
                            .HasForeignKey(IS => IS.Inst_Id)
                            .IsRequired(false);


                modelBuilder.Entity<Course>()
                            .HasMany(C => C.CourseInstructor)
                            .WithOne(IS => IS.Course)
                            .HasForeignKey(IS => IS.Course_Id)
                            .IsRequired(false);

                modelBuilder.Entity<Course_Inst>()
                            .HasKey(Key => new
                            {
                                Key.Course_Id,
                                Key.Inst_Id
                            });

            #endregion 
            #endregion


            // Works On Relation
            modelBuilder.Entity<Instructor>()
                        .HasOne(I => I.InstructorDepartment)
                        .WithMany(D => D.Instructors)
                        .HasForeignKey(I => I.DepartmentId)
                        .IsRequired(true)
                        .OnDelete(DeleteBehavior.NoAction);
            // Manage Relation is in config file of Employee
            modelBuilder.ApplyConfiguration(new DepartmentConfigurations());

            // if done from Instructor's Side
            //modelBuilder.Entity<Instructor>()
            //            .HasOne(I => I.ManagedDepartment)
            //            .WithOne(D => D.Manager)
            //            .HasForeignKey<Department>(D => D.ManagerId)
            //            .OnDelete(DeleteBehavior.NoAction)
            //            .IsRequired();
        }


    }
}
        