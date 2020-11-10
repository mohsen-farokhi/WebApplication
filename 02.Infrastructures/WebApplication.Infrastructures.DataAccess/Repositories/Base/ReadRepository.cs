using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Domain.Abstracts.Repositories.Base;
using WebApplication.Domain.Entities.Base;
using WebApplication.Domain.Entities.Dtos;
using WebApplication.Infrastructures.DataAccess.DbContexts;

namespace WebApplication.Infrastructures.DataAccess.Repositories.Base
{
    public class ReadRepository<TEntity> :
        IReadRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly DatabaseContext _databaseContext;
        internal ReadRepository(DatabaseContext context)
        {
            _databaseContext = context;
            DbSet = _databaseContext.Set<TEntity>();
        }

        internal DbSet<TEntity> DbSet { get; }

        public TEntity Find(int id) =>
            DbSet.Find(id);

        public async Task<TEntity> FindAsync(int id) =>
            await DbSet.FindAsync(id);

        //public SearchResult<TEntity, BaseSearchParameter> GetList
        //    (BaseSearchParameter searchParameters)
        //{
        //    var result = new SearchResult<TEntity, BaseSearchParameter>
        //    {
        //        SearchParameter = searchParameters
        //    };

        //    var query =
        //        DbSet.AsNoTracking()
        //        .OrderByDescending(c => c.Id)
        //        .AsQueryable();

        //    if (searchParameters.SearchParameter != default)
        //        query = query.Where(c => c.Id <= searchParameters.SearchParameter);

        //    if (searchParameters.NeedTotalCount)
        //        result.TotalCount = query.Count();

        //    if (searchParameters.LastLoadedId.HasValue)
        //        query = query.Where(c => c.Id < searchParameters.LastLoadedId);

        //    result.Result =
        //        query.Take(searchParameters.PageSize)
        //        .ToList();

        //    return result;
        //}

        public IQueryable<TEntity> Get() =>
            DbSet.AsNoTracking();

        public async Task<IQueryable<TEntity>> GetAsync() =>
            await Task.Run(() => DbSet.AsNoTracking());

    }
}
