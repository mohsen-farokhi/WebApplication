namespace WebApplication.Domain.Entities.Dtos
{
    public class CultureDto
    {
        public int Id { get; set; }
        public int? Lcid { get; set; }
        public string Name { get; set; }
        public string NativeName { get; set; }
        public string DisplayName { get; set; }
        public bool IsActive { get; set; }
    }
}
