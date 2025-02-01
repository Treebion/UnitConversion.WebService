using Swashbuckle.AspNetCore.Filters;
using UnitConversion.ConversionUnits;
using UnitConversion.WebService.Models;

namespace UnitConversion.WebService.SwaggerExamples.Area;

public class ConvertAreaResponseExample : IExamplesProvider<ConvertResponse<AreaUnit>>
{
    public ConvertResponse<AreaUnit> GetExamples()
    {
        return new ConvertResponse<AreaUnit>(
            fromUnit: AreaUnit.SquareMetres,
            toUnit: AreaUnit.SquareFeet,
            inputValue: 10.0,
            convertedValue: 107.63915051182416
        );
    }
}
