using Swashbuckle.AspNetCore.Filters;
using UnitConversion.ConversionUnits;
using UnitConversion.WebService.UseCases.Energy.Queries;

namespace UnitConversion.WebService.SwaggerExamples.Energy;

public class ConverEnergyQueryExample : IExamplesProvider<ConvertEnergyQuery>
{
    public ConvertEnergyQuery GetExamples()
    {
        return new ConvertEnergyQuery(
            FromUnit: EnergyUnit.Joules,
            ToUnit: EnergyUnit.Kilojoules,
            Value: 1234.567
        );
    }
}
