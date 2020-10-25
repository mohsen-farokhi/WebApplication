using System;

namespace WebApplication.Domain.Entities.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime InsertDateTime { get; set; }
    }
}
