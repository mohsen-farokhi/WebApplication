using System.Collections.Generic;
using ViewModels.Enums;
using ViewModels.Enums.Extensions;
using ViewModels.Extensions;

namespace ViewModels.Operation
{
    public class SearchViewModel : ViewDataRequest
    {
        public bool? IsActive { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public AccessType? AccessType { get; set; }
        public IList<EnumSelectList> GetAccessTypes() =>
            EnumExtension.GetList<AccessType>();
    }
}
