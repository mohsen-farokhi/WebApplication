using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Domain.Entities.Dtos;

namespace WebApplication.Domain.Abstracts.DomainServices
{
    public interface ICultureService
    {
        Task<IList<CultureDto>> GetAllAsync();
        Task<CultureDto> GetById(int id);
        Task<int> InsertAsync(CultureDto culture);
        Task DeleteAsync(int id);
        Task UpdateAsync(CultureDto culture, int userId);
    }
}
