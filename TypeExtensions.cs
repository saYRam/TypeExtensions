    public static class TypeExtensions
    {
        public static void MapTo<T, S>(this S source, T target)
        {
            Type sourceType = source.GetType();
            Type targetType = target.GetType();

            var sourceProperties = sourceType.GetProperties();
            var targetProperties = targetType.GetProperties();

            //for (int i = 0; i < sourceProperties.Length; i++)
            for (int i = 0; i < targetProperties.Length; i++)
            {
                var curentProperty = sourceProperties[i];
                var targetProperty = targetProperties.FirstOrDefault(p => p.Name == curentProperty.Name);
                if (targetProperty != null)
                    targetProperty.SetValue(target, curentProperty.GetValue(source));
            }
        }
    }
