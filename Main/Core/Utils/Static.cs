namespace MoviesApi.Main.Core.Utils;

/// <summary>
/// Utility class containing static methods.
/// </summary>
public static class Static
{

    /// <summary>
    /// Checks if any property of the given object is null or empty.
    /// </summary>
    /// <param name="obj">The object to be checked.</param>
    /// <returns>True if any property of the object is null or empty, otherwise false.</returns>
    public static bool IsAnyPropertyNullOrEmpty(object obj)
    {
        if (ReferenceEquals(obj, null))
            return true;

        return obj.GetType().GetProperties()
            .Any(x => IsPropertyNullOrEmpty(x.GetValue(obj)));
    }

    /// <summary>
    /// Checks if all properties of the given object are null or empty.
    /// </summary>
    /// <param name="obj">The object to be checked.</param>
    /// <returns>True if all properties of the object are null or empty, otherwise false.</returns>
    public static bool IsAllPropertyNullOrEmpty(object obj)
    {
        if (ReferenceEquals(obj, null))
            return true;

        return obj.GetType().GetProperties()
            .All(x => IsPropertyNullOrEmpty(x.GetValue(obj)));
    }

    
    private static bool IsPropertyNullOrEmpty(object? value)
    {
        if (ReferenceEquals(value, null))
            return true;

        var type = value.GetType();
        return type.IsValueType
               && Equals(value, Activator.CreateInstance(type));
    }
}