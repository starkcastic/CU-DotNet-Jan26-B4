using Microsoft.AspNetCore.Mvc;
using FinTrackPro.Models;

namespace FinTrackPro.Controllers
{
    public class PortfolioController : Controller
    {
        private static List<Asset> assets = new List<Asset>
        {
            new Asset { Id = 1, Name = "TCS", Value = 3000 },
            new Asset { Id = 2, Name = "Reliance", Value = 2500 }
        };

        public IActionResult Index()
        {
            ViewData["Total"] = assets.Sum(a => a.Value);
            return View(assets);
        }

        [Route("Asset/Info/{id:int}")]
        public IActionResult Details(int id)
        {
            var asset = assets.FirstOrDefault(a => a.Id == id);
            return View(asset);
        }

        public IActionResult Delete(int id)
        {
            var asset = assets.FirstOrDefault(a => a.Id == id);

            if (asset != null)
                assets.Remove(asset);

            TempData["Message"] = "Asset deleted successfully";

            return RedirectToAction("Index");
        }
    }
}