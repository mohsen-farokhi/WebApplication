using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Entities.Cms;

namespace WebApplication.Infrastructures.DataAccess.Configurations.Cms
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts", Constants.SCHEMA_CMS);

            // backing field
            builder.Property(c => c.Url)
                .HasField("_url") // optional if start with _
                .UsePropertyAccessMode(PropertyAccessMode.Property)
                .HasMaxLength(200)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(c => c.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Body)
                .IsRequired();

            builder.Property(c => c.Author)
                .HasMaxLength(100);

            builder.HasIndex(c => c.Url)
                .IsUnique();

            builder.HasOne(c => c.PostCategory)
                .WithMany(category => category.Posts)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
