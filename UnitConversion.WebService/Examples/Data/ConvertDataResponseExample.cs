using Swashbuckle.AspNetCore.Filters;
using UnitConversion.ConversionUnits;
using UnitConversion.WebService.Models;

namespace UnitConversion.WebService.SwaggerExamples.Data;

public class ConvertDataResponseExample : IExamplesProvider<ConvertResponse<DataUnit>>
{
    public ConvertResponse<DataUnit> GetExamples()
    {
        return new ConvertResponse<DataUnit>(
            fromUnit: DataUnit.Bit,
            toUnit: DataUnit.Byte,
            inputValue: 8,
            convertedValue: 1
        );
    }
}
