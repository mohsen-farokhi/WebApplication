namespace WebApplication.Domain.Entities.Dtos.Data
{
    public class DataRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalCount { get; set; }
    }
}
