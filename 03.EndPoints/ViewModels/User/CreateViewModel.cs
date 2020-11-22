using System;
using System.ComponentModel.DataAnnotations;
using ViewModels.Enums;

namespace ViewModels.User
{
    public class CreateViewModel
    {
        // **********
        public bool IsActive { get; set; }
        // **********

        // **********
        [Display
            (ResourceType = typeof(Resources.Models.User),
            Name = nameof(Resources.Models.User.EmailAddress))]

        [Required
            (AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]

        [RegularExpression
            (Extensions.Patterns.Email,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.RegularExpressionForEmail))]
        public string EmailAddress { get; set; }
        // **********

        // **********
        [Display
            (ResourceType = typeof(Resources.Models.User),
            Name = nameof(Resources.Models.User.FirstName))]

        [Required
            (AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public string FirstName { get; set; }
        // **********

        // **********
        [Display
            (ResourceType = typeof(Resources.Models.User),
            Name = nameof(Resources.Models.User.LastName))]

        [Required
            (AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public string LastName { get; set; }
        // **********

        // **********
        [Display
            (ResourceType = typeof(Resources.Models.User),
            Name = nameof(Resources.Models.User.UserType))]

        [Required
            (AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public UserType UserType { get; set; }
        // **********

        // **********
        [Display
            (ResourceType = typeof(Resources.Models.User),
            Name = nameof(Resources.Models.User.CellPhoneNumber))]
        public string CellPhoneNumber { get; set; }
        // **********

        // **********
        [Display
            (ResourceType = typeof(Resources.Models.User),
            Name = nameof(Resources.Models.User.Password))]

        [Required
            (AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]

        [RegularExpression
            (Extensions.Patterns.Password,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.RegularExpressionForPassword))]
        public string Password { get; set; }
        // **********

        // **********
        [Display
            (ResourceType = typeof(Resources.Models.User),
            Name = nameof(Resources.Models.User.NationalCode))]

        [RegularExpression
            (Extensions.Patterns.NationalCode,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.RegularExpressionForNationalCode))]
        public string NationalCode { get; set; }
        // **********

        // **********
        [Display
            (ResourceType = typeof(Resources.Models.User),
            Name = nameof(Resources.Models.User.Username))]

        [Required
            (AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]

        [RegularExpression
            (Extensions.Patterns.Username,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.RegularExpressionForUsername))]
        public string Username { get; set; }
        // **********

        // **********
        public DateTime? BirthDate { get; set; }
        // **********
    }
}
