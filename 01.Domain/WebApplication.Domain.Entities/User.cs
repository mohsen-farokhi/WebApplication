using Enums;
using System;
using System.Collections.Generic;
using WebApplication.Domain.Entities.Base;

namespace WebApplication.Domain.Entities
{
    public class User : BaseExtendedEntity, IBaseLocalizedEntity
    {
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserType UserType { get; set; }
        public string CellPhoneNumber { get; set; }
        public string Password { get; set; }
        public string NationalCode { get; set; }
        public string Username { get; set; }
        public DateTime? BirthDate { get; set; }
        public int CultureLcid { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public ICollection<UsersOfGroups> UsersOfGroups { get; set; }
    }
}
