using System.Threading.Tasks;
using WebApplication.Domain.Entities.Dtos;

namespace WebApplication.Domain.Abstracts.DomainServices
{
    public interface IGroupService
    {
        Task<int> InsertAsync(GroupDto dto);
    }
}
