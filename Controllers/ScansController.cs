using Microsoft.AspNetCore.Mvc;
using onepathapi.Services;

[ApiController]
[Route("api/[controller]")]
public class ScansController : ControllerBase
{
    private readonly IScanService _scanService;

    public ScansController(IScanService scanService)
    {
        _scanService = scanService;
    }

    [HttpGet("{userId}")]
    public IActionResult GetUserScans(string userId)
    {
        var scans = _scanService.GetUserScans(userId);
        return Ok(scans);
    }

    [HttpPost("upload")]
    public IActionResult UploadScan()
    {
        var result = _scanService.UploadScan();
        return Ok(new { Message = result });
    }
}
