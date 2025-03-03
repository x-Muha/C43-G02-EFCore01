using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreAssignment01.Models
{

    internal class Course
    {
        [Key]
        public int Id { get; set; }
        public string Duration { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; } //By Convention allow null
        public int Top_ID { get; set; }


    }
}
