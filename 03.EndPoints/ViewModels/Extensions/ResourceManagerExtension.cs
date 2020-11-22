using System;
using System.Resources;

namespace ViewModels.Extensions
{
    public static class ResourceManagerExtension
    {
        public static string GetLocalizedString
            (this Type resource, string name)
        {
            ResourceManager resourceManager =
                    new ResourceManager(resource);

            var value =
                resourceManager.GetString(name);

            return value;
        }
    }
}
