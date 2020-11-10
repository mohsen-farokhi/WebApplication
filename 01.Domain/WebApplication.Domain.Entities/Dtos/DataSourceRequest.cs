namespace WebApplication.Domain.Entities.Dtos
{
    public class DataSourceRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; } = 10;
        public int TotalCount { get; set; }
    }
}
