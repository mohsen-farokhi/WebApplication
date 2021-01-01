namespace WebApplication.Domain.Entities.Dtos.Data
{
    public class DataRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; } = 10;
        public int TotalCount { get; set; }
    }
}
