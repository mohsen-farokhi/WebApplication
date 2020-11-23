using System.Collections.Generic;

namespace WebApplication.Domain.Entities.Dtos.Data
{
    public class DataResult<T> : DataRequest
    {
        public IList<T> Result { get; set; } = new List<T>();

    }
}