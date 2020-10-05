namespace WebApplication.Domain.Entities.Base
{
    public interface IBaseExtendedEntity
    {
        bool IsActive { get; }
        bool IsSystem { get; }
        bool IsDeleted { get; }
    }
}
