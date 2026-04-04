using Microsoft.AspNetCore.Mvc;
using Vagabond.MVC.Services;

namespace Vagabond.MVC.Controllers;

public class TravelController : Controller
{
    private readonly IDestinationService _service;

    public TravelController(IDestinationService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var destinations = await _service.GetAllAsync();
        return View(destinations);
    }
}