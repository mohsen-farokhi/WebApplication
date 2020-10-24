using Microsoft.EntityFrameworkCore;
using System.Linq;
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
        private readonly WebApplicationContext _context;

        public Repository
            (WebApplicationContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
        }

        internal DbSet<TEntity> DbSet { get; }

        public TEntity Find(int id) =>
            DbSet.Find(id);

        public async Task<TEntity> FindAsync(int id) =>
            await DbSet.FindAsync(id);

        public SearchResult<TEntity, BaseSearchParameter> GetList
            (BaseSearchParameter searchParameters)
        {
            var result = new SearchResult<TEntity, BaseSearchParameter>
            {
                SearchParameter = searchParameters
            };

            var query =
                DbSet.AsNoTracking()
                .OrderByDescending(c => c.Id)
                .AsQueryable();

            if (searchParameters.SearchParameter != default)
                query = query.Where(c => c.Id <= searchParameters.SearchParameter);

            if (searchParameters.NeedTotalCount)
                result.TotalCount = query.Count();

            if (searchParameters.LastLoadedId.HasValue)
                query = query.Where(c => c.Id < searchParameters.LastLoadedId);

            result.Result =
                query.Take(searchParameters.PageSize)
                .ToList();

            return result;
        }

        public void Delete(int id)
        {
            var entity = DbSet.Find(id);
            DbSet.Remove(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await DbSet.FindAsync(id);
            DbSet.Remove(entity);
        }

        public int Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(paramName: nameof(entity));
            }

            DbSet.Add(entity);

            return entity.Id;
        }

        public async Task<int> InsertAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(paramName: nameof(entity));
            }

            await DbSet.AddAsync(entity);

            return entity.Id;
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(paramName: nameof(entity));
            }

            DbSet.Update(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException(paramName: nameof(entity));
            }

            await Task.Run(() =>
            {
                DbSet.Update(entity);
            });
        }
    }
}