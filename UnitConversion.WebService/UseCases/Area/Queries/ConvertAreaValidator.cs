using FluentValidation;
using UnitConversion.ConversionUnits;

namespace UnitConversion.WebService.UseCases.Area.Queries;

/// <summary>
/// Validator for <see cref="ConvertAreaQuery"/>.
/// </summary>
public class ConvertAreaValidator : AbstractValidator<ConvertAreaQuery>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConvertAreaValidator"/> class.
    /// </summary>
    public ConvertAreaValidator()
    {
        RuleFor(x => x.FromUnit)
            .Must(value => Enum.IsDefined(typeof(AreaUnit), value))
            .WithMessage(x => $"Invalid FromUnit '{x.FromUnit}'. Allowed values: {string.Join(", ", Enum.GetNames(typeof(AreaUnit)))}");

        RuleFor(x => x.ToUnit)
            .Must(value => Enum.IsDefined(typeof(AreaUnit), value))
            .WithMessage(x => $"Invalid ToUnit '{x.ToUnit}'. Allowed values: {string.Join(", ", Enum.GetNames(typeof(AreaUnit)))}");

        RuleFor(x => x.Value)
            .GreaterThan(0)
            .WithMessage("Value must be greater than zero.");
    }
}
