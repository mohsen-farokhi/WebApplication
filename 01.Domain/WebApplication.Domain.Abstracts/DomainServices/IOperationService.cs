using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Domain.Entities.Dtos;
using WebApplication.Domain.Entities.Dtos.Data;

namespace WebApplication.Domain.Abstracts.DomainServices
{
    public interface IOperationService
    {
        Task<DataResult<OperationDto>> GetAsync(OperationDataResuqestDto request);
        Task<int> InsertAsync(OperationDto dto);
        Task DeleteAsync(int operationId);
        Task<IEnumerable<OperationDto>> GetParentsAsync();
    }
}
