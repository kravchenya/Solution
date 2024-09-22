public class BMapper : ITypeMapper
{
    public object Map(object data, Type sourceType, Type targetType)
    {
        var targetInstance = Activator.CreateInstance(targetType);

        foreach (var sourceProperty in sourceType.GetProperties())
        {
            var targetProperty = targetType.GetProperty(sourceProperty.Name);
            if (targetProperty != null && targetProperty.CanWrite)
            {
                var value = sourceProperty.GetValue(data);
                if (targetProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
                {
                    targetProperty.SetValue(targetInstance, value);
                }
                else
                {
                    var convertedValue = Convert.ChangeType(value, targetProperty.PropertyType);
                    targetProperty.SetValue(targetInstance, convertedValue);
                }
            }
        }

        return targetInstance;
    }
}
