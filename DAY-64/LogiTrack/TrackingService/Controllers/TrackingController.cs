using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TrackingService.Controllers;

[ApiController]
[Route("api/tracking")]
public class TrackingController : ControllerBase
{
    [HttpGet("gps")]
    [Authorize(Roles = "Manager")]   // Only Managers allowed
    public IActionResult GetGpsHistory()
    {
        var data = new[]
        {
            new { TruckId = "TRK-001", Lat = 28.7041, Lon = 77.1025, Time = "2025-01-10 08:00" },
            new { TruckId = "TRK-002", Lat = 19.0760, Lon = 72.8777, Time = "2025-01-10 09:15" }
        };
        return Ok(data);
    }
}