using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using UnitConversion.ConversionUnits;
using UnitConversion.WebService.Models;
using UnitConversion.WebService.SwaggerExamples.Energy;
using UnitConversion.WebService.UseCases.Energy.Queries;
using UnitConversion.WebService.UseCases.Shared.Queries;

namespace UnitConversion.WebService.Controllers;

[Route("energy")]
[ApiController]
public class EnergyController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="EnergyController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator instance.</param>
    public EnergyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Converts a value from one energy unit to another.
    /// </summary>
    /// <param name="command">The conversion request containing FromUnit, ToUnit, and Value.</param>
    /// <returns>The converted value and relevant details.</returns>
    [HttpPost("convert")]
    [ProducesResponseType(typeof(ConvertResponse<EnergyUnit>), 200)]
    [SwaggerRequestExample(typeof(ConvertEnergyQuery), typeof(ConverEnergyQueryExample))]
    [SwaggerResponseExample(200, typeof(ConvertEnergyResponseExample))]
    public async Task<IActionResult> ConvertEnergy([FromBody] ConvertEnergyQuery command)
    {
        if (command == null)
        {
            return BadRequest("Invalid request: Conversion data is required.");
        }

        var result = await _mediator.Send(command);
        return Ok(result);
    }

    /// <summary>
    /// Retrieves all available energy units.
    /// </summary>
    [HttpGet("units")]
    public async Task<IActionResult> GetAvailableUnits()
    {
        var result = await _mediator.Send(new GetAvailableUnitsQuery());
        return Ok(result);
    }
}
