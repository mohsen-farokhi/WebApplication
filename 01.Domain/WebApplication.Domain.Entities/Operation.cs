using System.Collections.Generic;
using WebApplication.Domain.Entities.Base;
using WebApplication.Domain.Entities.Enums;

namespace WebApplication.Domain.Entities
{
    public class Operation : BaseExtendedEntity
    {
        public int? ParentId { get; set; }
        public Operation Parent { get; set; }
        public AccessType AccessType { get; set; }
        public string Name { get; set; }
        public bool IsVisibleJustForProgrammer { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public ICollection<Operation> SubOperations { get; set; }
        public ICollection<OperationsOfGroups> OperationsOfGroups { get; set; }
    }
}
