using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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
                    Name = group.Name,
                    Description = group.Description,
                });

            return id;
        }
    }
}
