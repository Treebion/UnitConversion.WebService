using MediatR;
using UnitConversion.ConversionUnits;
using UnitConversion.WebService.Models;

namespace UnitConversion.WebService.UseCases.Area.Queries;

/// <summary>
/// Handles the conversion of area units.
/// </summary>
public class ConvertAreaHandler : IRequestHandler<ConvertAreaQuery, ConvertResponse<AreaUnit>>
{
    /// <summary>
    /// Handles the conversion request.
    /// </summary>
    /// <param name="request">The conversion request containing FromUnit, ToUnit, and Value.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The response containing the converted value and relevant details.</returns>
    public async Task<ConvertResponse<AreaUnit>> Handle(ConvertAreaQuery request, CancellationToken cancellationToken)
    {
        // Perform the conversion using the external library
        double convertedValue = new UnitConversion.Area(request.Value, request.FromUnit).To(request.ToUnit).Value;

        // Return the response
        return new ConvertResponse<AreaUnit>(request.FromUnit, request.ToUnit, request.Value, convertedValue);
    }
}
