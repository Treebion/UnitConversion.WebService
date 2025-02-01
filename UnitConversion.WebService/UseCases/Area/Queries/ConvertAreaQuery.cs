using MediatR;
using UnitConversion.ConversionUnits;
using UnitConversion.WebService.Models;

namespace UnitConversion.WebService.UseCases.Area.Queries;

public record ConvertAreaQuery(AreaUnit FromUnit, AreaUnit ToUnit, double Value) : IRequest<ConvertResponse<AreaUnit>>;

