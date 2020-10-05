using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Entities.Cms;

namespace WebApplication.Infrastructures.DataAccess.Configurations.Cms
{
    public class PostCommentConfiguration : IEntityTypeConfiguration<PostComment>
    {
        public void Configure(EntityTypeBuilder<PostComment> builder)
        {
            builder.ToTable("PostComments", Constants.SCHEMA_CMS);

            builder.Property(c => c.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(c => c.UserEmailAddress)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(c => c.UserFullName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Subject)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.UserIP)
                .HasMaxLength(100)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasOne(c => c.Post)
                .WithMany(post => post.PostComments)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

        }
    }
}
