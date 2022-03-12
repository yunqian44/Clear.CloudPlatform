using Clear.CloudPlatform.Application.MenuLists.Queries.GetMenuItems;
using Clear.CloudPlatform.Domain.Entities.MenuEntities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clear.CloudPlatform.WebUI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    private readonly IMediator _mediator;

    public MenuController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("gets")]
    [ProducesResponseType(typeof(IEnumerable<MenuItem>), StatusCodes.Status200OK)]
    public async Task<IActionResult>  Get()
    {
        
        var menuItems = await _mediator.Send(new GetMenuItemsQuery());
        if (menuItems is null) return Ok(Array.Empty<MenuItem>());

           
        return Ok(menuItems);
    }
}
