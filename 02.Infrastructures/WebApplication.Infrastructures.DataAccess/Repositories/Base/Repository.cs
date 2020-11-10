using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication.Domain.Abstracts.Repositories.Base;
using WebApplication.Domain.Entities.Base;
using WebApplication.Domain.Entities.Dtos;
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
            DbSet = _databaseContext.Set<TEntity>();
        }

        internal DbSet<TEntity> DbSet { get; }

        public virtual TEntity Find(int id) =>
            DbSet.Find(id);

        public virtual async Task<TEntity> FindAsync(int id) =>
            await DbSet.FindAsync(id);

        public virtual void DeleteById(int id)
        {
            var entity = Find(id);
            DbSet.Remove(entity);
        }

        public virtual async Task DeleteByIdAsync(int id)
        {
            var entity = await FindAsync(id);
            DbSet.Remove(entity);
        }

        public virtual TEntity Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }

            DbSet.Add(entity);

            return entity;
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }

            await DbSet.AddAsync(entity);

            return entity;
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }

            DbSet.Update(entity);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }

            await Task.Run(() =>
            {
                DbSet.Update(entity);
            });
        }

        public virtual IList<TEntity> GetAll()
        {
            var result =
                DbSet.ToList();

            return result;
        }

        public virtual async Task<IList<TEntity>> GetAllAsync()
        {
            var result =
                await DbSet.ToListAsync();

            return result;
        }

        public virtual DataResult<TEntity> GetWithRequest(DataSourceRequest request)
        {
            var query =
                DbSet.AsNoTracking()
                .OrderByDescending(c => c.Id);

            //if (request.Predicate != null)
            //    query = query.Where(request.Predicate);

            var result =
                query
                .Skip(request.PageSize * (request.Page - 1))
                .Take(request.PageSize)
                .ToList();

            return new DataResult<TEntity>
            {
                Page = request.Page,
                PageSize = request.PageSize,
                TotalCount = request.TotalCount != 0 ? request.TotalCount : query.Count(),
                Result = result,
            };
        }

        public virtual async Task<DataResult<TEntity>> GetWithRequestAsync(DataSourceRequest request)
        {
            var query =
                DbSet.AsNoTracking()
                .OrderByDescending(c => c.Id);

            //if (predicate != null)
            //    query = query.Where(predicate);

            var result =
                await query
                .Skip(request.PageSize * (request.Page - 1))
                .Take(request.PageSize)
                .ToListAsync();

            return new DataResult<TEntity>
            {
                Page = request.Page,
                PageSize = request.PageSize,
                TotalCount = request.TotalCount != 0 ? request.TotalCount : query.Count(),
                Result = result,
            };
        }
    }
}