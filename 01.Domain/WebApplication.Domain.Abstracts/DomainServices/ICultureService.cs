using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Domain.Entities.Dtos;

namespace WebApplication.Domain.Abstracts.DomainServices
{
    public interface ICultureService
    {
        Task<IEnumerable<CultureDto>> GetAllAsync();
        Task<CultureDto> GetById(int id);
        Task<int> InsertAsync(CultureDto culture, int userId);
        Task DeleteAsync(int id, int userId);
        Task UpdateAsync(CultureDto culture, int userId);
    }
}
