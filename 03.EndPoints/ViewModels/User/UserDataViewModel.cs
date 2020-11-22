using System;
using ViewModels.Enums;
using ViewModels.Extensions;

namespace ViewModels.User
{
    public class UserDataViewModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string EmailAddress { get; set; }
        public string CellPhoneNumber { get; set; }
        public string NationalCode { get; set; }
        public string Username { get; set; }
        public DateTime? BirthDate { get; set; }
        public string FullName { get; set; }
        public UserType UserType { get; set; }
        public string UserTypeValue
        {
            get =>
                EnumExtension.GetDisplayName(UserType);
        }
    }
}
