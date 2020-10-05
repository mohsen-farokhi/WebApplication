using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Entities.Cms;

namespace WebApplication.Infrastructures.DataAccess.Configurations.Cms
{
    public class PostCategoryConfiguration : IEntityTypeConfiguration<PostCategory>
    {
        public void Configure(EntityTypeBuilder<PostCategory> builder)
        {
            builder.ToTable("PostCategories", Constants.SCHEMA_CMS);

            builder.Property(c => c.Title)
                .HasMaxLength(100)
                .IsRequired();

            // backing field
            builder.Property(c => c.ImageUrl)
                .HasField("_imageUrl")
                .UsePropertyAccessMode(PropertyAccessMode.Property)
                .HasMaxLength(200)
                .IsUnicode(false)
                .IsRequired();
            
            builder.Property(c => c.Description)
                .HasMaxLength(500);
        }
    }
}
