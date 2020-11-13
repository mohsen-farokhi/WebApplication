using System;
using System.Resources;

namespace ViewModels.Extensions
{
    public static class ResourceManagerExtension
    {
        public static string GetString
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
