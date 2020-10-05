using System.Globalization;
using WebApplication.Domain.Entities.Base;

namespace WebApplication.Domain.Entities
{
    public class Culture: BaseExtendedEntity
    {
		public Culture()
		{
		}

		public Culture(CultureInfo cultureInfo)
		{
			Lcid = cultureInfo.LCID;
			Name = cultureInfo.Name;
			NativeName = cultureInfo.NativeName;
			DisplayName = cultureInfo.DisplayName;
		}

		public int? Lcid { get; set; }
        public string Name { get; set; }
        public string NativeName { get; set; }
        public string DisplayName { get; set; }

    }
}
