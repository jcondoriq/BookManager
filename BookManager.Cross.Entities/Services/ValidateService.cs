namespace BookManager.Cross.Entities.Services
{
    public class ValidateService<T>
    {
        readonly IEnumerable<IValidator<T>> Validator;

        public ValidateService(IEnumerable<IValidator<T>> validator)
        {
            Validator = validator;
        }

        public async ValueTask ExecuteValidationGuard(
            T instanceToValidate, bool stopOnFirstValidationError = true)
        {
            List<KeyValuePair<string, string>> Failures = new();
            bool ContinueValidation = true;

            var Enumerator = Validator.GetEnumerator();

            while (Enumerator.MoveNext() && ContinueValidation)
            {
                bool IsValid = await Enumerator.Current.Validate(instanceToValidate);

                if (!IsValid)
                {
                    Failures.AddRange(Enumerator.Current.Failures);
                    ContinueValidation = !stopOnFirstValidationError;
                }
            }

            if (Failures.Any())
            {
                throw new ValidationException($"Error de validación", Failures);
            }
        }
    }
}
