using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Domain.Abstracts.DomainServices;
using WebApplication.Domain.Abstracts.UnitOfWork;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Entities.Dtos;
using WebApplication.Domain.Entities.Dtos.Data;

namespace WebApplication.Domain.DomainServices
{
    public class OperationService : IOperationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OperationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DataResult<OperationDto>> GetAsync(OperationDataResuqestDto request)
        {
            var predicate = PredicateBuilder.True<Operation>();

            if (request.IsActive.HasValue)
                predicate = predicate.And(c => c.IsActive == request.IsActive.Value);

            if (!string.IsNullOrEmpty(request.Name))
                predicate = predicate.And(c => c.Name.Contains(request.Name));

            if (!string.IsNullOrEmpty(request.DisplayName))
                predicate = predicate.And(c => c.DisplayName.Contains(request.DisplayName));

            var data =
                await _unitOfWork.OperationRepository
                .GetWithRequestAsync(request, predicate);

            var result =
                new DataResult<OperationDto>
                {
                    TotalCount = data.TotalCount,
                    Page = data.Page,
                    PageSize = data.PageSize,
                    Result = data.Result.Select(c => new OperationDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        DisplayName = c.DisplayName,
                        AccessType = c.AccessType,
                        IsActive = c.IsActive,
                        Parent = c.Parent?.DisplayName,
                    }).ToList(),
                };

            return result;
        }

        public async Task<int> InsertAsync(OperationDto dto)
        {
            var operation =
                await _unitOfWork.OperationRepository.InsertAsync(new Operation
                {
                    Name = dto.Name,
                    IsActive = dto.IsActive,
                    DisplayName = dto.DisplayName,
                    AccessType = dto.AccessType.Value,
                    Description = dto.Description,
                    ParentId = dto.ParentId,
                });

            await _unitOfWork.SaveAsync();

            return operation.Id;
        }

        public async Task DeleteAsync(int operationId)
        {
            await _unitOfWork.OperationRepository.DeleteByIdAsync(operationId);
            await _unitOfWork.SaveAsync();
        }
    }
}
