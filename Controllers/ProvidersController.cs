using Microsoft.AspNetCore.Mvc;
using onepathapi.Services;
using onepathapi.DTOs;
using onepathapi.Models;

[ApiController]
[Route("api/[controller]")]
public class ProvidersController : ControllerBase
{
    private readonly IProviderService _providerService;

    public ProvidersController(IProviderService providerService)
    {
        _providerService = providerService;
    }

    [HttpPost("getProviders")]
    public async Task<IActionResult> GetProviders([FromBody] PaginationRequest request)
    {
        var (providers, totalProviders) = await _providerService.GetProviders(request);

        // Return paginated result along with total patient count
        var result = new
        {
            TotalCount = totalProviders,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            Providers = providers
        };

        return Ok(result);
    }

    [HttpGet("getProvider/{providerId}")]
    public async Task<IActionResult> GetProvider(int providerId)
    {
        Provider provider = await _providerService.GetProvider(providerId);
        if (provider != null)
        {
            return Ok(provider);
        }
        else
        {
            return NotFound();
        }
        
    }
}
