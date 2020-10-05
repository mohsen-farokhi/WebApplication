using WebApplication.Domain.Entities.Base;

namespace WebApplication.Domain.Entities.Cms
{
    public class TagsOfPosts
    {
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
