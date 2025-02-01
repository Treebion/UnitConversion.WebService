using MediatR;
using UnitConversion.ConversionUnits;
using UnitConversion.WebService.Models;

namespace UnitConversion.WebService.UseCases.Area.Queries;

/// <summary>
/// Represents a query to convert an area value from one unit to another.
/// </summary>
/// <param name="FromUnit">The unit to convert from.</param>
/// <param name="ToUnit">The unit to convert to.</param>
/// <param name="Value">The value to be converted.</param>
public record ConvertAreaQuery(AreaUnit FromUnit, AreaUnit ToUnit, double Value) : IRequest<ConvertResponse<AreaUnit>>;

