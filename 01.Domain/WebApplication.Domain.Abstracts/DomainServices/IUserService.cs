using System.Threading.Tasks;
using WebApplication.Domain.Entities.Dtos;
using WebApplication.Domain.Entities.Dtos.Data;

namespace WebApplication.Domain.Abstracts.DomainServices
{
    public interface IUserService
    {
        Task<DataResult<UserDto>> GetDataAsync(UserDataRequestDto userDaraRequest);
        Task<int> InsertAsync(UserDto userDto);
        Task DeleteAsync(int userId);
    }
}
