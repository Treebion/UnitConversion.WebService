using FluentValidation;
using UnitConversion.ConversionUnits;

namespace UnitConversion.WebService.UseCases.Data.Queries;

/// <summary>
/// Validator for <see cref="ConvertDataQuery"/>.
/// </summary>
public class ConvertDataValidator : AbstractValidator<ConvertDataQuery>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConvertDataValidator"/> class.
    /// </summary>
    public ConvertDataValidator()
    {
        RuleFor(x => x.FromUnit)
            .Must(value => Enum.IsDefined(typeof(DataUnit), value))
            .WithMessage(x => $"Invalid FromUnit '{x.FromUnit}'. Allowed values: {string.Join(", ", Enum.GetNames(typeof(DataUnit)))}");

        RuleFor(x => x.ToUnit)
            .Must(value => Enum.IsDefined(typeof(DataUnit), value))
            .WithMessage(x => $"Invalid ToUnit '{x.ToUnit}'. Allowed values: {string.Join(", ", Enum.GetNames(typeof(DataUnit)))}");

        RuleFor(x => x.Value)
            .GreaterThan(0)
            .WithMessage("Value must be greater than zero.");
    }
}
