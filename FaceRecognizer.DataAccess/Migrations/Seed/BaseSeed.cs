using System;
using System.Collections.Generic;
using System.Linq;

namespace FaceRecognizer.DataAccess.Migrations.Seed
{
    public class BaseSeed
    {
        public static void SeedByEnum<TEnum, TContext>(TContext context, Action<TContext, int, TEnum> action)
        {
            IEnumerable<TEnum> enums = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
            enums.ForEach(enumItem => action.Invoke(context, Convert.ToInt32(enumItem), enumItem));
        }
    }
}
