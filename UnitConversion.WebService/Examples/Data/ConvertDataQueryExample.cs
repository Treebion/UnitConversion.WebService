using Swashbuckle.AspNetCore.Filters;
using UnitConversion.ConversionUnits;
using UnitConversion.WebService.UseCases.Data.Queries;

namespace UnitConversion.WebService.SwaggerExamples.Data;

public class ConverDataQueryExample : IExamplesProvider<ConvertDataQuery>
{
    public ConvertDataQuery GetExamples()
    {
        return new ConvertDataQuery(
            FromUnit: DataUnit.Bit,
            ToUnit: DataUnit.Byte,
            Value: 8.0
        );
    }
}
