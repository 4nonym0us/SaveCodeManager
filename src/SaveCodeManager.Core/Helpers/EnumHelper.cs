using System;
using System.Linq;

namespace SaveCodeManager.Core.Helpers
{
    public static class EnumHelper
    {
        public static T GetValueFromName<T>(string className)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();

            var spacelessClassName = className.Replace(" ", "");
            var field = type.GetFields().FirstOrDefault(f => f.Name == spacelessClassName);

            if (field == null)
                throw new ArgumentException("Not found.", nameof(className));

            return (T)field.GetValue(null);
        }
    }
}