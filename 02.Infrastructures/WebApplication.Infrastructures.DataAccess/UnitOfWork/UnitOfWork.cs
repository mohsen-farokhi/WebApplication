using System.Threading.Tasks;
using WebApplication.Domain.Abstracts.Repositories;
using WebApplication.Domain.Abstracts.UnitOfWork;
using WebApplication.Infrastructures.DataAccess.DbContexts;
using WebApplication.Infrastructures.DataAccess.Repositories;

namespace WebApplication.Infrastructures.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private WebApplicationContext _context;

        public UnitOfWork(WebApplicationContext context)
        {
            _context = context;
        }

		public void Save()
        {
			_context.SaveChanges();
        }

        public async Task SaveAsync()
        {
			await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            _context = null;
        }

        // **************************************************
        //private IXXXXXRepository _xXXXXRepository;

        //public IXXXXXRepository XXXXXRepository
        //{
        //	get
        //	{
        //		if (_xXXXXRepository == null)
        //		{
        //			_xXXXXRepository =
        //				new XXXXXRepository(DatabaseContext);
        //		}

        //		return _xXXXXRepository;
        //	}
        //}
        // **************************************************

        // **************************************************
        private ICultureRepository _cultureRepository;
        public ICultureRepository CultureRepository
        {
            get
            {
                if (_cultureRepository == null)
                {
                    _cultureRepository =
                        new CultureRepository(_context);
                }

                return _cultureRepository;
            }
        }
        // **************************************************

    }
}
