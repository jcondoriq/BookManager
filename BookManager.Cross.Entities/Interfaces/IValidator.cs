namespace BookManager.Cross.Entities.Interfaces
{
    public interface IValidator<T>
    {
        ValueTask<bool> Validate(T instanceToValidate);
        IEnumerable<KeyValuePair<string, string>> Failures { get; }
    }
}
