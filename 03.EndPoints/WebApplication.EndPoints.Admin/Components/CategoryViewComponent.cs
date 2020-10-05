using Microsoft.AspNetCore.Mvc;

namespace WebApplication.EndPoints.Admin.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
