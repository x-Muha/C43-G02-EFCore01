
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace EFCoreAssignment01.Models
{
    [PrimaryKey(nameof(Stud_ID),nameof(Course_ID))]
    internal class Stud_Course
    {
        [ForeignKey(nameof(Student))]
        public int Stud_ID { get; set; }
        [ForeignKey(nameof(Course))]
        public int Course_ID { get; set; }
        public string Grade { get; set; } = null!;

        public virtual Student Student { get; set; } = null!;
        public virtual Course Course { get; set; } = null!;
    }
}
