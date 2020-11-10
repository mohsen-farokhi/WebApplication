using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Culture;
using WebApplication.Domain.Abstracts.DomainServices;
using WebApplication.Domain.Entities.Dtos;

namespace WebApplication.EndPoints.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CulturesController : ControllerBase
    {
        private readonly ICultureService _cultureService;

        public CulturesController(ICultureService cultureService)
        {
            _cultureService = cultureService;
        }

        [HttpGet]
        public async Task<IEnumerable<IndexViewModel>> Get()
        {
            if (ModelState.IsValid)
            {
                var cultures =
                    (await _cultureService.GetAllAsync())
                    .Select(c => new IndexViewModel
                    {
                        Id = c.Id,
                        DisplayName = c.DisplayName,
                        IsActive = c.IsActive,
                        Lcid = c.Lcid,
                        Name = c.Name,
                        NativeName = c.NativeName,
                    });

                return cultures;
            }

            throw new ArgumentException();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CultureDto>> Get(int id)
        {
            var culture = await _cultureService.GetByIdAsync(id);

            return culture;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CreateViewModel viewModel)
        {
            int cultureId =
                await _cultureService.InsertAsync(new CultureDto
                {
                    IsActive = viewModel.IsActive,
                    Name = viewModel.Name,
                    DisplayName = viewModel.DisplayName,
                    NativeName = viewModel.NativeName,
                    Lcid = viewModel.Lcid,
                });

            return cultureId;
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int cultureId)
        {
            await _cultureService.DeleteAsync(cultureId);
            return Ok();
        }

    }
}
