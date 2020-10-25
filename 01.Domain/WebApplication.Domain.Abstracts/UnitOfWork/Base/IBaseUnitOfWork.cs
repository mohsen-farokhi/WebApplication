using System;
using System.Threading.Tasks;
using WebApplication.Domain.Abstracts.Repositories.Base;
using WebApplication.Domain.Entities.Base;

namespace WebApplication.Domain.Abstracts.UnitOfWork.Base
{
    public interface IBaseUnitOfWork : IDisposable
    {
        void Save();
        Task SaveAsync();
        bool IsDisposed { get; }
    }
}
