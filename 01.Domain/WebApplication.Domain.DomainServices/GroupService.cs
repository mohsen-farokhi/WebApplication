using System.Threading.Tasks;
using WebApplication.Domain.Abstracts.DomainServices;
using WebApplication.Domain.Abstracts.UnitOfWork;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Entities.Dtos;

namespace WebApplication.Domain.DomainServices
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> InsertAsync(GroupDto dto)
        {
            var entity =
                _unitOfWork.GetRepository<Group>()
                .Insert(new Group
                {
                    Name = dto.Name,
                    Description = dto.Description,
                });

            await _unitOfWork.SaveAsync();

            return entity.Id;
        }
    }
}
