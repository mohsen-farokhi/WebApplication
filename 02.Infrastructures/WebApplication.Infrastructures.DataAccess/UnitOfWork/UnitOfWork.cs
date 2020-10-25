using WebApplication.Domain.Abstracts.Repositories;
using WebApplication.Domain.Abstracts.UnitOfWork;
using WebApplication.Infrastructures.DataAccess.Repositories;
using WebApplication.Infrastructures.DataAccess.UnitOfWork.Base;

namespace WebApplication.Infrastructures.DataAccess.UnitOfWork
{
    public class UnitOfWork : BaseUnitOfWork, IUnitOfWork
    {
        public UnitOfWork(Tools.Options options) : base(options)
        {
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
                        new CultureRepository(DatabaseContext);
                }

                return _cultureRepository;
            }
        }
        // **************************************************

    }
}
