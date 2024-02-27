using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions.Types;

public class ValidationException:Exception
{
    public IEnumerable<ValidationExceptionModel> Errors { get; set; }

    public ValidationException() : base()
    {
        Errors = Array.Empty<ValidationExceptionModel>();
    }

    public ValidationException(string? message) : base(message)
    {
        Errors = Array.Empty<ValidationExceptionModel>();
    }

    public ValidationException(string? message, Exception? exception) : base(message, exception)
    {
        Errors = Array.Empty<ValidationExceptionModel>();
    }

    public ValidationException(IEnumerable<ValidationExceptionModel> errors)
        : base(BuildErrorMessage(errors))
    {
        Errors = errors;
    }


    private static string BuildErrorMessage(IEnumerable<ValidationExceptionModel> errors)
    {
        IEnumerable<string> error = errors.Select(x => $"{Environment.NewLine} " +
        $"-- {x.Property} : {string.Join(Environment.NewLine,
        values: x.Errors ?? Array.Empty<string>())}");
        return $"Validation failed : {string.Join(string.Empty, error)}";
    }


    public class ValidationExceptionModel
    {
        public string? Property { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }

}
