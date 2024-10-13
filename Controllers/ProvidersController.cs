using Microsoft.AspNetCore.Mvc;
using onepathapi.Services;

[ApiController]
[Route("api/[controller]")]
public class ProvidersController : ControllerBase
{
    private readonly IProviderService _providerService;

    public ProvidersController(IProviderService providerService)
    {
        _providerService = providerService;
    }

    [HttpGet]
    public IActionResult GetAllProviders()
    {
        var providers = _providerService.GetAllProviders();
        return Ok(providers);
    }

    [HttpGet("{id}")]
    public IActionResult GetProviderDetails(string id)
    {
        var provider = _providerService.GetProviderDetails(id);
        return Ok(provider);
    }
}
