
using MediatR;
using UnitConversion.ConversionUnits;
using UnitConversion.WebService.Models;

namespace UnitConversion.WebService.UseCases.Data.Queries;

/// <summary>
/// Represents a query to convert a data value from one unit to another.
/// </summary>
/// <param name="FromUnit">The unit to convert from.</param>
/// <param name="ToUnit">The unit to convert to.</param>
/// <param name="Value">The value to be converted.</param>
public record ConvertDataQuery(DataUnit FromUnit, DataUnit ToUnit, double Value) : IRequest<ConvertResponse<DataUnit>>;
