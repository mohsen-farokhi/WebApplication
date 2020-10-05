using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Culture;
using WebApplication.Domain.Abstracts.DomainServices;

namespace WebApplication.EndPoints.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CultureController : ControllerBase
    {
        private readonly ICultureService _cultureService;

        public CultureController(ICultureService cultureService)
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
    }
}
