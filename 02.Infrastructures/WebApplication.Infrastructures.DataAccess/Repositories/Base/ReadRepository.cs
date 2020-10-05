using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Domain.Abstracts.Repositories.Base;
using WebApplication.Domain.Entities.Base;
using WebApplication.Domain.Entities.Dtos;
using WebApplication.Infrastructures.DataAccess.DbContexts;

namespace WebApplication.Infrastructures.DataAccess.Repositories.Base
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly WebApplicationContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public ReadRepository(WebApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public TEntity Find(int id)
        {
            var entity = _dbSet.Find(id);
            return entity;
        }

        public async Task<TEntity> FindAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity;
        }

        public SearchResult<TEntity, BaseSearchParameter> GetList(BaseSearchParameter searchParameters)
        {
            var result = new SearchResult<TEntity, BaseSearchParameter>
            {
                SearchParameter = searchParameters
            };
            var query =
                _dbSet.AsNoTracking()
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
        public IQueryable<TEntity> Get()
        {
            return _dbSet.AsNoTracking();
        }

        public async Task<IQueryable<TEntity>> GetAsync()
        {
            return
                await Task.Run(() => _dbSet.AsNoTracking());
        }

    }
}
