using System.Collections.Generic;
using WebApplication.Domain.Entities.Base;
using WebApplication.Domain.Entities.Enums;

namespace WebApplication.Domain.Entities
{
    public class Operation : BaseExtendedEntity
    {
        public Operation()
        {
            SubOperations = new List<Operation>();
            OperationsOfGroups = new List<OperationsOfGroups>();
        }
        public int? ParentId { get; set; }
        public Operation Parent { get; set; }
        public AccessType AccessType { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public IList<Operation> SubOperations { get; set; }
        public IList<OperationsOfGroups> OperationsOfGroups { get; set; }
    }
}
