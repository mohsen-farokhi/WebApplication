using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Domain.Entities;

namespace WebApplication.Infrastructures.DataAccess.Configurations
{
    public class UsersOfGroupsConfiguration : IEntityTypeConfiguration<UsersOfGroups>
    {
        public void Configure(EntityTypeBuilder<UsersOfGroups> builder)
        {
            builder.HasKey(c => new { c.UserId, c.GroupId });

            builder.HasOne(c => c.Group)
                .WithMany(group => group.UsersOfGroups)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(c => c.User)
                .WithMany(user => user.UsersOfGroups)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
