﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Data;
using MVC_Project.Models;

namespace MVC_Project.Controllers
{
    public class DepartamentsController : Controller
    {
        private readonly MVC_ProjectContext _context;

        public DepartamentsController(MVC_ProjectContext context)
        {
            _context = context;
        }

        // GET: Departaments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Departaments.ToListAsync());
        }

        // GET: Departaments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departaments = await _context.Departaments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departaments == null)
            {
                return NotFound();
            }

            return View(departaments);
        }

        // GET: Departaments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departaments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Departaments departaments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departaments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departaments);
        }

        // GET: Departaments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departaments = await _context.Departaments.FindAsync(id);
            if (departaments == null)
            {
                return NotFound();
            }
            return View(departaments);
        }

        // POST: Departaments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Departaments departaments)
        {
            if (id != departaments.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departaments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentsExists(departaments.Id))
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
            return View(departaments);
        }

        // GET: Departaments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departaments = await _context.Departaments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departaments == null)
            {
                return NotFound();
            }

            return View(departaments);
        }

        // POST: Departaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departaments = await _context.Departaments.FindAsync(id);
            if (departaments != null)
            {
                _context.Departaments.Remove(departaments);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartamentsExists(int id)
        {
            return _context.Departaments.Any(e => e.Id == id);
        }
    }
}
