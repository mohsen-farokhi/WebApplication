using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Domain.Entities;

namespace WebApplication.Infrastructures.DataAccess.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(c => c.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.Description)
                .HasMaxLength(1000);
        }
    }
}
