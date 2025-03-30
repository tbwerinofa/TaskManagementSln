

using FluentValidation.Results;
using System.Xml.Linq;

namespace TaskManagement.Application.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string name) : base(name)
    {

    }

    public BadRequestException(string name, ValidationResult validationResult)
        : base(name)
    {
        ValidationErrors = validationResult.ToDictionary();
    }

    public IDictionary<string, string[]> ValidationErrors { get; set; }
}
