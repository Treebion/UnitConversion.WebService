using MediatR;
using UnitConversion.ConversionUnits;
using UnitConversion.WebService.Models;

namespace UnitConversion.WebService.UseCases.Energy.Queries;

/// <summary>
/// Handles the conversion of energy units.
/// </summary>
public class ConvertEnergyHandler : IRequestHandler<ConvertEnergyQuery, ConvertResponse<EnergyUnit>>
{
    /// <summary>
    /// Handles the conversion request.
    /// </summary>
    /// <param name="request">The conversion request containing FromUnit, ToUnit, and Value.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The response containing the converted value and relevant details.</returns>
    public async Task<ConvertResponse<EnergyUnit>> Handle(ConvertEnergyQuery request, CancellationToken cancellationToken)
    {
        // Perform the conversion using the external library
        double convertedValue = new UnitConversion.Energy(request.Value, request.FromUnit).To(request.ToUnit).Value;

        // Return the response
        return new ConvertResponse<EnergyUnit>(request.FromUnit, request.ToUnit, request.Value, convertedValue);
    }
}
