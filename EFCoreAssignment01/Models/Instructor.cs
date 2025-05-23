using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace EFCoreAssignment01.Models
{
    internal class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Bonus { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public int HourRate { get; set; }



        // Works On Relation Many - One
        [ForeignKey(nameof(InstructorDepartment))]
        public int? DepartmentId { get; set; }
        [InverseProperty(nameof(Department.Instructors))]
        public virtual Department? InstructorDepartment { get; set; }

        // Manage Relation one - one
        public virtual Department? ManagedDepartment { get; set; }

        // Teach Relation Many - Many
        public virtual ICollection<Course_Inst>? InstructorCourses { get; set; } = new HashSet<Course_Inst>();

    }
}
