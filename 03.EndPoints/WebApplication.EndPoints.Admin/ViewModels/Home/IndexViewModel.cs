using System.ComponentModel.DataAnnotations;
using Infrastructures;

namespace ViewModels.Home
{
    public class IndexViewModel
    {
        [Display(Name = "FullName")]
        [Required(ErrorMessage = "Required")]
        public string FullName { get; set; }

        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
