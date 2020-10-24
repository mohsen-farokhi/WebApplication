using System.Threading.Tasks;
using WebApplication.Domain.Entities.Base;
using WebApplication.Domain.Entities.Dtos;

namespace WebApplication.Domain.Abstracts.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        int Insert(TEntity entity);
        Task<int> InsertAsync(TEntity entity);
        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);
        void Delete(int id);
        Task DeleteAsync(int id);
        TEntity Find(int id);
        Task<TEntity> FindAsync(int id);
        SearchResult<TEntity, BaseSearchParameter> GetList(BaseSearchParameter searchParameters);
    }
}
