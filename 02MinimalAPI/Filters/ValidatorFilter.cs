using _02MinimalAPI.Validations;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace _02MinimalAPI.Filters;

public class ValidatorFilter<T> : IEndpointFilter where T : class
{
    private readonly string _methodName;
    private readonly IValidator<T> _validator;

    public ValidatorFilter(IValidator<T> validator)
    {
        _methodName = GetType().Name;
        this._validator = validator;
    }

    public virtual async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        var validatable = context.Arguments.SingleOrDefault(x => x?.GetType() == typeof(T));

        if (validatable == null)
        {
            return Results.BadRequest();
        }

        var validationResult = await _validator.ValidateAsync((T)validatable);

        if (!validationResult.IsValid)
        {
            return Results.BadRequest(validationResult.Errors.ToResponse());
        }

        var result = await next(context);

        return result;
    }
}
