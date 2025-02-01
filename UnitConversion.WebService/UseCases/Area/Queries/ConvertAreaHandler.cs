using MediatR;
using UnitConversion.ConversionUnits;
using UnitConversion.WebService.Models;

namespace UnitConversion.WebService.UseCases.Area.Queries;

public class ConvertAreaHandler : IRequestHandler<ConvertAreaQuery, ConvertResponse<AreaUnit>>
{
    public async Task<ConvertResponse<AreaUnit>> Handle(ConvertAreaQuery request, CancellationToken cancellationToken)
    {
        // Perform the conversion using the external library
        double convertedValue = new UnitConversion.Area(request.Value, request.FromUnit).To(request.ToUnit).Value;

        // Return the response
        return new ConvertResponse<AreaUnit>(request.FromUnit, request.ToUnit, request.Value, convertedValue);
    }
}
