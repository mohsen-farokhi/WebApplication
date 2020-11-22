using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using ViewModels.Enums.Extensions;

namespace ViewModels.Extensions
{
    public static class EnumExtension
    {
        public static IList<EnumSelectList> GetList<TEnum>()
        {
            var list =
                Enum.GetValues(typeof(TEnum)).Cast<TEnum>()
                .Select(c => new EnumSelectList
                {
                    Value = c.ToString(),
                    Text = GetDisplayName(c),
                }).ToList();

            return list;
        }

        public static string GetDisplayName<TEnum>(TEnum value)
        {
            if (value != null)
            {
                var member = value.GetType().GetMember(value.ToString())[0];
                var displayAttribute = member.GetCustomAttribute<DisplayAttribute>();
                if (displayAttribute != null)
                    return displayAttribute.GetName();

                return value.ToString();
            }

            return null;
        }
    }
}