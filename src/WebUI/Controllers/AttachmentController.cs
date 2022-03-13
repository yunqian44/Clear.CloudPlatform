using Clear.CloudPlatform.Domain.Entities.ToolsBlockEntities;
using Microsoft.AspNetCore.Mvc;

namespace Clear.CloudPlatform.WebUI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AttachmentController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AttachmentController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet("ToolsBlocks")]
    [ProducesResponseType(typeof(IEnumerable<ToolsBlockItem>),StatusCodes.Status200OK)]
    public async Task<IActionResult> ToolsBlocks()
    {
        return Ok();
    }
}
