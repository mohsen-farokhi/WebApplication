using System;
using WebApplication.Domain.Abstracts.Repositories;

namespace WebApplication.Domain.Abstracts.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICultureRepository CultureRepository { get; }
    }
}
