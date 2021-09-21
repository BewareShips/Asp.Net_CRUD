using FirstWebApplication.Data;
using FirstWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApplication.Controllers
{
    public class EmployeerController : Controller
    {
        private readonly EmployeerContext _context;

        public EmployeerController(EmployeerContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employeers.ToListAsync();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Employeer employeer)
        {
            if (ModelState.IsValid)
            {
                _context.Employeers.Add(employeer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(employeer);
        }

        public async Task<IActionResult> Edit(int ? id)
        {
            if(id == null || id <= 0)
            {
                return BadRequest();
            }

            var employeer = await _context.Employeers.FirstOrDefaultAsync(e =>e.Id == id);
            if(employeer == null)
            {
                return NotFound();
            }

            return View(employeer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Employeer employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            _context.Employeers.Update(employee);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }

            var employeer = await _context.Employeers.FirstOrDefaultAsync(e => e.Id == id);
            if (employeer == null)
            {
                return NotFound();
            }

            _context.Employeers.Remove(employeer);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null || id <= 0)
            {
                return BadRequest();
            }
            var employeer = await _context.Employeers.FirstOrDefaultAsync(e => e.Id == id);
            if(employeer == null)
            {
                return NotFound();
            }
            return View(employeer);

        } 
    }
}
