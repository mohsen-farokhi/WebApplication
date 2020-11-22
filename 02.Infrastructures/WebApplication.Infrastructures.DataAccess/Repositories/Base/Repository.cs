using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication.Domain.Abstracts.Repositories.Base;
using WebApplication.Domain.Entities.Base;
using WebApplication.Domain.Entities.Dtos.Data;
using WebApplication.Infrastructures.DataAccess.DbContexts;

namespace WebApplication.Infrastructures.DataAccess.Repositories.Base
{
    public class Repository<TEntity> :
        IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly DatabaseContext _databaseContext;

        internal Repository
            (DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            dbSet = _databaseContext.Set<TEntity>();
        }

        protected DbSet<TEntity> dbSet { get; }

        public virtual TEntity Find(int id) =>
            dbSet.Find(id);

        public virtual async Task<TEntity> FindAsync(int id) =>
            await dbSet.FindAsync(id);

        public virtual void DeleteById(int id)
        {
            var entity = Find(id);
            dbSet.Remove(entity);
        }

        public virtual async Task DeleteByIdAsync(int id)
        {
            var entity = await FindAsync(id);
            dbSet.Remove(entity);
        }

        public virtual TEntity Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }

            dbSet.Add(entity);

            return entity;
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }

            await dbSet.AddAsync(entity);

            return entity;
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }

            dbSet.Update(entity);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }

            await Task.Run(() =>
            {
                dbSet.Update(entity);
            });
        }

        public virtual IList<TEntity> GetAll()
        {
            var result =
                dbSet.ToList();

            return result;
        }

        public virtual async Task<IList<TEntity>> GetAllAsync()
        {
            var result =
                await dbSet.ToListAsync();

            return result;
        }

        public virtual DataResult<TEntity> GetWithRequest
            (DataRequest request, Expression<Func<TEntity, bool>> predicate = null)
        {
            var query =
                dbSet.AsNoTracking();

            if (predicate != null)
                query = query.Where(predicate);

            return new DataResult<TEntity>
            {
                Page = request.Page,
                PageSize = request.PageSize,
                TotalCount = 
                    request.TotalCount != 0 ? 
                    request.TotalCount : 
                    query.Count(),
                Result =
                    query.Skip(request.PageSize * (request.Page - 1))
                    .Take(request.PageSize)
                    .ToList(),
            };
        }

        public virtual async Task<DataResult<TEntity>> GetWithRequestAsync
            (DataRequest request, Expression<Func<TEntity, bool>> predicate = null)
        {
            var query =
                dbSet.AsNoTracking();

            if (predicate != null)
                query = query.Where(predicate);

            return new DataResult<TEntity>
            {
                Page = request.Page,
                PageSize = request.PageSize,
                TotalCount = 
                    request.TotalCount != 0 ? 
                    request.TotalCount : 
                    await query.CountAsync(),
                Result = 
                    await query.Skip(request.PageSize * (request.Page - 1))
                    .Take(request.PageSize)
                    .ToListAsync(),
            };
        }
    }
}