using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Domain.Entities;

namespace WebApplication.Infrastructures.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(c => c.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.Username)
                .HasMaxLength(200)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(c => c.Password)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.BirthDate)
                .HasColumnType("date");

            builder.Property(c => c.NationalCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(c => c.EmailAddress)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(c => c.CellPhoneNumber)
                .HasMaxLength(11)
                .IsUnicode(false);

            builder.HasIndex(c => c.Username)
                .IsUnique();

            builder.Ignore(c => c.FullName);

        }
    }
}
