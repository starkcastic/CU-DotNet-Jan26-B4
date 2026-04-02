using Microsoft.AspNetCore.Mvc;
using QuickLoanApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace QuickLoanApp.Controllers
{
    public class LoanController : Controller
    {
        public static List<Loan> loans = new List<Loan>();
        public static int nextId = 1;

        public IActionResult Index()
        {
            return View(loans);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Loan loan)
        {
            if (ModelState.IsValid)
            {
                loan.Id = nextId++;
                loans.Add(loan);
                return RedirectToAction("Index");
            }
            return View(loan);
        }

        public IActionResult Edit(int id)
        {
            var loan = loans.Find(x => x.Id == id);
            if (loan == null)
                return NotFound();

            return View(loan);
        }

        [HttpPost]
        public IActionResult Edit(Loan updatedLoan)
        {
            if (ModelState.IsValid)
            {
                var loan = loans.Find(x => x.Id == updatedLoan.Id);
                if (loan == null)
                    return NotFound();

                loan.BorrowerName = updatedLoan.BorrowerName;
                loan.LenderName = updatedLoan.LenderName;
                loan.Amount = updatedLoan.Amount;
                loan.IsSettled = updatedLoan.IsSettled;

                return RedirectToAction("Index");
            }
            return View(updatedLoan);
        }

        // public IActionResult Delete(int id)
        // {
        //     var loan = loans.Find(x => x.Id == id);
        //     if (loan != null)
        //         loans.Remove(loan);

        //     return RedirectToAction("Index");
        // }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var loan = loans.Find(x => x.Id == id);
            if (loan != null)
                loans.Remove(loan);

            return RedirectToAction("Index");
        }
    }
}