using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelpingHands.Models;

namespace HelpingHands.Controllers
{
    public class DonationController : Controller
    {
        private readonly HelpinghandsContext _context;

        public DonationController(HelpinghandsContext context)
        {
            _context = context;
        }

        // GET: Donation
        public async Task<IActionResult> Index()
        {
            var donations = await _context.Donations
                .Include(d => d.Donor)
                .Include(d => d.Project)
                .ToListAsync();

            return View(donations);
        }

        // GET: Donation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donation = await _context.Donations
                .Include(d => d.Donor)
                .Include(d => d.Project)
                .FirstOrDefaultAsync(m => m.DonationId == id);
            if (donation == null)
            {
                return NotFound();
            }

            return View(donation);
        }

        // GET: Donation/Create
        public IActionResult Create()
        {
            ViewData["DonorId"] = new SelectList(_context.Donors, "DonorId", "FirstName");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectName");
            return View();
        }

        // POST: Donation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DonationId,DonorId,ProjectId,Amount,DonationDate")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DonorId"] = new SelectList(_context.Donors, "DonorId", "FirstName", donation.DonorId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectName", donation.ProjectId);
            return View(donation);
        }

        // GET: Donation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donation = await _context.Donations
                .Include(d => d.Donor)
                .Include(d => d.Project)
                .FirstOrDefaultAsync(m => m.DonationId == id);

            if (donation == null)
            {
                return NotFound();
            }

            ViewData["DonorId"] = new SelectList(_context.Donors, "DonorId", "FirstName", donation.DonorId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectName", donation.ProjectId);
            return View(donation);
        }

        // POST: Donation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DonationId,DonorId,ProjectId,Amount,DonationDate")] Donation donation)
        {
            if (id != donation.DonationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonationExists(donation.DonationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["DonorId"] = new SelectList(_context.Donors, "DonorId", "FirstName", donation.DonorId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectName", donation.ProjectId);
            return View(donation);
        }

        // GET: Donation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donation = await _context.Donations
                .Include(d => d.Donor)
                .Include(d => d.Project)
                .FirstOrDefaultAsync(m => m.DonationId == id);

            if (donation == null)
            {
                return NotFound();
            }

            return View(donation);
        }

        // POST: Donation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donation = await _context.Donations.FindAsync(id);
            if (donation != null)
            {
                _context.Donations.Remove(donation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonationExists(int id)
        {
            return _context.Donations.Any(e => e.DonationId == id);
        }
    }
}
