using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CultureDto>> Get(int id)
        {
            var culture = await _cultureService.GetById(id);

            return culture;
        }
    }
}
