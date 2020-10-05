using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Domain.Entities;

namespace WebApplication.Infrastructures.DataAccess.Configurations
{
    public class OperationConfiguration : IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> builder)
        {
            builder.Property(c => c.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(c => c.DisplayName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.Description)
                .HasMaxLength(500);

            builder.HasOne(c => c.Parent)
                .WithMany(operation => operation.SubOperations)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
