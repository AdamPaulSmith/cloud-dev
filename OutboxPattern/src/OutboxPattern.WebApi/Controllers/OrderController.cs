using Microsoft.AspNetCore.Mvc;
using OutboxPattern.WebApi.Models;

namespace OutboxPattern.WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;

    public OrderController(ILogger<OrderController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public IActionResult Post(SubmitOrderModel model)
    {
        return Ok();
    }
}