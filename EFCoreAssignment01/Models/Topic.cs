using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace EFCoreAssignment01.Models
{
    [Owned]
    internal class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
