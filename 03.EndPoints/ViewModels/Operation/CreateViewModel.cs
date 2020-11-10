using System.ComponentModel.DataAnnotations;
using ViewModels.Enums;

namespace ViewModels.Operation
{
    public class CreateViewModel
    {
        // **********
        public int? ParentId { get; set; }
        // **********

        // **********
        [Display
            (ResourceType = typeof(Resources.Models.Operation),
            Name = nameof(Resources.Models.Operation.AccessType))]

        [Required
            (AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public AccessType AccessType { get; set; }
        // **********

        // **********
        [Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Name))]

        [Required
            (AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]

        [RegularExpression
            (Extensions.Patterns.LatinLetters,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.LatinLetter))]
        public string Name { get; set; }
        // **********

        // **********
        [Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.IsActive))]
        public bool IsActive { get; set; }
        // **********

        // **********
        [Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.DisplayName))]

        [Required
            (AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public string DisplayName { get; set; }
        // **********

        // **********
        [Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Description))]
        public string Description { get; set; }
        // **********
    }
}
