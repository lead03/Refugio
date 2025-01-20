using System;
using System.Linq;
using System.Reflection;

namespace Refugio.Business
{
    public class Common
    {
        public static void CheckRowVersion(byte[] modelVersion, byte[] DTOVersion)
        {
            if (modelVersion == null || DTOVersion == null)
            {
                throw new ArgumentNullException();
            }
            if (!modelVersion.SequenceEqual(DTOVersion))
            {
                throw new InvalidOperationException();
            }
        }

        public static TTarget Map<TSource, TTarget>(TSource source, TTarget target)
        {
            var sourceType = typeof(TSource);
            var targetType = typeof(TTarget);
            var sourceProperties = sourceType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var targetProperties = targetType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var sourceProperty in sourceProperties)
            {
                var targetProperty = targetProperties.FirstOrDefault(x => x.Name == sourceProperty.Name && x.PropertyType == sourceProperty.PropertyType);

                if (targetProperty != null)
                {
                    var value = sourceProperty.GetValue(source);
                    targetProperty.SetValue(target, value);
                }
            }
            return target;
        }
    }
}
