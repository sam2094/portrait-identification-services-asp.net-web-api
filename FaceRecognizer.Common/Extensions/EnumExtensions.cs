using System;
using System.Linq;

namespace FaceRecognizer.Common.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// For getting custom attribute of Enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T GetAttribute<T>(this Enum value)
            where T: Attribute
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            return type.GetField(name)
                .GetCustomAttributes(false)
                .OfType<T>()
                .SingleOrDefault();
        }
    }
}
