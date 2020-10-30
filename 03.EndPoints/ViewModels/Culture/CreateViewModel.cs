using System.ComponentModel.DataAnnotations;

namespace ViewModels.Culture
{
    public class CreateViewModel
    {
        // **********
        [Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Lcid))]

        [Required
            (AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public int? Lcid { get; set; }
        // **********

        // **********
        [Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Name))]

        [Required
            (AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public string Name { get; set; }
        // **********

        // **********
        [Display
            (ResourceType = typeof(Resources.Models.Cultures),
            Name = nameof(Resources.Models.Cultures.NativeName))]

        [Required
            (AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public string NativeName { get; set; }
        // **********

        // **********
        [Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.DisplayName))]
        public string DisplayName { get; set; }
        // **********

        // **********
        [Display
            (ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.IsActive))]
        public bool IsActive { get; set; }
        // **********
    }
}
