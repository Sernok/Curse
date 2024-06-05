using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using MyProject.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Controllers
{
    public class RequestJournalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RequestJournalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var requestJournals = await _context.RequestJournals
                .Include(r => r.House)
                .Include(r => r.Executor)
                .Include(r => r.RequestStatus)
                .Include(r => r.RequestType)
                .ToListAsync();
            return View(requestJournals);
        }

        public IActionResult Create()
        {
            ViewData["HouseId"] = new SelectList(_context.Houses, "Id", "Id");
            ViewData["ExecutorId"] = new SelectList(_context.Executors, "Id", "Id");
            ViewData["RequestTypeId"] = new SelectList(_context.RequestTypes, "Id", "TypeName");
            ViewData["RequestStatusId"] = new SelectList(_context.RequestStatuses, "Id", "StatusName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RequestJournal requestJournal)
        {
            _context.Add(requestJournal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestJournal = await _context.RequestJournals.FindAsync(id);
            if (requestJournal == null)
            {
                return NotFound();
            }

            PopulateSelectLists(requestJournal);
            return View(requestJournal);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, RequestJournal requestJournal)
        {
            if (id != requestJournal.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(requestJournal);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestJournalExists(requestJournal.Id))
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


        public async Task<IActionResult> Delete(int id)
        {
            var requestJournal = await _context.RequestJournals.FindAsync(id);
            if (requestJournal == null)
            {
                return NotFound();
            }
            return View(requestJournal);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requestJournal = await _context.RequestJournals.FindAsync(id);
            if (requestJournal == null)
            {
                return NotFound();
            }
            _context.RequestJournals.Remove(requestJournal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestJournalExists(int id)
        {
            return _context.RequestJournals.Any(e => e.Id == id);
        }

        private void PopulateSelectLists(RequestJournal requestJournal = null)
        {
            ViewData["HouseId"] = new SelectList(_context.Houses, "Id", "Id", requestJournal?.HouseId);
            ViewData["ExecutorId"] = new SelectList(_context.Executors, "Id", "Id", requestJournal?.ExecutorId);
            ViewData["RequestStatusId"] = new SelectList(_context.RequestStatuses, "Id", "StatusName", requestJournal?.RequestStatusId);
            ViewData["RequestTypeId"] = new SelectList(_context.RequestTypes, "Id", "TypeName", requestJournal?.RequestTypeId);
        }
    }
}
