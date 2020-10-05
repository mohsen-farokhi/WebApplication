using System.Collections.Generic;
using WebApplication.Domain.Entities.Base;

namespace WebApplication.Domain.Entities
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<UsersOfGroups> UsersOfGroups { get; set; }
        public ICollection<OperationsOfGroups> OperationsOfGroups { get; set; }
    }
}
