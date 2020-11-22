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
        private IOperationRepository _operationRepository;
        public IOperationRepository OperationRepository
        {
            get
            {
                if (_operationRepository == null)
                {
                    _operationRepository =
                        new OperationRepository(DatabaseContext);
                }

                return _operationRepository;
            }
        }
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

        // **************************************************
        private IUserRepository _userRepository;

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository =
                        new UserRepository(DatabaseContext);
                }

                return _userRepository;
            }
        }
        // **************************************************
    }
}
