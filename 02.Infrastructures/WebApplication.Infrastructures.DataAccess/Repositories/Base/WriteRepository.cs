using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication.Domain.Abstracts.Repositories.Base;
using WebApplication.Domain.Entities.Base;
using WebApplication.Infrastructures.DataAccess.DbContexts;

namespace WebApplication.Infrastructures.DataAccess.Repositories.Base
{
    public class WriteRepository<TEntity> : 
        IWriteRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly WebApplicationContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public WriteRepository(WebApplicationContext context)
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
    }
}
