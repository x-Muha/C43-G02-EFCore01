using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreAssignment01.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreAssignment01.ModelConfigurations
{
    internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasOne(D => D.Manager)
                   .WithOne(I => I.ManagedDepartment)
                   .HasForeignKey<Department>( D => D.ManagerId)
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired(true);
        }
    }
}
