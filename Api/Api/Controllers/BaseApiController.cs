using Api.Extensions;
using Application.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
    private IMediator? _mediator;

#pragma warning disable CS8603 // Possible null reference return.
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
#pragma warning restore CS8603 // Possible null reference return.


    protected ActionResult HandleResult<T>(Result<T> result)
    {
        if (result == null) return NotFound();

        if (result.IsSucess && result.Value == null) return NotFound();

        if (result.IsSucess) return Ok(result.Value);

        return BadRequest(result.Error);
    }

    protected ActionResult HandlePagedResult<T>(Result<PagedList<T>> result)
    {
        if(result == null) return NotFound();

        if (result.IsSucess && result.Value == null) return NotFound();

        if (result.IsSucess)
        {
            Response.AddPaginationHeader(result.Value.CurrentPage, result.Value.PageSize,
                result.Value.TotalCount, result.Value.TotalPages);
            return Ok(result.Value);
        }

        return BadRequest(result.Error);
    }

}
