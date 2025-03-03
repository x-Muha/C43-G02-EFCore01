
using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment01.Models
{
    internal class Stud_Course
    {
        [Key]
        public int Stud_ID { get; set; }
        public int Course_ID { get; set; }
        public string Grade { get; set; }
    }
}
