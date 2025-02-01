using MediatR;
using UnitConversion.ConversionUnits;
using UnitConversion.WebService.UseCases.Shared.Queries;

namespace UnitConversion.WebService.UseCases.Area.Queries;

/// <summary>
/// Handles the request to get all available area units.
/// </summary>
public class GetAvailableAreaUnitsHandler : IRequestHandler<GetAvailableUnitsQuery, List<string>>
{
    /// <summary>
    /// Handles the request to get all available area units.
    /// </summary>
    /// <param name="request">The request to get available units.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A list of available area unit names.</returns>
    public async Task<List<string>> Handle(GetAvailableUnitsQuery request, CancellationToken cancellationToken)
    {
        // Get all area unit names from the Enum
        return await Task.FromResult(Enum.GetNames(typeof(AreaUnit)).ToList());
    }
}
