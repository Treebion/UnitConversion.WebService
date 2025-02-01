using MediatR;

namespace UnitConversion.WebService.UseCases.Shared.Queries;

public record GetAvailableUnitsQuery() : IRequest<List<string>>;
