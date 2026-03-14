using Microsoft.AspNetCore.Mvc;
using FinTrackPro.Data;
using FinTrackPro.Models;

namespace FinTrackPro.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var accounts = _context.Accounts.ToList();
            return View(accounts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Account account)
        {
            if (ModelState.IsValid)
            {
                _context.Accounts.Add(account);
                _context.SaveChanges();

                TempData["Success"] = "Account created successfully!";
                return RedirectToAction("Index");
            }

            return View(account);
        }
    }
}