using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace EFCoreAssignment01.Models
{

    internal class Course
    {
        [Key]
        public int Id { get; set; }
        public string Duration { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; } //By Convention allow null

        public virtual Topic CourseTopic { get; set; }

        // Relationship with Student / Stud_Course
        public virtual ICollection<Stud_Course> CourseStudents { get; set; } = new HashSet<Stud_Course>();
        
        // Relationship with Instructor / Course_Inst
        public virtual ICollection<Course_Inst>? CourseInstructor { get; set; } = new HashSet<Course_Inst>();



    }
}
