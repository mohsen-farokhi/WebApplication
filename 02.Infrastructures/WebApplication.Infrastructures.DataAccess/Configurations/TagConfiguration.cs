using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Domain.Entities;

namespace WebApplication.Infrastructures.DataAccess.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

            // backing field
            builder.Property(c => c.Url)
                .HasField("_url") // optional if start with _
                .UsePropertyAccessMode(PropertyAccessMode.Property)
                .HasMaxLength(200)
                .IsUnicode(false)
                .IsRequired();

            builder.HasIndex(c => c.Url)
                .IsUnique();
        }
    }
}
