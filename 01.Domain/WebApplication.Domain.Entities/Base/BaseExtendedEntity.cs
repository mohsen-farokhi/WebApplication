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
        public int? ActivatorUserId { get; set; }
		public void SetIsActive(bool isActive, int userId)
		{
			if (isActive)
			{
				if (!IsActive)
				{
					IsActive = true;
					ActivatorUserId = userId;
				}
				else
				{
					if (!ActivatorUserId.HasValue)
						ActivatorUserId = userId;
				}
			}
			else
			{
				if (IsActive)
				{
					IsActive = false;
					ActivatorUserId = userId;
				}
			}
		}
		public bool IsSystem { get; set; }
        public bool IsDeleted { get; set; }
        public int? RemoverUserId { get; set; }
		public void SetIsDeleted(bool isDeleted, int userId)
		{
			if (isDeleted)
			{
				if (!IsDeleted)
				{
					IsDeleted = true;
					RemoverUserId = userId;
				}
				else
				{
					if (!RemoverUserId.HasValue)
						RemoverUserId = userId;
				}
			}
			else
			{
				if (IsDeleted)
				{
					IsDeleted = false;
					RemoverUserId = userId;
				}
			}
		}
        public DateTime InsertDateTime { get; protected set; }
        public DateTime UpdateDateTime { get; protected set; }
        public int? EditorUserId { get; set; }
        public void SetUpdateDateTime(int userId)
        {
            EditorUserId = userId;
            UpdateDateTime = DateTime.Now;
        }
    }
}
