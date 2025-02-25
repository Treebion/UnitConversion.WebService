﻿using MediatR;
using UnitConversion.ConversionUnits;
using UnitConversion.WebService.Models;

namespace UnitConversion.WebService.UseCases.Data.Queries;

/// <summary>
/// Handles the conversion of data units.
/// </summary>
public class ConvertDataHandler : IRequestHandler<ConvertDataQuery, ConvertResponse<DataUnit>>
{
    /// <summary>
    /// Handles the conversion request.
    /// </summary>
    /// <param name="request">The conversion request containing FromUnit, ToUnit, and Value.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The response containing the converted value and relevant details.</returns>
    public async Task<ConvertResponse<DataUnit>> Handle(ConvertDataQuery request, CancellationToken cancellationToken)
    {
        // Perform the conversion using the external library
        double convertedValue = new UnitConversion.Data(request.Value, request.FromUnit).To(request.ToUnit).Value;

        // Return the response
        return new ConvertResponse<DataUnit>(request.FromUnit, request.ToUnit, request.Value, convertedValue);
    }
}
