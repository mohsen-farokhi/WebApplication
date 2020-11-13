namespace ViewModels
{
    public class ViewDataRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalCount { get; set; }
    }
}
