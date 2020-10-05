using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Domain.Entities;

namespace WebApplication.Infrastructures.DataAccess.Configurations
{
    public class CultureConfiguration : IEntityTypeConfiguration<Culture>
    {
        public void Configure(EntityTypeBuilder<Culture> builder)
        {
            builder.Property(c => c.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(c => c.NativeName)
                .HasMaxLength(50);

            builder.Property(c => c.DisplayName)
                .HasMaxLength(100)
                .IsRequired();

        }
    }
}
