using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Domain.Abstracts.Repositories.Base;
using WebApplication.Domain.Entities.Base;
using WebApplication.Domain.Entities.Dtos;

namespace WebApplication.Infrastructures.DataAccess.Repositories.Base
{
    public class Repository<TEntity> :
        IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public int Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }

        public async Task<int> InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            _context.SaveChanges();

            return entity.Id;
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
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

        public IQueryable<TEntity> Get()
        {
            return _dbSet.AsNoTracking();
        }

        public async Task<IQueryable<TEntity>> GetAsync()
        {
            return 
                await Task.Run(() => _dbSet.AsNoTracking());
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
    }
}
