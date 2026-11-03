using AcxiomCRM.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcxiomCRM.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TotalCustomers = await _context.Customers.CountAsync();

            ViewBag.TotalLeads = await _context.Leads.CountAsync();

            ViewBag.TotalOpportunities =
                await _context.Opportunities.CountAsync();

            ViewBag.PendingFollowUps =
                await _context.FollowUps
                    .CountAsync(f => f.Status == "Pending");

            ViewBag.WonOpportunities =
                await _context.Opportunities
                    .CountAsync(o => o.Status == "Won");

            ViewBag.LostOpportunities =
                await _context.Opportunities
                    .CountAsync(o => o.Status == "Lost");

            ViewBag.OpenOpportunities =
                await _context.Opportunities
                    .CountAsync(o => o.Status == "Open");

            ViewBag.NewLeads =
                await _context.Leads
                    .CountAsync(l => l.Status == "New");

            ViewBag.ContactedLeads =
                await _context.Leads
                    .CountAsync(l => l.Status == "Contacted");

            ViewBag.QualifiedLeads =
                await _context.Leads
                    .CountAsync(l => l.Status == "Qualified");

            ViewBag.ConvertedLeads =
                await _context.Leads
                    .CountAsync(l => l.Status == "Converted");

            ViewBag.LostLeads =
                await _context.Leads
                    .CountAsync(l => l.Status == "Lost");

            return View();
        }
    }
}