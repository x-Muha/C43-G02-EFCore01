using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace EFCoreAssignment01.Models
{
    internal class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public DateOnly? HiringDate { get; set; } 

        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();


        // Works-On Relation
        [InverseProperty(nameof(Instructor.InstructorDepartment))]
        public virtual ICollection<Instructor> Instructors { get; set; }
                = new HashSet<Instructor>();

        // Manage Relation
        public int? ManagerId { get; set; }
        public virtual Instructor? Manager { get; set; }

    }
}
