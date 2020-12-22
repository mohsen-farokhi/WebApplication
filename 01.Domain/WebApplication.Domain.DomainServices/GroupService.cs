using System.Linq;
using System.Threading.Tasks;
using WebApplication.Domain.Abstracts.DomainServices;
using WebApplication.Domain.Abstracts.UnitOfWork;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Entities.Dtos;
using WebApplication.Domain.Entities.Dtos.Data;

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
                    IsActive = dto.IsActive,
                    Name = dto.Name,
                    Description = dto.Description,
                });

            await _unitOfWork.SaveAsync();

            return entity.Id;
        }

        public async Task<DataResult<GroupDto>> GetDataAsync(GroupDataRequestDto groupDataRequest)
        {
            var predicate = PredicateBuilder.True<Group>();

            if (groupDataRequest.IsActive.HasValue)
                predicate = predicate.And(c => c.IsActive == groupDataRequest.IsActive.Value);

            if (!string.IsNullOrWhiteSpace(groupDataRequest.Name))
                predicate = predicate.And(c => c.Name.Contains(groupDataRequest.Name));

            var data =
                await _unitOfWork.GroupRepository.GetWithRequestAsync(groupDataRequest, predicate);

            var result = new DataResult<GroupDto>
            {
                Page = data.Page,
                PageSize = data.PageSize,
                TotalCount = data.TotalCount,
                Result = data.Result.Select(c => new GroupDto
                {
                    Id = c.Id,
                    IsActive = c.IsActive,
                    Name = c.Name,
                }).ToList(),
            };

            return result;
        }
    }
}
