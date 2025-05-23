using System.Xml;
using EFCoreAssignment01.DbContexts;
using EFCoreAssignment01.Models;
using EFCoreAssignment01.Repositories;
using EFCoreAssignment01.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;

namespace EFCoreAssignment01
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using ItiDbContext dbContext = new ItiDbContext();

            #region CRUD Operations Using Repo That act as Both Repo and Service

            //IGenericRepository<Department> Repo = new GenericRepository<Department>(dbContext);

            //// Insert
            //Department dept = new Department()
            //{
            //    Name = "Assistants"
            //};
            //await Repo.Insert(dept);

            //// Select

            //IEnumerable<Department> Departments = await Repo.Select();
            //foreach (var dep in Departments)
            //    Console.WriteLine($"Dept Id: {dep.Id}, Dept Name: {dep.Name}");

            //// Update
            //Department dept2 = new() { Name = "UpdatedSales", Id = 71 };
            //await Repo.Update(dept2, 71);

            //// Delete
            //bool Result = await Repo.Delete(71);
            //Console.WriteLine(Result); 
            #endregion

            #region Loading
            // Without loading can't access manager attributes (name)
            //var dep = dbContext.Set<Department>().FirstOrDefault(D => D.Name == "IT");
            //if (dep != null) Console.WriteLine(dep.Manager.Name); // INVALID
            #region Eager Loading
            #region Ex01 Loading Manager of It Department
            //// To access manager name of IT department
            //var Dep = dbContext.Set<Department>().Include(D => D.Manager)
            //                   .FirstOrDefault(D => D.Name == "IT");
            //if (Dep != null) Console.WriteLine
            //        ($"Dep:{Dep.Name},{Dep.Id}, Manager:{Dep.Manager?.Name ?? "No Manager"}"); 
            #endregion

            #region Thats Selcet with join but no LOADING => Only for viewing
            //var Dep2 = dbContext.Set<Department>().Where(d => d.Id == 51)
            //    .Select(d => new
            //    {
            //        DepartmentName = d.Name,
            //        Instructors = d.Instructors.Where(i => i.Salary > 7000).ToList()
            //    }).FirstOrDefault();
            //if (Dep2 != null)
            ////foreach (var i in Dep2.Instructors)
            ////        Console.WriteLine(i.Name+i.Salary);
            //{
            //    Console.WriteLine(Dep2);
            //    Console.WriteLine(Dep2.DepartmentName);
            //    foreach(var i in Dep2.Instructors) Console.WriteLine(i.Name+i.Salary);
            //} 
            #endregion

            #region Ex02 Loading Instructors work in Dept It then filter by salary
            //var Dep2 = dbContext.Set<Department>().Include(D => D.Instructors)
            //        .FirstOrDefault(D => D.Name == "IT");
            //// that loaded IEnumerable list of Instructors work in IT Department
            //var InstructorsWithSalaryAbove7000 = from i in Dep2.Instructors
            //                                     where i.Salary > 7000
            //                                     select new
            //                                     {
            //                                         InstructorName = i.Name,
            //                                         Salary = i.Salary,
            //                                     };
            //foreach (var i in InstructorsWithSalaryAbove7000)
            //    Console.WriteLine(i);

            #endregion

            // Multi Relationship using Include - ThenInclude
            #region Ex03 Getting Instructors the work on the department that the student is assigned in Complex (MultiRelationship)
            //var Student = dbContext.Set<Student>().Include(S=>S.StudentDepartment)
            //    .ThenInclude(D=>D.Instructors).FirstOrDefault(S=>S.FName=="Hossam");

            //if (Student != null)
            //{
            //    Console.WriteLine($"Student Name: {Student.FName}");
            //    Console.WriteLine($"----------Department Id: {Student.DepartmentId}");
            //    Console.WriteLine($"----------Department Name: {Student.StudentDepartment.Name}");
            //    Console.WriteLine($"----------Department's Instructors: ");
            //    foreach(var i in Student.StudentDepartment.Instructors)
            //        Console.WriteLine($"----------------------{i.Name} - {i.Id}");
            //}

            #endregion
            #endregion


            #region Lazy Loading (Automatic Loading)

            //var dep = dbContext.departments?.FirstOrDefault(D => D.Name == "IT");
            //if (dep != null)
            //{
            //    Console.WriteLine($"Department: {dep.Name}\nHas Instructors:");
            //    foreach(var i in dep.Instructors) Console.WriteLine($"--{i.Name}");
            //}

            //var student = dbContext.students?.FirstOrDefault(S => S.FName =="Hossam");
            //if (student != null)
            //{
            //    Console.WriteLine($"Hossam's Department's Manager:" +
            //        student.StudentDepartment?.Manager?.Name?? "No Manager or Department");
            //}
            #endregion
            #endregion
        }
    }
}
