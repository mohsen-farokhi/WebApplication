using System;

namespace WebApplication.Domain.Entities.Base
{
    public class BaseExtendedEntity : BaseEntity, IBaseExtendedEntity
    {
        public BaseExtendedEntity()
        {
            InsertDateTime = DateTime.Now;
            UpdateDateTime = DateTime.Now;
        }
        public bool IsActive { get; set; }
		public bool IsSystem { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime InsertDateTime { get; protected set; }
        public DateTime UpdateDateTime { get; set; }
    }
}
