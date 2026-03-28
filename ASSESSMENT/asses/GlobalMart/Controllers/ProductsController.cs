using GlobalMart.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlobalMart.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IPricingService _pricingService;

        // The DI container sees this constructor, reads the parameter type
        // (IPricingService), finds its registered implementation (PricingService),
        // creates it, and passes it in automatically. Zero manual wiring needed.
        public ProductsController(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }

        // GET /Products
        public IActionResult Index()
        {
            // Simulate fetching products from a repository
            var products = GetSampleProducts();

            // Apply promo for the current sale — change WINTER25 to any code;
            // the logic is in one place (PricingService), not scattered here.
            const string currentPromo = "WINTER25";

            var viewModel = products.Select(p => new
            {
                p.Name,
                p.BasePrice,
                DiscountedPrice = _pricingService.CalculateFinalPrice(p.BasePrice, currentPromo),
                PromoApplied = currentPromo
            }).ToList();

            ViewBag.Products = viewModel;
            return View();
        }

        // GET /Products/Details/5?promoCode=FREESHIP
        public IActionResult Details(int id, string? promoCode)
        {
            var products = GetSampleProducts();
            var index = products.FindIndex(p => p.Id == id);
            if (index == -1) return NotFound();

            var product = products[index];

            ViewBag.ProductName  = product.Name;
            ViewBag.BasePrice    = product.BasePrice;
            ViewBag.FinalPrice   = _pricingService.CalculateFinalPrice(product.BasePrice, promoCode);
            ViewBag.PromoApplied = promoCode;
            return View();
        }

        // ── Helpers ─────────────────────────────────────────────────────────
        private static List<(int Id, string Name, decimal BasePrice)> GetSampleProducts() =>
        [
            (1, "Winter Jacket",   89.99m),
            (2, "Thermal Socks",   12.00m),
            (3, "Ski Gloves",      34.50m),
        ];
    }
}
