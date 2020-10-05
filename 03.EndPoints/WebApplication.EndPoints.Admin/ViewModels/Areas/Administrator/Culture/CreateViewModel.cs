using System.ComponentModel.DataAnnotations;
using WebApplication.EndPoints.Resources;
using WebApplication.EndPoints.Resources.ViewModels;
using WebApplication.EndPoints.Resources.ViewModels.Areas.Administrator;

namespace ViewModels.Areas.Administrator.Culture
{
    public class CreateViewModel
    {
        // **********
        [Display(ResourceType = typeof(MyCulture),
                 Name = nameof(MyCulture.DisplayName))]
        [Required(ErrorMessageResourceType = typeof(Messages),
                  ErrorMessageResourceName = nameof(Messages.Required))]
        public string DisplayName { get; set; }
        // **********

        // **********
        [Display(ResourceType = typeof(General),
                 Name = nameof(General.IsActive))]
        public bool IsActive { get; set; }
        // **********
    }
}
