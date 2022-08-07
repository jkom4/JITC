using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JITC.Models;
using JITC.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace JITC.Controllers
{
    [Authorize]
    public class ReservationsController : Controller
    {
        private readonly JITCDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public ReservationsController(JITCDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            var reservation = await _context.Reservation.Include(r => r.vol).Where(r => r.UserId ==_userManager.GetUserId(User)).ToListAsync();
            var vol = await _context.Vol
               .Include(v => v.AeroportArrive)
               .Include(v => v.AeroportDepart)
               .Include(v => v.Appareil)
               .Include(v => v.Pilote)
               .ToListAsync();

            var viewModel = new VolViewModel();
            viewModel.vols = vol;
            viewModel.Reservations = reservation;
            return View(viewModel);
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reservation == null)
            {
                return NotFound();
            }
            var reservation = await _context.Reservation
                .Include(r => r.vol)
                .FirstOrDefaultAsync(m => m.Id == id);
            var vol = await _context.Vol
                .Include(v => v.AeroportArrive)
                .Include(v => v.AeroportDepart)
                .Include(v => v.Appareil)
                .Include(v => v.Pilote)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null || vol == null)
            {
                return NotFound();
            }
            var viewModel = new VolViewModel();
            viewModel.IdVol = vol.Id;
            viewModel.Appareil = vol.Appareil;
            viewModel.NombrePlace = vol.NombrePlace;
            viewModel.Depart = vol.AeroportDepart;
            viewModel.Arrive = vol.AeroportArrive;
            viewModel.DepartPrevue = vol.HeureDepartPrevue;
            viewModel.ArrivePrevue = vol.HeureArrivePrevue;
            viewModel.Reservation = reservation;
            return View(viewModel);
        }

        // GET: Reservations/Create
        public async Task<IActionResult> CreateAsync(int? id)
        {
            if (id == null || _context.Vol == null)
            {
                return NotFound();
            }

            var vol = await _context.Vol
                .Include(v => v.AeroportArrive)
                .Include(v => v.AeroportDepart)
                .Include(v => v.Appareil)
                .Include(v => v.Pilote)
                .Include(v => v.Reservations)
                .FirstOrDefaultAsync(m => m.Id == id);
            ViewData["volId"] = new SelectList(_context.Vol, "Id", "Id");
            var nbreOccupe = 0;
            foreach (var reser in vol.Reservations)
            {
                nbreOccupe += reser.place;
            }

            var nbreDispo = vol.NombrePlace - nbreOccupe;
            var reservation = new Reservation();
            reservation.volId = id;
            reservation.vol = vol;
            var viewModel = new VolViewModel();
            viewModel.NombrePlaceDispo = nbreDispo;
            viewModel.Reservation = reservation;
            return View(viewModel);
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("volId,place")] Reservation reservation)
        {
            var vol = await _context.Vol
                .Include(v => v.AeroportArrive)
                .Include(v => v.AeroportDepart)
                .Include(v => v.Appareil)
                .Include(v => v.Pilote)
                .Include(v => v.Reservations)
                .FirstOrDefaultAsync(v => v.Id == reservation.volId);
            var nbreOccupe = 0;
            foreach (var reser in vol.Reservations)
            {
                nbreOccupe += reser.place;
            }

            var nbreDispo = vol.NombrePlace - nbreOccupe;
            if (ModelState.IsValid)
            {
                reservation.UserId = _userManager.GetUserId(User);
               

                if (nbreDispo >= reservation.place)
                {
                    _context.Add(reservation);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "Le nombre de place n'est pas disponible");
                }
               
            }
            
            reservation.volId = vol.Id;
            reservation.vol = vol;
            var viewModel = new VolViewModel();
            viewModel.NombrePlaceDispo = nbreDispo;
            viewModel.Reservation = reservation;
            return View(viewModel);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reservation == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            ViewData["volId"] = new SelectList(_context.Vol, "Id", "Id", reservation.volId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,volId,place")] Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.Id))
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
            ViewData["volId"] = new SelectList(_context.Vol, "Id", "Id", reservation.volId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reservation == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation
                .Include(r => r.vol)
                .FirstOrDefaultAsync(m => m.Id == id);
            var vol = await _context.Vol
               .Include(v => v.AeroportArrive)
               .Include(v => v.AeroportDepart)
               .Include(v => v.Appareil)
               .Include(v => v.Pilote)
               .Include(v => v.Reservations)
               .FirstOrDefaultAsync(m => m.Id == reservation.volId);
            if (reservation == null || vol == null)
            {
                return NotFound();
            }
            VolViewModel viewModel = CreateViewModel(reservation, vol);

            return View(viewModel);
        }

        private static VolViewModel CreateViewModel(Reservation? reservation, Vol? vol)
        {
            var viewModel = new VolViewModel();
            viewModel.IdVol = vol.Id;
            viewModel.Appareil = vol.Appareil;
            viewModel.NombrePlace = vol.NombrePlace;
            viewModel.Depart = vol.AeroportDepart;
            viewModel.Arrive = vol.AeroportArrive;
            viewModel.DepartPrevue = vol.HeureDepartPrevue;
            viewModel.ArrivePrevue = vol.HeureArrivePrevue;
            viewModel.DepartReelle = vol.HeureDepartReelle;
            viewModel.ArriveReelle = vol.HeureArriveReelle;
            viewModel.Reservation = reservation;
            return viewModel;
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Reservation == null)
            {
                return Problem("Entity set 'JITCDbContext.Reservation'  is null.");
            }
            var reservation = await _context.Reservation.Include(r => r.vol).FirstAsync(r => r.Id == id);
            if (reservation != null && (DateTime.Now.AddDays(1) <= reservation.vol.HeureDepartPrevue))
            {
                _context.Reservation.Remove(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                

                
                var vol = await _context.Vol
                   .Include(v => v.AeroportArrive)
                   .Include(v => v.AeroportDepart)
                   .Include(v => v.Appareil)
                   .Include(v => v.Pilote)
                   .Include(v => v.Reservations)
                   .FirstOrDefaultAsync(m => m.Id == reservation.volId);
                if (reservation == null || vol == null)
                {
                    return NotFound();
                }
                VolViewModel viewModel = CreateViewModel(reservation, vol);
                ViewBag.Problem = "Vous ne pouvez pas annuler a moins de 24H";
                return View(viewModel);
                
            }
            
        }

        private bool ReservationExists(int? id)
        {
          return (_context.Reservation?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
