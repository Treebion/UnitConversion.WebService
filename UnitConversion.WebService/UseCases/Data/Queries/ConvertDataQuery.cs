
using MediatR;
using UnitConversion.ConversionUnits;
using UnitConversion.WebService.Models;

namespace UnitConversion.WebService.UseCases.Data.Queries;

public record ConvertDataQuery(DataUnit FromUnit, DataUnit ToUnit, double Value) : IRequest<ConvertResponse<DataUnit>>;