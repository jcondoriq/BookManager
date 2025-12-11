using BookManager.Cross.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AlwaysValidValidator<T> : IValidator<T>
{
    public IEnumerable<KeyValuePair<string, string>> Failures
        => Enumerable.Empty<KeyValuePair<string, string>>();

    public ValueTask<bool> Validate(T instanceToValidate)
    {
        return ValueTask.FromResult(true);
    }
}
