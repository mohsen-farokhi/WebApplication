using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Areas.Administrator.User
{
    public class CreateViewModel
    {
        //[DisplayName("Lcid")]
        [Display(Name = "Lcid")]
        public int Lcid { get; set; }
    }
}
