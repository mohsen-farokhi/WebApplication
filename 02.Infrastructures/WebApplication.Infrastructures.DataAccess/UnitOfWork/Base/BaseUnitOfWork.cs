using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication.Domain.Abstracts.UnitOfWork.Base;
using WebApplication.Infrastructures.DataAccess.DbContexts;
using WebApplication.Infrastructures.DataAccess.Repositories.Base;

namespace WebApplication.Infrastructures.DataAccess.UnitOfWork.Base
{
    public class BaseUnitOfWork : IBaseUnitOfWork
    {
        public BaseUnitOfWork(Tools.Options options) : base()
        {
            Options = options;
        }

        protected Tools.Options Options { get; set; }
        private DatabaseContext _databaseContext;

        /// <summary>
        /// Lazy Loading = Lazy Initialization
        /// </summary>
        internal DatabaseContext DatabaseContext
        {
            get
            {
                if (_databaseContext == null)
                {
                    var optionsBuilder =
                        new DbContextOptionsBuilder<DatabaseContext>();

                    switch (Options.Provider)
                    {
                        case Tools.Enums.Provider.SqlServer:
                            {
                                optionsBuilder.UseSqlServer
                                    (connectionString: Options.ConnectionString);

                                break;
                            }

                        case Tools.Enums.Provider.MySql:
                            {
                                //optionsBuilder.UseMySql
                                //	(connectionString: Options.ConnectionString);

                                break;
                            }

                        case Tools.Enums.Provider.Oracle:
                            {
                                //optionsBuilder.UseOracle
                                //	(connectionString: Options.ConnectionString);

                                break;
                            }

                        case Tools.Enums.Provider.PostgreSQL:
                            {
                                //optionsBuilder.UsePostgreSQL
                                //	(connectionString: Options.ConnectionString);

                                break;
                            }

                        case Tools.Enums.Provider.InMemory:
                            {
                                //optionsBuilder.UseInMemoryDatabase(databaseName: "Temp");

                                break;
                            }

                        default:
                            {
                                break;
                            }
                    }

                    _databaseContext =
                        new DatabaseContext(options: optionsBuilder.Options);
                }

                return _databaseContext;
            }
        }

        public void Save()
        {
            _databaseContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _databaseContext.SaveChangesAsync();
        }

        public bool IsDisposed { get; protected set; }

        public void Dispose()
        {
            Dispose(true);

            System.GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed)
            {
                return;
            }

            if (disposing)
            {
                if (_databaseContext != null)
                {
                    _databaseContext.Dispose();
                    _databaseContext = null;
                }
            }

            IsDisposed = true;
        }

        ~BaseUnitOfWork()
        {
            Dispose(false);
        }
    }
}
