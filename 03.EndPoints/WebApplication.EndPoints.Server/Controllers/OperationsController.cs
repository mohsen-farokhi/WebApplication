using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.Operation;
using WebApplication.Domain.Abstracts.DomainServices;
using WebApplication.Domain.Entities.Dtos;

namespace WebApplication.EndPoints.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperationsController : ControllerBase
    {
        private readonly IOperationService _operationService;

        public OperationsController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        [HttpPost]
        [Route("GetData")]
        public async Task<ActionResult<ViewDataResult<IndexViewModel>>> GetData
            (DataSourceRequest request)
        {
            var data =
                await _operationService.GetAsync(request);

            var result = new ViewDataResult<IndexViewModel>
            {
                TotalCount = data.TotalCount,
                PageSize = data.PageSize,
                Page = data.Page,
                Result = data.Result.Select(c => new IndexViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    DisplayName = c.DisplayName,
                    IsActive = c.IsActive,
                    AccessType = (ViewModels.Enums.AccessType)c.AccessType,
                    Parent = c.Parent,
                }).ToList(),
            };

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var operationId =
                    await _operationService.InsertAsync(new OperationDto
                    {
                        Name = viewModel.Name,
                        IsActive = viewModel.IsActive,
                        DisplayName = viewModel.DisplayName,
                        ParentId = viewModel.ParentId,
                        Description = viewModel.Description,
                        AccessType = (Domain.Entities.Enums.AccessType)viewModel.AccessType,
                    });

                return operationId;
            }

            throw new ArgumentException();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int operationId)
        {
            await _operationService.DeleteAsync(operationId);
            return Ok();
        }

    }
}
