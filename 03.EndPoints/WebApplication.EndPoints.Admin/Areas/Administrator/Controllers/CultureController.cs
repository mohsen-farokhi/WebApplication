using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Areas.Administrator.Culture;
using WebApplication.Domain.Abstracts.DomainServices;
using WebApplication.Domain.Entities.Dtos;

namespace WebApplication.EndPoints.Admin.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class CultureController : Controller
    {
        private readonly ICultureService _cultureService;

        public CultureController(ICultureService cultureService)
        {
            _cultureService = cultureService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result =
                (await _cultureService.GetAllAsync())
                .Select(c => new IndexViewModel
                {
                    Id = c.Id,
                    DisplayName = c.DisplayName,
                    NativeName = c.NativeName,
                    Name = c.Name,
                    Lcid = c.Lcid,
                    IsActive = c.IsActive,
                });

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _cultureService.InsertAsync(new CultureDto
                {
                    IsActive = viewModel.IsActive,
                    DisplayName = viewModel.DisplayName,
                },0);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }
    }
}