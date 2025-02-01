using Swashbuckle.AspNetCore.Filters;
using UnitConversion.ConversionUnits;
using UnitConversion.WebService.Models;

namespace UnitConversion.WebService.SwaggerExamples.Energy;

public class ConvertEnergyResponseExample : IExamplesProvider<ConvertResponse<EnergyUnit>>
{
    public ConvertResponse<EnergyUnit> GetExamples()
    {
        return new ConvertResponse<EnergyUnit>(
            fromUnit: EnergyUnit.Joules,
            toUnit: EnergyUnit.Kilojoules,
            inputValue: 1234.567,
            convertedValue: 1.234567
        );
    }
}
