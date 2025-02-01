using MediatR;
using UnitConversion.ConversionUnits;
using UnitConversion.WebService.UseCases.Shared.Queries;

namespace UnitConversion.WebService.UseCases.Energy.Queries;

/// <summary>
/// Handles the request to get all available energy units.
/// </summary>
public class GetAvailableEnergyUnitsHandler : IRequestHandler<GetAvailableUnitsQuery, List<string>>
{
    /// <summary>
    /// Handles the request to get all available energy units.
    /// </summary>
    /// <param name="request">The request to get available units.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A list of available energy unit names.</returns>
    public async Task<List<string>> Handle(GetAvailableUnitsQuery request, CancellationToken cancellationToken)
    {
        // Get all energy unit names from the Enum
        return await Task.FromResult(Enum.GetNames(typeof(EnergyUnit)).ToList());
    }
}
