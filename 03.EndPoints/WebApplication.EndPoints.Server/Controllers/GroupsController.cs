using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.Group;
using WebApplication.Domain.Abstracts.DomainServices;
using WebApplication.Domain.Entities.Dtos;

namespace WebApplication.EndPoints.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpPost]
        public async Task<int> Post(GroupDto group)
        {
            var id =
                await _groupService.InsertAsync(new GroupDto
                {
                    IsActive = group.IsActive,
                    Name = group.Name,
                    Description = group.Description,
                });

            return id;
        }

        [HttpPost]
        [Route("GetData")]
        public async Task<ActionResult<ViewPagingDataResult<GroupDataViewModel>>> GetData
            (GroupDataRequestDto groupDataRequest)
        {
            var data =
                await _groupService.GetDataAsync(groupDataRequest);

            var result = new ViewPagingDataResult<GroupDataViewModel>
            {
                PageIndex = data.PageIndex,
                PageSize = data.PageSize,
                TotalCount = data.TotalCount,
                Result = data.Result.Select(c => new GroupDataViewModel
                {
                    Id = c.Id,
                    IsActive = c.IsActive,
                    Name = c.Name,
                }).ToList(),
            };

            return result;
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int groupId)
        {
            await _groupService.DeleteAsync(groupId);
            return Ok();
        }
    }
}
