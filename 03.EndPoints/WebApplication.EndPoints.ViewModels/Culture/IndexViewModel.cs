using System.ComponentModel.DataAnnotations;
using WebApplication.EndPoints.Resources.ViewModels;
using WebApplication.EndPoints.Resources.ViewModels.Areas.Administrator;

namespace ViewModels.Culture
{
    public class IndexViewModel
    {
        // **********
        public int Id { get; set; }
        // **********

        // **********
        [Display(ResourceType = typeof(MyCulture),
                 Name = nameof(MyCulture.Lcid))]
        public int? Lcid { get; set; }
        // **********

        // **********
        [Display(ResourceType = typeof(General),
                 Name = nameof(General.Name))]
        public string Name { get; set; }
        // **********

        // **********
        [Display(ResourceType = typeof(MyCulture),
                 Name = nameof(MyCulture.NativeName))]
        public string NativeName { get; set; }
        // **********

        // **********
        [Display(ResourceType = typeof(MyCulture),
                 Name = nameof(MyCulture.DisplayName))]
        public string DisplayName { get; set; }
        // **********

        // **********
        [Display(ResourceType = typeof(General),
                 Name = nameof(General.IsActive))]
        public bool IsActive { get; set; }
        // **********
    }
}
