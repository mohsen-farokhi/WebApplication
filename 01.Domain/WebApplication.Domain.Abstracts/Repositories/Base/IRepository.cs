using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication.Domain.Entities.Base;
using WebApplication.Domain.Entities.Dtos;

namespace WebApplication.Domain.Abstracts.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        TEntity Insert(TEntity entity);
        Task<TEntity> InsertAsync(TEntity entity);
        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);
        void DeleteById(int id);
        Task DeleteByIdAsync(int id);
        TEntity Find(int id);
        Task<TEntity> FindAsync(int id);
        IList<TEntity> GetAll();
        Task<IList<TEntity>> GetAllAsync();
        DataResult<TEntity> GetWithRequest(DataSourceRequest request);
        Task<DataResult<TEntity>> GetWithRequestAsync(DataSourceRequest request);
    }
}
