using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using MyProject.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Controllers
{
    public class HousesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HousesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var houses = await _context.Houses
                .Include(h => h.ExternalManagementCompany)
                .ToListAsync();
            return View(houses);
        }

        public IActionResult Create()
        {
            // Передаем в представление список всех сторонних управляющих компаний
            ViewData["ExternalManagementCompanies"] = new SelectList(_context.ExternalManagementCompanies, "Id", "CompanyName");
            return View();
        }

[HttpPost]
public async Task<IActionResult> Create(House house)
{
    if (ModelState.IsValid)
    {
        // If the house is managed by us, set the external management company ID to null
        if (house.IsManagedByUs)
        {
            house.ExternalManagementCompanyId = null;
        }
        // If the house is associated with another company and also managed by us, remove the association with the other company
        else if (house.ExternalManagementCompanyId != null)
        {
            var associatedHouse = await _context.Houses.FirstOrDefaultAsync(h => h.ExternalManagementCompanyId == house.ExternalManagementCompanyId);
            if (associatedHouse != null)
            {
                associatedHouse.ExternalManagementCompanyId = null;
                _context.Update(associatedHouse);
            }
        }

        _context.Add(house);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // In case of errors, pass the list of all external management companies to the view
    ViewData["ExternalManagementCompanies"] = new SelectList(_context.ExternalManagementCompanies, "Id", "CompanyName", house.ExternalManagementCompanyId);
    return View(house);
}


        public async Task<IActionResult> Edit(int id)
        {
            var house = await _context.Houses.FindAsync(id);
            if (house == null)
            {
                return NotFound();
            }
            // Если у дома нет связанной сторонней управляющей компании, добавляем ее в список выбора
            if (house.ExternalManagementCompanyId != null && !_context.ExternalManagementCompanies.Any(c => c.Id == house.ExternalManagementCompanyId))
            {
                ViewData["ExternalManagementCompanyId"] = new SelectList(_context.ExternalManagementCompanies.Append(house.ExternalManagementCompany), "Id", "CompanyName", house.ExternalManagementCompanyId);
            }
            else
            {
                ViewData["ExternalManagementCompanyId"] = new SelectList(_context.ExternalManagementCompanies, "Id", "CompanyName", house.ExternalManagementCompanyId);
            }
            return View(house);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, House house)
        {
            if (id != house.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Если сторонняя управляющая компания не выбрана, устанавливаем значение null
                    if (house.ExternalManagementCompanyId == 0)
                    {
                        house.ExternalManagementCompanyId = null;
                    }

                    _context.Update(house);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HouseExists(house.Id))
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
            // Если у дома нет связанной сторонней управляющей компании, добавляем ее в список выбора
            if (house.ExternalManagementCompanyId != null && !_context.ExternalManagementCompanies.Any(c => c.Id == house.ExternalManagementCompanyId))
            {
                ViewData["ExternalManagementCompanyId"] = new SelectList(_context.ExternalManagementCompanies.Append(house.ExternalManagementCompany), "Id", "CompanyName", house.ExternalManagementCompanyId);
            }
            else
            {
                ViewData["ExternalManagementCompanyId"] = new SelectList(_context.ExternalManagementCompanies, "Id", "CompanyName", house.ExternalManagementCompanyId);
            }
            return View(house);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var house = await _context.Houses
                .Include(h => h.ExternalManagementCompany)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (house == null)
            {
                return NotFound();
            }

            // Check if the house is referenced in any HouseRequests
            bool isReferenced = await _context.RequestJournals.AnyAsync(hr => hr.HouseId == id);
            ViewData["IsReferenced"] = isReferenced;

            return View(house);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var house = await _context.Houses.FindAsync(id);
            if (house == null)
            {
                return NotFound();
            }

            // Check if the house is referenced in any HouseRequests
            bool isReferenced = await _context.RequestJournals.AnyAsync(hr => hr.HouseId == id);

            if (isReferenced)
            {
                TempData["ErrorMessage"] = "Данный дом используется в заявке, удаление невозможно.";
                return RedirectToAction(nameof(Index));
            }

            _context.Houses.Remove(house);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HouseExists(int id)
        {
            return _context.Houses.Any(e => e.Id == id);
        }
    }
}
