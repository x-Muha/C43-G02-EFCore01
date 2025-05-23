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
    internal class Course_Inst
    {
        //Primary key done by Fluent Api
        public int Inst_Id { get; set; }
        public int Course_Id { get; set; }
        public string Evaluate {  get; set; }

        public virtual Course Course { get; set; } 
        public virtual Instructor Instructor { get; set; } 
    }
}
