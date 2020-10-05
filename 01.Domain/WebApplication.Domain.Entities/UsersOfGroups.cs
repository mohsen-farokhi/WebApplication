using WebApplication.Domain.Entities.Base;

namespace WebApplication.Domain.Entities
{
    public class UsersOfGroups
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
