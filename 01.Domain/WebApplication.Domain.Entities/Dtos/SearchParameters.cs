using System;

namespace WebApplication.Domain.Entities.Dtos
{
    public class SearchParameters<T>
    {
        public int PageSize { get; set; } = 10;
        public int? LastLoadedId { get; set; }
        public bool NeedTotalCount { get; set; } = false;
        public T SearchParameter { get; set; }
    }
    public class BaseSearchParameter : SearchParameters<int>
    {

    }
}
