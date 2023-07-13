using Application.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using Application.Planets;
using Application.Core;
using Domain;

namespace Api.Controllers;

public class PlanetController : BaseApiController
{

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PlanetData planet)
    {
        return HandleResult(await Mediator.Send(new Create.Command { Planet = planet }));
    }

    [HttpGet]
    public async Task<ActionResult<PagedList<PlanetResponse>>> List([FromQuery] PagingParams pagingParams)
    {
        return HandlePagedResult(await Mediator.Send(new List.Query { Params = pagingParams }));
    }

    [HttpGet("{planetId}")]
    public async Task<ActionResult<PlanetResponse>> Detail([FromRoute] Guid planetId)
    {
        return HandleResult(await Mediator.Send(new Detail.Query { Id = planetId }));
    }

    [HttpPut("{planetId}")]
    public async Task<ActionResult<PlanetResponse>> Edit([FromRoute] Guid planetId, [FromBody] PlanetData planet)
    {
        return HandleResult(await Mediator.Send(new Edit.Command { Id = planetId, Planet = planet }));
    }

    [HttpDelete("{planetId}")]
    public async Task<ActionResult<PlanetResponse>> Delete([FromRoute] Guid planetId)
    {
        return HandleResult(await Mediator.Send(new Delete.Command { Id = planetId }));
    }
}
