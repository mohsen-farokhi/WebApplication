using WebApplication.Domain.Entities.Dtos.Data;
using WebApplication.Domain.Entities.Enums;

namespace WebApplication.Domain.Entities.Dtos
{
    public class UserDataRequestDto : PagingData
    {
        public bool? IsActive { get; set; }
        public string EmailAddress { get; set; }
        public string FullName { get; set; }
        public string NationalCode { get; set; }
        public UserType? UserType { get; set; }
    }
}
