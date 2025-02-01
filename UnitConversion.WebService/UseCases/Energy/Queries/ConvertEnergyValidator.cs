using FluentValidation;
using UnitConversion.ConversionUnits;

namespace UnitConversion.WebService.UseCases.Energy.Queries;

/// <summary>
/// Validator for <see cref="ConvertEnergyQuery"/>.
/// </summary>
public class ConvertEnergyValidator : AbstractValidator<ConvertEnergyQuery>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConvertEnergyValidator"/> class.
    /// </summary>
    public ConvertEnergyValidator()
    {
        RuleFor(x => x.FromUnit)
            .Must(value => Enum.IsDefined(typeof(EnergyUnit), value))
            .WithMessage(x => $"Invalid FromUnit '{x.FromUnit}'. Allowed values: {string.Join(", ", Enum.GetNames(typeof(EnergyUnit)))}");

        RuleFor(x => x.ToUnit)
            .Must(value => Enum.IsDefined(typeof(EnergyUnit), value))
            .WithMessage(x => $"Invalid ToUnit '{x.ToUnit}'. Allowed values: {string.Join(", ", Enum.GetNames(typeof(EnergyUnit)))}");

        RuleFor(x => x.Value)
            .GreaterThan(0)
            .WithMessage("Value must be greater than zero.");
    }
}
