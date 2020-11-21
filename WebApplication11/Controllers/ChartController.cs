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
    public class ChartController : Controller
    {
        private readonly Project2Context _context;

        public ChartController(Project2Context context)
        {
            _context = context;
        }

        // GET: Chart
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeDetail.ToListAsync());
        }

        // GET: Chart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDetail = await _context.EmployeeDetail
                .FirstOrDefaultAsync(m => m.EmployeeNumber == id);
            if (employeeDetail == null)
            {
                return NotFound();
            }

            return View(employeeDetail);
        }

        // GET: Chart/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeNumber,Age,Gender,MaritalStatus,EmployeeCount")] EmployeeDetail employeeDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeDetail);
        }

        // GET: Chart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDetail = await _context.EmployeeDetail.FindAsync(id);
            if (employeeDetail == null)
            {
                return NotFound();
            }
            return View(employeeDetail);
        }

        // POST: Chart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeNumber,Age,Gender,MaritalStatus,EmployeeCount")] EmployeeDetail employeeDetail)
        {
            if (id != employeeDetail.EmployeeNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeDetailExists(employeeDetail.EmployeeNumber))
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
            return View(employeeDetail);
        }

        // GET: Chart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDetail = await _context.EmployeeDetail
                .FirstOrDefaultAsync(m => m.EmployeeNumber == id);
            if (employeeDetail == null)
            {
                return NotFound();
            }

            return View(employeeDetail);
        }

        // POST: Chart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeDetail = await _context.EmployeeDetail.FindAsync(id);
            _context.EmployeeDetail.Remove(employeeDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeDetailExists(int id)
        {
            return _context.EmployeeDetail.Any(e => e.EmployeeNumber == id);
        }
    }
}
