using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreAssignment01.Models
{
    internal class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Ins_Id { get; set; }
        public DateOnly HiringDate { get; set; }

        public ICollection<Student> Students { get; set; } = new HashSet<Student>();


        // Works-On Relation
        [InverseProperty(nameof(Instructor.InstructorDepartment))]
        public ICollection<Instructor> Instructors { get; set; }
                = new HashSet<Instructor>();

        // Manage Relation
        public int ManagerId { get; set; }
        public Instructor Manager { get; set; } = null!;

    }
}
