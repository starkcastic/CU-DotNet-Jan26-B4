using Microsoft.AspNetCore.Mvc;

namespace FinTrackPro.Controllers
{
    public class MarketController : Controller
    {
        public IActionResult Summary()
        {
            ViewBag.Status = "Market Open";

            ViewData["TopGainer"] = "Infosys";
            ViewData["Volume"] = 2000000L;

            return View();
        }

        [HttpGet("Analyze/{ticker}/{days:int?}")]
        public IActionResult Analyze(string ticker, int? days)
        {
            int d = days ?? 30;

            ViewBag.Ticker = ticker;
            ViewBag.Days = d;

            return View();
        }
    }
}