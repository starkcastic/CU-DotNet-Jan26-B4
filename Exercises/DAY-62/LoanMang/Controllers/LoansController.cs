using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoanMang.Data;
using LoanMang.Models;

namespace LoanMang.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoansController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Loans.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var loan = await _context.Loans.FindAsync(id);
            if (loan == null) return NotFound();
            return Ok(loan);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Loan loan)
        {
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = loan.Id }, loan);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Loan updatedLoan)
        {
            if (id != updatedLoan.Id) return BadRequest();

            var loan = await _context.Loans.FindAsync(id);
            if (loan == null) return NotFound();

            loan.BorrowerName = updatedLoan.BorrowerName;
            loan.Amount = updatedLoan.Amount;
            loan.LoanTermMonths = updatedLoan.LoanTermMonths;
            loan.IsApproved = updatedLoan.IsApproved;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var loan = await _context.Loans.FindAsync(id);
            if (loan == null) return NotFound();

            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}