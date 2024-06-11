using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using MyProject.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Controllers
{
    public class ExecutorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExecutorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Executors.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Executor executor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(executor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(executor);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var executor = await _context.Executors.FindAsync(id);
            if (executor == null)
            {
                return NotFound();
            }
            return View(executor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Executor executor)
        {
            if (id != executor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(executor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExecutorExists(executor.Id))
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
            return View(executor);
        }

public async Task<IActionResult> Delete(int id)
{
    var executor = await _context.Executors.FirstOrDefaultAsync(m => m.Id == id);
    if (executor == null)
    {
        return NotFound();
    }

    bool isReferenced = await _context.RequestJournals.AnyAsync(rj => rj.ExecutorId == id);
    ViewData["IsReferenced"] = isReferenced;

    return View(executor);
}

      [HttpPost, ActionName("Delete")]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    var executor = await _context.Executors.FindAsync(id);
    if (executor == null)
    {
        return NotFound();
    }

    bool isReferenced = await _context.RequestJournals.AnyAsync(rj => rj.ExecutorId == id);

    if (isReferenced)
    {
        TempData["ErrorMessage"] = "Данный исполнитель используется в заявке, удаление невозможно.";
        return RedirectToAction(nameof(Index));
    }

    _context.Executors.Remove(executor);
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
}

        private bool ExecutorExists(int id)
        {
            return _context.Executors.Any(e => e.Id == id);
        }
    }
}
