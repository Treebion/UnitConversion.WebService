using MediatR;

namespace UnitConversion.WebService.UseCases.Shared.Queries;

/// <summary>
/// Represents a query to get all available units.
/// </summary>
public record GetAvailableUnitsQuery() : IRequest<List<string>>;
