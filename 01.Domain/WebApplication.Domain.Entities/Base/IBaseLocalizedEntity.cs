using System.Threading;

namespace WebApplication.Domain.Entities.Base
{
    public interface IBaseLocalizedEntity
    {
        int CultureLcid { get; set; }
    }
}
