using WebApplication.Domain.Abstracts.Repositories;
using WebApplication.Domain.Abstracts.UnitOfWork.Base;

namespace WebApplication.Domain.Abstracts.UnitOfWork
{
    public interface IUnitOfWork : IBaseUnitOfWork
    {
        IOperationRepository OperationRepository { get; }
        ICultureRepository CultureRepository { get; }
        IUserRepository UserRepository { get; }
        IGroupRepository GroupRepository { get; }
    }
}
