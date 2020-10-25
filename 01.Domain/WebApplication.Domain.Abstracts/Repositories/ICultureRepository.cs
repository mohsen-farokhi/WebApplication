using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Domain.Abstracts.Repositories.Base;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Entities.Dtos;

namespace WebApplication.Domain.Abstracts.Repositories
{
    public interface ICultureRepository : IRepository<Culture>
    {
        Task<IList<CultureDto>> GetAll();
    }
}
