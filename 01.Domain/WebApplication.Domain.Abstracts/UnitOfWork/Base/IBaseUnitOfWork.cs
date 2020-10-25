using System;
using System.Threading.Tasks;

namespace WebApplication.Domain.Abstracts.UnitOfWork.Base
{
    public interface IBaseUnitOfWork : IDisposable
    {
        void Save();
        Task SaveAsync();
        bool IsDisposed { get; }
    }
}
