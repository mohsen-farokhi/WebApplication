namespace ViewModels
{
    public class ViewDataRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; } = 10;
        public int TotalCount { get; set; }
    }
}
