using WebApplication.Domain.Entities.Base;

namespace WebApplication.Domain.Entities.Cms
{
    public class PostComment : BaseExtendedEntity
    {
        public PostComment()
        {

        }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int UserId { get; set; }
        public bool IsRead { get; set; }
        public bool IsPrivate { get; set; }
        public string UserIP { get; set; }
        public string UserFullName { get; set; }
        public string UserEmailAddress { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
    }
}
