using Microsoft.AspNetCore.Mvc;

namespace WebApplication.EndPoints.Admin.Areas.Cms.Controllers
{
    [Area("Cms")]
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}