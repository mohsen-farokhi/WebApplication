using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Domain.Entities;

namespace WebApplication.Infrastructures.DataAccess.Configurations
{
    public class OperationsOfGroupsConfiguration : IEntityTypeConfiguration<OperationsOfGroups>
    {
        public void Configure(EntityTypeBuilder<OperationsOfGroups> builder)
        {
            builder.HasKey(c => new { c.OperationId, c.GroupId });

            builder.HasOne(c => c.Operation)
                .WithMany(operation => operation.OperationsOfGroups)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(c => c.Group)
                .WithMany(group => group.OperationsOfGroups)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
