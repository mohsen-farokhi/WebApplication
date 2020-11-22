using WebApplication.Domain.Entities.Dtos.Data;
using WebApplication.Domain.Entities.Enums;

namespace WebApplication.Domain.Entities.Dtos
{
    public class OperationDataResuqestDto : PagingData
    {
        public bool? IsActive { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public AccessType? AccessType { get; set; }
    }
}
