using System.Threading.Tasks;
using WebApplication.Domain.Entities.Base;
using WebApplication.Domain.Entities.Dtos;

namespace WebApplication.Domain.Abstracts.Repositories.Base
{
    public interface IReadRepository<TEntity> where TEntity : BaseEntity, new()
    {
        TEntity Find(int id);
        Task<TEntity> FindAsync(int id);
        //SearchResult<TEntity, BaseSearchParameter> GetList(BaseSearchParameter searchParameters);
    }
}
