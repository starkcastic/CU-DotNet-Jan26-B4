using GlobalMart.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlobalMart.Controllers
{
    public class CartController : Controller
    {
        // Identical injection pattern to ProductsController.
        // The DI container provides the SAME Scoped instance that was created
        // for ProductsController within this HTTP request — but even if it
        // creates a fresh one, the logic is identical because it all lives in
        // PricingService, not in either controller.
        private readonly IPricingService _pricingService;

        public CartController(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }

        // GET /Cart
        // The promo code might come from a session, query string, or form post.
        public IActionResult Index(string? promoCode)
        {
            // Simulate cart items from session / database
            var cartItems = GetCartItems();

            // ✅ DRY: the same formula that ran on the Products page runs here.
            // There is ZERO chance of a price mismatch between pages.
            var lineItems = cartItems.Select(item => new
            {
                item.Name,
                item.BasePrice,
                item.Quantity,
                UnitPrice    = _pricingService.CalculateFinalPrice(item.BasePrice, promoCode),
                LineTotal    = _pricingService.CalculateFinalPrice(item.BasePrice, promoCode) * item.Quantity
            }).ToList();

            var orderTotal = lineItems.Sum(li => li.LineTotal);

            ViewBag.LineItems    = lineItems;
            ViewBag.OrderTotal   = orderTotal;
            ViewBag.PromoApplied = promoCode;
            return View();
        }

        // POST /Cart/ApplyPromo
        [HttpPost]
        public IActionResult ApplyPromo(string promoCode)
        {
            // Redirect back to cart with the promo code in the query string.
            // Validation of the code happens inside PricingService — not here.
            return RedirectToAction(nameof(Index), new { promoCode });
        }

        // ── Helpers ─────────────────────────────────────────────────────────
        private static List<(string Name, decimal BasePrice, int Quantity)> GetCartItems() =>
        [
            ("Winter Jacket", 89.99m, 1),
            ("Thermal Socks", 12.00m, 3),
        ];
    }
}
