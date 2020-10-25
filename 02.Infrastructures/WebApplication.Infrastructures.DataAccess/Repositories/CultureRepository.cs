using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Domain.Abstracts.Repositories;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Entities.Dtos;
using WebApplication.Infrastructures.DataAccess.DbContexts;
using WebApplication.Infrastructures.DataAccess.Repositories.Base;

namespace WebApplication.Infrastructures.DataAccess.Repositories
{
    public class CultureRepository : Repository<Culture>, ICultureRepository
    {
        internal CultureRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<IList<CultureDto>> GetAllAsync()
        {
            var task =
                await Task.Run(() =>
                {
                    var result =
                        DbSet.Select(c => new CultureDto
                        {
                            Id = c.Id,
                            DisplayName = c.DisplayName,
                            Lcid = c.Lcid,
                            Name = c.Name,
                            NativeName = c.NativeName,
                            IsActive = c.IsActive,
                        }).ToList();

                    return result;
                });

            return task;
        }
    }
}
