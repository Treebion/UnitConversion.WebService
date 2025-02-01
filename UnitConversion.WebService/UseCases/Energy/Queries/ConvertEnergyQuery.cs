
using MediatR;
using UnitConversion.ConversionUnits;
using UnitConversion.WebService.Models;

namespace UnitConversion.WebService.UseCases.Energy.Queries;

/// <summary>
/// Represents a query to convert an energy value from one unit to another.
/// </summary>
/// <param name="FromUnit">The unit to convert from.</param>
/// <param name="ToUnit">The unit to convert to.</param>
/// <param name="Value">The value to be converted.</param>
public record ConvertEnergyQuery(EnergyUnit FromUnit, EnergyUnit ToUnit, double Value) : IRequest<ConvertResponse<EnergyUnit>>;
