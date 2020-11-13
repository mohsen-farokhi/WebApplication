using WebApplication.Domain.Entities.Dtos.Data;

namespace WebApplication.Domain.Entities.Dtos
{
    public class OperationDataResuqestDto : DataRequest
    {
        public bool? IsActive { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}
