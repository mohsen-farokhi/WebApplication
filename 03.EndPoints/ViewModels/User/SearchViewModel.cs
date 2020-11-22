using System.Collections.Generic;
using ViewModels.Enums;
using ViewModels.Enums.Extensions;
using ViewModels.Extensions;

namespace ViewModels.User
{
    public class SearchViewModel : ViewDataRequest
    {
        public bool? IsActive { get; set; }
        public string EmailAddress { get; set; }
        public string FullName { get; set; }
        public string NationalCode { get; set; }
        public UserType? UserType { get; set; }
        public IList<EnumSelectList> GetUserTypes() =>
            EnumExtension.GetList<UserType>();
    }
}
