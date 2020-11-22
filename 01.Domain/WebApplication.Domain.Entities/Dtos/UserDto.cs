using System;
using WebApplication.Domain.Entities.Enums;

namespace WebApplication.Domain.Entities.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
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
    }
}
