using MediatR;
using UnitConversion.ConversionUnits;
using UnitConversion.WebService.Models;

namespace UnitConversion.WebService.UseCases.Data.Queries;

public class ConvertDataHandler : IRequestHandler<ConvertDataQuery, ConvertResponse<DataUnit>>
{
    public async Task<ConvertResponse<DataUnit>> Handle(ConvertDataQuery request, CancellationToken cancellationToken)
    {
        // Perform the conversion using the external library
        double convertedValue = new UnitConversion.Data(request.Value, request.FromUnit).To(request.ToUnit).Value;

        // Return the response
        return new ConvertResponse<DataUnit>(request.FromUnit, request.ToUnit, request.Value, convertedValue);
    }
}
