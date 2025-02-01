
using MediatR;
using UnitConversion.ConversionUnits;
using UnitConversion.WebService.Models;

namespace UnitConversion.WebService.UseCases.Energy.Queries;

public record ConvertEnergyQuery(EnergyUnit FromUnit, EnergyUnit ToUnit, double Value) : IRequest<ConvertResponse<EnergyUnit>>;