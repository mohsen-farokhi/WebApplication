using WebApplication.Domain.Entities.Base;

namespace WebApplication.Domain.Abstracts.Repositories.Base
{
    public interface IRepository<T> :
        IReadRepository<T>, IWriteRepository<T> where T : BaseEntity, new()
    {
    }
}
