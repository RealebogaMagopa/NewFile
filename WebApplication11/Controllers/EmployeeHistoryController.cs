using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication11.Data;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    public class EmployeeHistoryController : Controller
    {
        private readonly Project2Context _context;

        public EmployeeHistoryController(Project2Context context)
        {
            _context = context;
        }

        // GET: EmployeeHistory
        public async Task<IActionResult> Index()
        {
            var project2Context = _context.EmployeeHistory.Include(e => e.EmployeeNumberNavigation);
            return View(await project2Context.ToListAsync());
        }

        // GET: EmployeeHistory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeHistory = await _context.EmployeeHistory
                .Include(e => e.EmployeeNumberNavigation)
                .FirstOrDefaultAsync(m => m.EmployeeHistoryId == id);
            if (employeeHistory == null)
            {
                return NotFound();
            }

            return View(employeeHistory);
        }

        // GET: EmployeeHistory/Create
        public IActionResult Create()
        {
            ViewData["EmployeeNumber"] = new SelectList(_context.EmployeeDetail, "EmployeeNumber", "Gender");
            return View();
        }

        // POST: EmployeeHistory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeHistoryId,YearsAtCompany,YearsInCurrentRole,YearsSinceLastPromotion,YearsWithCurrManager,EnvironmentSatisfaction,RelationshipSatisfaction,StandardHours,StockOptionLevel,TotalWorkingYears,TrainingTimesLastYear,WorkLifeBalance,PerformanceRating,NumCompaniesWorked,Over18,OverTime,Attrition,BusinessTravel,EmployeeNumber")] EmployeeHistory employeeHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeNumber"] = new SelectList(_context.EmployeeDetail, "EmployeeNumber", "Gender", employeeHistory.EmployeeNumber);
            return View(employeeHistory);
        }

        // GET: EmployeeHistory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeHistory = await _context.EmployeeHistory.FindAsync(id);
            if (employeeHistory == null)
            {
                return NotFound();
            }
            ViewData["EmployeeNumber"] = new SelectList(_context.EmployeeDetail, "EmployeeNumber", "Gender", employeeHistory.EmployeeNumber);
            return View(employeeHistory);
        }

        // POST: EmployeeHistory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeHistoryId,YearsAtCompany,YearsInCurrentRole,YearsSinceLastPromotion,YearsWithCurrManager,EnvironmentSatisfaction,RelationshipSatisfaction,StandardHours,StockOptionLevel,TotalWorkingYears,TrainingTimesLastYear,WorkLifeBalance,PerformanceRating,NumCompaniesWorked,Over18,OverTime,Attrition,BusinessTravel,EmployeeNumber")] EmployeeHistory employeeHistory)
        {
            if (id != employeeHistory.EmployeeHistoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeHistoryExists(employeeHistory.EmployeeHistoryId))
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
            ViewData["EmployeeNumber"] = new SelectList(_context.EmployeeDetail, "EmployeeNumber", "Gender", employeeHistory.EmployeeNumber);
            return View(employeeHistory);
        }

        // GET: EmployeeHistory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeHistory = await _context.EmployeeHistory
                .Include(e => e.EmployeeNumberNavigation)
                .FirstOrDefaultAsync(m => m.EmployeeHistoryId == id);
            if (employeeHistory == null)
            {
                return NotFound();
            }

            return View(employeeHistory);
        }

        // POST: EmployeeHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeHistory = await _context.EmployeeHistory.FindAsync(id);
            _context.EmployeeHistory.Remove(employeeHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeHistoryExists(int id)
        {
            return _context.EmployeeHistory.Any(e => e.EmployeeHistoryId == id);
        }
    }
}
