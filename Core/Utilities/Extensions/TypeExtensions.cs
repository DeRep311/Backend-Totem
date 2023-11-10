using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

public static class TypeExtensions
{
    public static PropertyInfo[] GetNonIgnoredProperties(this Type type)
    {
        return type.GetProperties()
            .Where(p => p.GetCustomAttribute<NotMappedAttribute>() == null)
            .ToArray();
    }
}
