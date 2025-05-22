using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreAssignment01.Models
{
    internal class Course_Inst
    {
        //Primary key done by Fluent Api
        public int Inst_Id { get; set; }
        public int Course_Id { get; set; }
        public string Evaluate {  get; set; }

        public Course Course { get; set; } 
        public Instructor Instructor { get; set; } 
    }
}
