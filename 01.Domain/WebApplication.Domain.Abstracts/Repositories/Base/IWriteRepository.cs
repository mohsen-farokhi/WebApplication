using System.Threading.Tasks;
using WebApplication.Domain.Entities.Base;

namespace WebApplication.Domain.Abstracts.Repositories.Base
{
    public interface IWriteRepository<T> where T : BaseEntity, new()
    {
        int Insert(T entity);
        Task<int> InsertAsync(T entity);
        void Update(T entity);
        Task UpdateAsync(T entity);
        void Delete(int id);
        Task DeleteAsync(int id);
    }
}
