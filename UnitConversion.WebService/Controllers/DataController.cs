using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using UnitConversion.ConversionUnits;
using UnitConversion.WebService.Models;
using UnitConversion.WebService.SwaggerExamples.Data;
using UnitConversion.WebService.UseCases.Data.Queries;
using UnitConversion.WebService.UseCases.Shared.Queries;

namespace UnitConversion.WebService.Controllers;

[Route("data")]
[ApiController]
public class DataController : ControllerBase
{
    private readonly IMediator _mediator;

    public DataController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Converts a value from one area unit to another.
    /// </summary>
    /// <param name="command">The conversion request containing FromUnit, ToUnit, and Value.</param>
    /// <returns>The converted value and relevant details.</returns>
    [HttpPost("convert")]
    [ProducesResponseType(typeof(ConvertResponse<DataUnit>), 200)]
    [SwaggerRequestExample(typeof(ConvertDataQuery), typeof(ConverDataQueryExample))]
    [SwaggerResponseExample(200, typeof(ConvertDataResponseExample))]
    public async Task<IActionResult> ConvertData([FromBody] ConvertDataQuery command)
    {
        if (command == null)
        {
            return BadRequest("Invalid request: Conversion data is required.");
        }

        var result = await _mediator.Send(command);
        return Ok(result);
    }

    /// <summary>
    /// Retrieves all available data units.
    /// </summary>
    [HttpGet("units")]
    public async Task<IActionResult> GetAvailableUnits()
    {
        var result = await _mediator.Send(new GetAvailableUnitsQuery());
        return Ok(result);
    }
}
