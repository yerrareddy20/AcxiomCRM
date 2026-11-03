using AcxiomCRM.Data;
using AcxiomCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcxiomCRM.Controllers
{
    public class FollowUpsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FollowUpsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string search)
        {
            var followUps = _context.FollowUps.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                followUps = followUps.Where(f =>
                    f.CustomerName.Contains(search) ||
                    f.Subject.Contains(search) ||
                    f.Status.Contains(search));
            }

            return View(await followUps.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FollowUp followUp)
        {
            if (followUp.FollowUpDate.Date < DateTime.Today)
            {
                ModelState.AddModelError(
                    "FollowUpDate",
                    "Follow-up date cannot be in the past.");
            }

            if (ModelState.IsValid)
            {
                _context.FollowUps.Add(followUp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(followUp);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var followUp = await _context.FollowUps.FindAsync(id);

            if (followUp == null) return NotFound();

            return View(followUp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FollowUp followUp)
        {
            if (id != followUp.Id) return NotFound();

            if (followUp.FollowUpDate.Date < DateTime.Today)
            {
                ModelState.AddModelError(
                    "FollowUpDate",
                    "Follow-up date cannot be in the past.");
            }

            if (ModelState.IsValid)
            {
                _context.Update(followUp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(followUp);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var followUp = await _context.FollowUps.FindAsync(id);

            if (followUp == null) return NotFound();

            return View(followUp);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var followUp = await _context.FollowUps.FindAsync(id);

            if (followUp != null)
            {
                _context.FollowUps.Remove(followUp);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}