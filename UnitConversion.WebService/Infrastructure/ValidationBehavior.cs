using FluentValidation;
using MediatR;

namespace UnitConversion.WebService.Infrastructure;

/// <summary>
/// Behavior for validating requests in the MediatR pipeline.
/// </summary>
/// <typeparam name="TRequest">The type of the request.</typeparam>
/// <typeparam name="TResponse">The type of the response.</typeparam>
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationBehavior{TRequest, TResponse}"/> class.
    /// </summary>
    /// <param name="validators">The validators to use for validating the request.</param>
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    /// <summary>
    /// Handles the validation of the request.
    /// </summary>
    /// <param name="request">The request to validate.</param>
    /// <param name="next">The next delegate in the pipeline.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="ValidationException">Thrown when validation fails.</exception>
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
        var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

        if (failures.Count != 0)
        {
            throw new ValidationException(failures);
        }

        return await next();
    }
}
