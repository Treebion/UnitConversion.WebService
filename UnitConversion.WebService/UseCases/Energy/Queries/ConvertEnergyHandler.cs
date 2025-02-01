using MediatR;
using UnitConversion.ConversionUnits;
using UnitConversion.WebService.Models;

namespace UnitConversion.WebService.UseCases.Energy.Queries;

public class ConvertEnergyHandler : IRequestHandler<ConvertEnergyQuery, ConvertResponse<EnergyUnit>>
{
    public async Task<ConvertResponse<EnergyUnit>> Handle(ConvertEnergyQuery request, CancellationToken cancellationToken)
    {
        // Perform the conversion using the external library
        double convertedValue = new UnitConversion.Energy(request.Value, request.FromUnit).To(request.ToUnit).Value;

        // Return the response
        return new ConvertResponse<EnergyUnit>(request.FromUnit, request.ToUnit, request.Value, convertedValue);
    }
}
