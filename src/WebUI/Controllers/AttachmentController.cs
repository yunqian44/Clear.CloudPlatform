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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status302Found)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ToolsBlocks()
    {

        return Ok();
    }
}
