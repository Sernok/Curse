using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using MyProject.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Controllers
{
    public class OtherCompaniesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OtherCompaniesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ExternalManagementCompanies.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExternalManagementCompany company)
        {
            if (ModelState.IsValid)
            {
                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var company = await _context.ExternalManagementCompanies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ExternalManagementCompany company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
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
            return View(company);
        }

public async Task<IActionResult> Delete(int id)
{
    var company = await _context.ExternalManagementCompanies.FindAsync(id);
    if (company == null)
    {
        return NotFound();
    }

    // Check if the company is associated with any house
    bool isAssociatedWithHouse = await _context.Houses.AnyAsync(h => h.ExternalManagementCompanyId == id);
    if (isAssociatedWithHouse)
    {
        TempData["ErrorMessage"] = "Данная компания обслуживает один из домов, удаление невозможно.";
    }

    return View(company);
}

[HttpPost, ActionName("Delete")]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    var company = await _context.ExternalManagementCompanies.FindAsync(id);
    if (company == null)
    {
        return NotFound();
    }

    _context.ExternalManagementCompanies.Remove(company);
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
}


        private bool CompanyExists(int id)
        {
            return _context.ExternalManagementCompanies.Any(e => e.Id == id);
        }
    }
}
