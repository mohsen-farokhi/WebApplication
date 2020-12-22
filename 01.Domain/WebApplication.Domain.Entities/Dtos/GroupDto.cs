namespace WebApplication.Domain.Entities.Dtos
{
    public class GroupDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
