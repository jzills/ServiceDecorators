using Microsoft.AspNetCore.Mvc;
using Source.Services;

namespace Source.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private readonly IApplicationService _service;

    public HomeController(IApplicationService service) => _service = service;

    [HttpGet]
    public IActionResult Get() => Ok(_service.Get(new ApplicationRequest()));
}
