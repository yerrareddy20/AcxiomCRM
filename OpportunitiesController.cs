
using AcxiomCRM.Data;
using AcxiomCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcxiomCRM.Controllers
{
    public class OpportunitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OpportunitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string search)
        {
            var opportunities = _context.Opportunities.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                opportunities = opportunities.Where(o =>
                    o.Name.Contains(search) ||
                    o.CustomerName.Contains(search) ||
                    o.Status.Contains(search));
            }

            return View(await opportunities.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Opportunity opportunity)
        {
            if (opportunity.Status != "Won" &&
                opportunity.Status != "Lost" &&
                opportunity.ExpectedCloseDate.Date < DateTime.Today)
            {
                ModelState.AddModelError("ExpectedCloseDate",
                    "Expected close date cannot be in the past for an active opportunity.");
            }

            if (ModelState.IsValid)
            {
                _context.Opportunities.Add(opportunity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(opportunity);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var opportunity = await _context.Opportunities.FindAsync(id);
            if (opportunity == null) return NotFound();

            return View(opportunity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Opportunity opportunity)
        {
            if (id != opportunity.Id) return NotFound();

            if (opportunity.Status != "Won" &&
                opportunity.Status != "Lost" &&
                opportunity.ExpectedCloseDate.Date < DateTime.Today)
            {
                ModelState.AddModelError("ExpectedCloseDate",
                    "Expected close date cannot be in the past for an active opportunity.");
            }

            if (ModelState.IsValid)
            {
                _context.Update(opportunity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(opportunity);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var opportunity = await _context.Opportunities.FindAsync(id);
            if (opportunity == null) return NotFound();

            return View(opportunity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var opportunity = await _context.Opportunities.FindAsync(id);

            if (opportunity != null)
            {
                _context.Opportunities.Remove(opportunity);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
