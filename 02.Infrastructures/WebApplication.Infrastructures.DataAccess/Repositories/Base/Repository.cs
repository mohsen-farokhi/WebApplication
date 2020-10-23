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
        private readonly IWriteRepository<TEntity> _writeRepository;
        private readonly IReadRepository<TEntity> _readRepository;

        public Repository
            (IWriteRepository<TEntity> writeRepository,
            IReadRepository<TEntity> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public TEntity Find(int id) =>
            _readRepository.Find(id);

        public Task<TEntity> FindAsync(int id) =>
            _readRepository.FindAsync(id);

        public IQueryable<TEntity> Get() =>
            _readRepository.Get();

        public async Task<IQueryable<TEntity>> GetAsync() => 
            await _readRepository.GetAsync();

        public SearchResult<TEntity, BaseSearchParameter> GetList
            (BaseSearchParameter searchParameters) =>
            _readRepository.GetList(searchParameters);

        public int Insert(TEntity entity) =>
            _writeRepository.Insert(entity);

        public async Task<int> InsertAsync(TEntity entity) =>
            await _writeRepository.InsertAsync(entity);

        public void Update(TEntity entity) =>
            _writeRepository.Update(entity);

        public async Task UpdateAsync(TEntity entity) =>
            await _writeRepository.UpdateAsync(entity);

        public void Delete(int id) =>
            _writeRepository.Delete(id);

        public async Task DeleteAsync(int id) =>
            await _writeRepository.DeleteAsync(id);
    }
}