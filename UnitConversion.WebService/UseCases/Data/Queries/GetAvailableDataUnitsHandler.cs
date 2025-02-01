using MediatR;
using UnitConversion.ConversionUnits;
using UnitConversion.WebService.UseCases.Shared.Queries;

namespace UnitConversion.WebService.UseCases.Data.Queries;

public class GetAvailableDataUnitsHandler : IRequestHandler<GetAvailableUnitsQuery, List<string>>
{
    public async Task<List<string>> Handle(GetAvailableUnitsQuery request, CancellationToken cancellationToken)
    {
        // Get all area unit names from the Enum
        return await Task.FromResult(Enum.GetNames(typeof(DataUnit)).ToList());
    }
}
