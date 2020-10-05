using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Entities.Cms;

namespace WebApplication.Infrastructures.DataAccess.Configurations.Cms
{
    public class TagsOfPostsConfiguration : IEntityTypeConfiguration<TagsOfPosts>
    {
        public void Configure(EntityTypeBuilder<TagsOfPosts> builder)
        {
            builder.ToTable("TagsOfPosts", Constants.SCHEMA_CMS);

            builder.HasKey(c => new { c.TagId, c.PostId });

            builder.HasOne(c => c.Tag)
                .WithMany(tag => tag.PostTags)
                .HasForeignKey(c => c.TagId)
                .IsRequired();

            builder.HasOne(c => c.Post)
                .WithMany(post => post.PostTags)
                .HasForeignKey(c => c.PostId)
                .IsRequired();
        }
    }
}
