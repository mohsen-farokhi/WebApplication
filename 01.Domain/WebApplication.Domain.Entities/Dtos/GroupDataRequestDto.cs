using WebApplication.Domain.Entities.Dtos.Data;

namespace WebApplication.Domain.Entities.Dtos
{
    public class GroupDataRequestDto : DataRequest
    {
        public bool? IsActive { get; set; }
        public string Name { get; set; }
    }
}
