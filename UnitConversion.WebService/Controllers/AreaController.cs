using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using UnitConversion.ConversionUnits;
using UnitConversion.WebService.Models;
using UnitConversion.WebService.SwaggerExamples.Area;
using UnitConversion.WebService.UseCases.Area.Queries;
using UnitConversion.WebService.UseCases.Shared.Queries;

namespace UnitConversion.WebService.Controllers;

[Route("area")]
[ApiController]
public class AreaController : ControllerBase
{
    private readonly IMediator _mediator;

    public AreaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Converts a value from one area unit to another.
    /// </summary>
    /// <param name="command">The conversion request containing FromUnit, ToUnit, and Value.</param>
    /// <returns>The converted value and relevant details.</returns>
    [HttpPost("convert")]
    [ProducesResponseType(typeof(ConvertResponse<AreaUnit>), 200)]
    [SwaggerRequestExample(typeof(ConvertAreaQuery), typeof(ConvertAreaQueryExample))]
    [SwaggerResponseExample(200, typeof(ConvertAreaResponseExample))]
    public async Task<IActionResult> ConvertArea([FromBody] ConvertAreaQuery command)
    {
        if (command == null)
        {
            return BadRequest("Invalid request: Conversion data is required.");
        }

        var result = await _mediator.Send(command);
        return Ok(result);
    }

    /// <summary>
    /// Retrieves all available area units.
    /// </summary>
    [HttpGet("units")]
    public async Task<IActionResult> GetAvailableUnits()
    {
        var result = await _mediator.Send(new GetAvailableUnitsQuery());
        return Ok(result);
    }
}
