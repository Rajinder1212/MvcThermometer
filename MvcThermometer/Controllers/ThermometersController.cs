using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcThermometer.Data;
using MvcThermometer.Models;

namespace MvcThermometer.Controllers
{
    public class ThermometersController : Controller
    {
        private readonly MvcThermometerContext _context;

        public ThermometersController(MvcThermometerContext context)
        {
            _context = context;
        }

        // GET: Thermometers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Thermometer.ToListAsync());
        }

        // GET: Thermometers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thermometer = await _context.Thermometer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thermometer == null)
            {
                return NotFound();
            }

            return View(thermometer);
        }

        // GET: Thermometers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Thermometers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Features,Celcious,Fahrenheit,Price,Type")] Thermometer thermometer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thermometer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thermometer);
        }

        // GET: Thermometers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thermometer = await _context.Thermometer.FindAsync(id);
            if (thermometer == null)
            {
                return NotFound();
            }
            return View(thermometer);
        }

        // POST: Thermometers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Features,Celcious,Fahrenheit,Price,Type")] Thermometer thermometer)
        {
            if (id != thermometer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thermometer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThermometerExists(thermometer.Id))
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
            return View(thermometer);
        }

        // GET: Thermometers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thermometer = await _context.Thermometer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thermometer == null)
            {
                return NotFound();
            }

            return View(thermometer);
        }

        // POST: Thermometers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thermometer = await _context.Thermometer.FindAsync(id);
            _context.Thermometer.Remove(thermometer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThermometerExists(int id)
        {
            return _context.Thermometer.Any(e => e.Id == id);
        }
    }
}
