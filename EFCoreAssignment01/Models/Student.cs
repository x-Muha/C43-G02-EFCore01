using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace EFCoreAssignment01.Models
{
    internal class Student
    {
        //[Key]
        public int Id { get; set; }//By Convention
        [Column("FName", TypeName = "varchar(20)")]
        [MaxLength(100, ErrorMessage ="")]
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }

        [Range(12,34)]
        public int Age { get; set; }

        #region Relationship with Department
            // Configurations done inside DbContext - OnModelCreating
            // From Student - Side
            [ForeignKey(nameof(Department.Id))]
            public int DepartmentId { get; set; }
            public virtual Department StudentDepartment { get; set; } = null!;
        #endregion

        #region Relationship with Course / Stud_Course

        public virtual ICollection<Stud_Course> StudentCourses { get; set; } = new HashSet<Stud_Course>();
        #endregion



    }
}
