namespace s20522_SejmAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using s20522_SejmAPI.DTOs;
using s20522_SejmAPI.Services;

[ApiController]
[Route("politycy")]
public class PolitycyController : ControllerBase
{
    private readonly IPolitykService _politykService;
    private readonly ILogger<PolitycyController> _logger;

    public PolitycyController(IPolitykService politykService, ILogger<PolitycyController> logger)
    {
        _politykService = politykService;
        _logger = logger;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PolitykGetDto>))]
    public async Task<IActionResult> GetPolitycy()
    {
        _logger.LogInformation("Otrzymano żądanie GET /politycy");
        var politycy = await _politykService.GetAllPolitycyAsync();
        return Ok(politycy);
    }
    
}