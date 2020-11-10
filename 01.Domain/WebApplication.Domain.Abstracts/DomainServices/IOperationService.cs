using System.Threading.Tasks;
using WebApplication.Domain.Entities.Dtos;

namespace WebApplication.Domain.Abstracts.DomainServices
{
    public interface IOperationService
    {
        Task<DataResult<OperationDto>> GetAsync(DataSourceRequest request);
        Task<int> InsertAsync(OperationDto dto);
        Task DeleteAsync(int operationId);
    }
}
