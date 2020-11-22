using System.ComponentModel.DataAnnotations;

namespace ViewModels.Enums
{
    public enum UserType
    {
        // **********
        [Display
            (ResourceType = typeof(Resources.Enums.UserType),
            Name = nameof(Resources.Enums.UserType.Programmer))]
        Programmer,
        // **********

        // **********
        [Display
            (ResourceType = typeof(Resources.Enums.UserType),
            Name = nameof(Resources.Enums.UserType.Owner))]
        Owner,
        // **********

        // **********
        [Display
            (ResourceType = typeof(Resources.Enums.UserType),
            Name = nameof(Resources.Enums.UserType.Supervisor))]
        Supervisor,
        // **********

        // **********
        [Display
            (ResourceType = typeof(Resources.Enums.UserType),
            Name = nameof(Resources.Enums.UserType.User))]
        User,
        // **********
    }
}
