using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JITC.Models;

namespace JITC.Controllers
{
    public class AppareilsController : Controller
    {
        private readonly JITCDbContext _context;

        public AppareilsController(JITCDbContext context)
        {
            _context = context;
        }

        // GET: Appareils
        public async Task<IActionResult> Index()
        {
            RefreshStatut();
            
              return _context.Appareil != null ? 
                          View(await _context.Appareil.Include(a=> a.Vols).ToListAsync()) :
                          Problem("Entity set 'JITCDbContext.Appareil'  is null.");
        }

        private void RefreshStatut()
        {
            if (_context.Appareil != null) {
                foreach( var appareil in  _context.Appareil.Include(a => a.Vols).ToList())
                {
                    if (appareil.Vols.Count % 5 == 0 && appareil.Vols.Count != 0)
                    {
                        appareil.Statut = true;
                    }
                   
                }
            }
        }

        // GET: Appareils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Appareil == null)
            {
                return NotFound();
            }

            var appareil = await _context.Appareil
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appareil == null)
            {
                return NotFound();
            }

            return View(appareil);
        }

        // GET: Appareils/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Appareils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Description,Capacite_Cab,Vitesse,Moteur,Statut")] Appareil appareil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appareil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appareil);
        }

        // GET: Appareils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Appareil == null)
            {
                return NotFound();
            }

            var appareil = await _context.Appareil.FindAsync(id);
            if (appareil == null)
            {
                return NotFound();
            }
            return View(appareil);
        }

        // POST: Appareils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Description,Capacite_Cab,Vitesse,Moteur,Statut")] Appareil appareil)
        {
            if (id != appareil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appareil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppareilExists(appareil.Id))
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
            return View(appareil);
        }

        // GET: Appareils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Appareil == null)
            {
                return NotFound();
            }

            var appareil = await _context.Appareil
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appareil == null)
            {
                return NotFound();
            }

            return View(appareil);
        }

        // POST: Appareils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Appareil == null)
            {
                return Problem("Entity set 'JITCDbContext.Appareil'  is null.");
            }
            var appareil = await _context.Appareil.FindAsync(id);
            if (appareil != null)
            {
                _context.Appareil.Remove(appareil);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ChangerStatut(int? id)
        {
            if (id == null || _context.Appareil == null)
            {
                return NotFound();
            }

            RefreshStatut();
            Appareil appareil = await _context.Appareil.Where(a => a.Id == id).Include(a => a.Vols).FirstAsync();
            appareil.Statut = false;

            return _context.Appareil != null ?
                        View("index",await _context.Appareil.Include(a => a.Vols).ToListAsync()) :
                        Problem("Entity set 'JITCDbContext.Appareil'  is null.");
        }

        private bool AppareilExists(int id)
        {
          return (_context.Appareil?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
