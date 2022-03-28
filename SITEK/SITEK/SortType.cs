using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SITEK
{
    internal enum SortType
    {
        [Description("Сортировка по имени")]
        Name,
        [Description("Сортировка по количеству неисполненных входящих документов")]
        Rkk,
        [Description("Сортировка по количеству неисполненных письменных обращений граждан")]
        Appeals,
        [Description("Сортировка по общему количество документов")]
        Total,
        [Description("Сортировка не устанавливалась")]
        None
    }

    public static class SortEnumExtensions
    {
        public static string GetDescription<T>(this T enumerationValue) where T : struct
        {
            var type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", nameof(enumerationValue));
            }

            var memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return enumerationValue.ToString();
        }
    }
}
