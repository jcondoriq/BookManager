namespace BookManager.Validators.Common
{
    internal abstract class ValidatorWrapper<T> :
        AbstractValidator<T>, Cross.Entities.Interfaces.IValidator<T>
    {
        public IEnumerable<KeyValuePair<string, string>> Failures { get; private set; }

        async ValueTask<bool> Cross.Entities.Interfaces.IValidator<T>.Validate(T instanceToValidate)
        {
            var Result = await ValidateAsync(instanceToValidate);

            if (!Result.IsValid)
            {
                Failures = Result.Errors
                    .Select(e =>
                            new KeyValuePair<string, string>(e.PropertyName, e.ErrorMessage))
                    .ToList();
            }

            return Result.IsValid;
        }
    }
}
