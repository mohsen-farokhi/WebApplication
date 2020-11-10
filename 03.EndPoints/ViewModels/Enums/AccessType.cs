using System.ComponentModel.DataAnnotations;

namespace ViewModels.Enums
{
    public enum AccessType
    {
        // **********
        [Display
            (ResourceType = typeof(Resources.Enums.AccessType),
            Name = nameof(Resources.Enums.AccessType.Public))]

        Public,
        // **********

        // **********
        [Display
            (ResourceType = typeof(Resources.Enums.AccessType),
            Name = nameof(Resources.Enums.AccessType.Registered))]

        Registered,
        // **********

        // **********
        [Display
            (ResourceType = typeof(Resources.Enums.AccessType),
            Name = nameof(Resources.Enums.AccessType.Special))]

        Special,
        // **********
    }
}
