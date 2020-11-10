using System.Collections.Generic;

namespace ViewModels
{
    public class ViewDataResult<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public IList<T> Result { get; set; } = new List<T>();
    }
}
