using WebApplication.Domain.Entities.Base;

namespace WebApplication.Domain.Entities
{
    public class OperationsOfGroups
    {
        public int OperationId { get; set; }
        public Operation Operation { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
