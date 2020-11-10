using WebApplication.Domain.Entities.Enums;

namespace WebApplication.Domain.Entities.Dtos
{
    public class OperationDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int? ParentId { get; set; }
        public string Parent { get; set; }
        public AccessType AccessType { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
    }
}
