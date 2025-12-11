public static class PatchHelper
{
    public static T SetIfChanged<T>(T target, T value)
    {
        if (value == null) return target;
        return !Equals(target, value) ? value : target;
    }

    public static string SetIfChanged(string target, string value)
    {
        return (!string.IsNullOrWhiteSpace(value) && target != value)
            ? value
            : target;
    }

    public static int SetIfChanged(int target, int? value)
    {
        return (value.HasValue && value.Value != 0 && target != value.Value)
            ? value.Value
            : target;
    }

    public static Guid SetIfChanged(Guid target, Guid? value)
    {
        return (value.HasValue && target != value.Value)
            ? value.Value
            : target;
    }
}
