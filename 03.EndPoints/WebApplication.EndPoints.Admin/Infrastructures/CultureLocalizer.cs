using Microsoft.Extensions.Localization;
using System.Reflection;
using WebApplication.EndPoints.Admin.Resources;

namespace Infrastructures
{
    public class CultureLocalizer
    {
        private readonly IStringLocalizer _localizer;

        public CultureLocalizer(IStringLocalizerFactory factory)
        {
            var type = typeof(ShareResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("ShareResource", assemblyName.Name);
        }
        public LocalizedString Get(string key)
        {
            return _localizer[key];
        }
    }
}
