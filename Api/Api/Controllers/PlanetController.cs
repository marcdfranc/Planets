using Application.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using Application.Planets;
using Application.Core;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

public class PlanetController : BaseApiController
{

    [HttpPost]
    [Produces("application/json")]
    [SwaggerOperation(summary: "Create Planet", OperationId = "CreatePlanet", Description = "Create a new Planet registry")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromBody] PlanetData planet)
    {
        return HandleResult(await Mediator.Send(new Create.Command { Planet = planet }));
    }

    [HttpGet]
    [Produces("application/json")]
    [SwaggerOperation(summary: "Get Planets", OperationId = "GetPlanets", Description = "returns a paged array of Planets")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PagedList<PlanetResponse>>> List([FromQuery] PagingParams pagingParams)
    {
        return HandlePagedResult(await Mediator.Send(new List.Query { Params = pagingParams }));
    }

    [HttpGet("{planetId}")]
    [SwaggerOperation(summary: "Detail Planet", OperationId = "DetailPlanet", Description = "Get Planet detail by uuid")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PlanetResponse>> Detail([FromRoute] Guid planetId)
    {
        return HandleResult(await Mediator.Send(new Detail.Query { Id = planetId }));
    }

    [HttpPut("{planetId}")]
    [SwaggerOperation(summary: "Edit Planet", OperationId = "EditPlanet", Description = "Edit a Planet by uuid")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Edit([FromRoute] Guid planetId, [FromBody] PlanetData planet)
    {
        return HandleResult(await Mediator.Send(new Edit.Command { Id = planetId, Planet = planet }));
    }

    [HttpDelete("{planetId}")]
    [SwaggerOperation(summary: "Delete Planet", OperationId = "DeletePlanet", Description = "Delete a Planet by uuid")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]    
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete([FromRoute] Guid planetId)
    {
        return HandleResult(await Mediator.Send(new Delete.Command { Id = planetId }));
    }
}
