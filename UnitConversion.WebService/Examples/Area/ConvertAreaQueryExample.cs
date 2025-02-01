using Swashbuckle.AspNetCore.Filters;
using UnitConversion.ConversionUnits;
using UnitConversion.WebService.UseCases.Area.Queries;

namespace UnitConversion.WebService.SwaggerExamples.Area;

public class ConvertAreaQueryExample : IExamplesProvider<ConvertAreaQuery>
{
    public ConvertAreaQuery GetExamples()
    {
        return new ConvertAreaQuery(
            FromUnit: AreaUnit.SquareMetres,
            ToUnit: AreaUnit.SquareFeet,
            Value: 10.0
        );
    }
}
