using System.Threading.Tasks;
using WebApplication.Domain.Entities.Dtos;
using WebApplication.Domain.Entities.Dtos.Data;

namespace WebApplication.Domain.Abstracts.DomainServices
{
    public interface IGroupService
    {
        Task<int> InsertAsync(GroupDto dto);
        Task<DataResult<GroupDto>> GetDataAsync(GroupDataRequestDto groupDataRequest);
        Task DeleteAsync(int groupId);
    }
}
