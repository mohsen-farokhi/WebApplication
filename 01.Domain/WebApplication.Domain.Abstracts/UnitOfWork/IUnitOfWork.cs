using System;
using System.Threading.Tasks;
using WebApplication.Domain.Abstracts.Repositories;

namespace WebApplication.Domain.Abstracts.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        Task SaveAsync();
        ICultureRepository CultureRepository { get; }
    }
}
