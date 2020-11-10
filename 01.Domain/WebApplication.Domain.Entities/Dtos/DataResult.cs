using System.Collections.Generic;

namespace WebApplication.Domain.Entities.Dtos
{
    public class DataResult<TEntity>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public IList<TEntity> Result { get; set; } = new List<TEntity>();

    }
}