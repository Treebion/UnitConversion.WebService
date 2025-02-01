using MediatR;
using UnitConversion.ConversionUnits;
using UnitConversion.WebService.UseCases.Shared.Queries;

namespace UnitConversion.WebService.UseCases.Data.Queries;

/// <summary>
/// Handles the request to get all available data units.
/// </summary>
public class GetAvailableDataUnitsHandler : IRequestHandler<GetAvailableUnitsQuery, List<string>>
{
    /// <summary>
    /// Handles the request to get all available data units.
    /// </summary>
    /// <param name="request">The request to get available units.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A list of available data unit names.</returns>
    public async Task<List<string>> Handle(GetAvailableUnitsQuery request, CancellationToken cancellationToken)
    {
        // Get all data unit names from the Enum
        return await Task.FromResult(Enum.GetNames(typeof(DataUnit)).ToList());
    }
}
