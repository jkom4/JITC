using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JITC.Models;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;
using System.Text.Json.Serialization;
using JITC.Models.ViewModels;

namespace JITC.Controllers
{
    public class VolsController : Controller
    {
        private readonly JITCDbContext _context;

        public VolsController(JITCDbContext context)
        {
            _context = context;
        }

        // GET: Vols
        public async Task<IActionResult> Index()
        {
            var jITCDbContext = _context.Vol.Include(v => v.AeroportArrive).Include(v => v.AeroportDepart).Include(v => v.Appareil).Include(v => v.Pilote);
            return View(await jITCDbContext.ToListAsync());
        }

        // GET: Vols/Details/5
        public async Task<IActionResult> Details(int? id)
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
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vol == null)
            {
                return NotFound();
            }

            return View(vol);
        }

        // GET: Vols/Create
        [Authorize(Roles = "Responsable")]
        public IActionResult Create()
        {
            ViewData["AeroportArriveId"] = new SelectList(_context.Aeroport, "Id", "Nom");
            ViewData["AeroportDepartId"] = new SelectList(_context.Aeroport, "Id", "Nom");
            ViewData["AppareilId"] = new SelectList(_context.Appareil, "Id", "Nom");
            ViewData["PiloteId"] = new SelectList(_context.Users
                .Join(_context.UserRoles,u => u.Id,
                ur => ur.UserId,(u, ur) => new { Id = u.Id,
                                                 Name = u.Name,
                                                 Firstname = u.Firstname,
                                                 RoleId = ur.RoleId})
                .Join(_context.Roles,x => x.RoleId,r => r.Id, (x, r) => new { 
                                Id = x.Id,
                                Name = x.Name,
                                Firstname = x.Firstname,
                                RoleName = r.Name})
                                                .Where(x => x.RoleName == "Pilote"), "Id", "Name");
            return View();
        }   

        // POST: Vols/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Responsable")]
        public async Task<IActionResult> Create([Bind("Id,AeroportDepartId,AeroportArriveId,NombrePlace,HeureDepartPrevue,HeureArrivePrevue,HeureDepartReelle,HeureArriveReelle,PiloteId,Distance,AppareilId,Recurrence,Retard,Raison")] Vol vol)
        {
            if (vol.AeroportDepartId == vol.AeroportArriveId) {
                ModelState.AddModelError("", "l'aeroport de départ doit être différent de celui d'arrivé");
            }
            else if (vol.HeureDepartPrevue < DateTime.Now || vol.HeureArrivePrevue <= vol.HeureDepartPrevue)
            {
                ModelState.AddModelError("", "La date d'arrivé doit être superieure a celui de départ et la date courante");
            }
            else if (ModelState.IsValid)
            {

                Aeroport Depart = await _context.Aeroport.Where(a => a.Id == vol.AeroportDepartId).FirstOrDefaultAsync();
                Aeroport Arrive = await _context.Aeroport.Where(a => a.Id == vol.AeroportArriveId).FirstOrDefaultAsync();
                vol.Distance = getDistanceFromLatLonInKm(Depart.Latitude, Depart.Longitude, Arrive.Latitude, Arrive.Longitude);
                ModifVol modifVol = new ModifVol();
                VolViewModel volViewModel = CreateViewModel(vol,_context);

                modifVol.VolModifs.Add(CreateModifObject(volViewModel));
                vol.ModifVol = modifVol;
                _context.Add(modifVol);
                _context.Add(vol);


                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AeroportArriveId"] = new SelectList(_context.Aeroport, "Id", "Nom", vol.AeroportArriveId);
            ViewData["AeroportDepartId"] = new SelectList(_context.Aeroport, "Id", "Nom", vol.AeroportDepartId);
            ViewData["AppareilId"] = new SelectList(_context.Appareil, "Id", "Nom", vol.AppareilId);
            ViewData["PiloteId"] = new SelectList(_context.Users
                .Join(_context.UserRoles, u => u.Id,
                ur => ur.UserId, (u, ur) => new {
                    Id = u.Id,
                    Name = u.Name,
                    Firstname = u.Firstname,
                    RoleId = ur.RoleId
                })
                .Join(_context.Roles, x => x.RoleId, r => r.Id, (x, r) => new {
                    Id = x.Id,
                    Name = x.Name,
                    Firstname = x.Firstname,
                    RoleName = r.Name
                })
                                                .Where(x => x.RoleName == "Pilote"), "Id", "Name", vol.PiloteId);
            return View(vol);
        }

        private static  VolViewModel CreateViewModel(Vol vol,JITCDbContext context)
        {
            VolViewModel volViewModel = new VolViewModel();
            volViewModel.IdVol = vol.Id;
            volViewModel.Depart =  context.Aeroport.Find(vol.AeroportDepartId);
            volViewModel.Arrive = context.Aeroport.Find(vol.AeroportArriveId);
            volViewModel.DepartPrevue = vol.HeureDepartPrevue;
            volViewModel.ArrivePrevue = vol.HeureArrivePrevue;
            volViewModel.NombrePlace = vol.NombrePlace;
            volViewModel.Pilote = context.Users.Find(vol.PiloteId);
            volViewModel.Appareil = context.Appareil.Find(vol.AppareilId);
            volViewModel.Recurrence = vol.Recurrence;
            return volViewModel;
        }

        private string CreateModifObject(VolViewModel vol)
        {
           return JsonSerializer.Serialize(vol);
        }

        // GET: Vols/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vol == null)
            {
                return NotFound();
            }

            var vol = await _context.Vol.FindAsync(id);
            if (vol == null)
            {
                return NotFound();
            }

            ViewData["AeroportArriveId"] = new SelectList(_context.Aeroport, "Id", "Nom", vol.AeroportArriveId);
            ViewData["AeroportDepartId"] = new SelectList(_context.Aeroport, "Id", "Nom", vol.AeroportDepartId);
            ViewData["AppareilId"] = new SelectList(_context.Appareil, "Id", "Nom", vol.AppareilId);
            ViewData["PiloteId"] = new SelectList(_context.Users
                .Join(_context.UserRoles, u => u.Id,
                ur => ur.UserId, (u, ur) => new {
                    Id = u.Id,
                    Name = u.Name,
                    Firstname = u.Firstname,
                    RoleId = ur.RoleId
                })
                .Join(_context.Roles, x => x.RoleId, r => r.Id, (x, r) => new {
                    Id = x.Id,
                    Name = x.Name,
                    Firstname = x.Firstname,
                    RoleName = r.Name
                })
                                                .Where(x => x.RoleName == "Pilote"), "Id", "Firstname", vol.PiloteId);
     
            return View(vol);
        }

        // POST: Vols/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AeroportDepartId,AeroportArriveId,NombrePlace,HeureDepartPrevue,HeureArrivePrevue,HeureDepartReelle,HeureArriveReelle,PiloteId,Distance,AppareilId,Recurrence,Retard,Raison,ModifVolId")] Vol vol)
        {
            if (id != vol.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               
                //var volDb = _context.Vol.Where(v => v.Id == id).Include(v => v.ModifVol).First();
                //vol.ModifVol = volDb.ModifVol;
                try
                {
                    // vol.ModifVol.Vols.Add(vol);
                    _context.Update(vol);
                    var modifVol = await _context.ModifVol.FindAsync(vol.ModifVolId);
                    VolViewModel volViewModel = CreateViewModel(vol, _context);
                    volViewModel.IdVol = vol.Id;
                    modifVol.VolModifs.Add(CreateModifObject(volViewModel));
                    _context.Update(modifVol);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VolExists(vol.Id))
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
            ViewData["AeroportArriveId"] = new SelectList(_context.Aeroport, "Id", "Nom", vol.AeroportArriveId);
            ViewData["AeroportDepartId"] = new SelectList(_context.Aeroport, "Id", "Nom", vol.AeroportDepartId);
            ViewData["AppareilId"] = new SelectList(_context.Appareil, "Id", "Nom", vol.AppareilId);
            ViewData["PiloteId"] = new SelectList(_context.Users
                .Join(_context.UserRoles, u => u.Id,
                ur => ur.UserId, (u, ur) => new {
                    Id = u.Id,
                    Name = u.Name,
                    Firstname = u.Firstname,
                    RoleId = ur.RoleId
                })
                .Join(_context.Roles, x => x.RoleId, r => r.Id, (x, r) => new {
                    Id = x.Id,
                    Name = x.Name,
                    Firstname = x.Firstname,
                    RoleName = r.Name
                })
                                                .Where(x => x.RoleName == "Pilote"), "Id", "Firstname", vol.PiloteId);
            return View(vol);
        }

       

        // GET: Vols/Edit/5
        public async Task<IActionResult> EditByPilote(int? id)
        {
            if (id == null || _context.Vol == null)
            {
                return NotFound();
            }

            var vol = await _context.Vol.FindAsync(id);
            if (vol == null)
            {
                return NotFound();
            }
            ViewData["AeroportArriveId"] = new SelectList(_context.Aeroport, "Id", "Nom", vol.AeroportArriveId);
            ViewData["AeroportDepartId"] = new SelectList(_context.Aeroport, "Id", "Nom", vol.AeroportDepartId);
            ViewData["AppareilId"] = new SelectList(_context.Appareil, "Id", "Nom", vol.AppareilId);
            ViewData["PiloteId"] = new SelectList(_context.Users
                .Join(_context.UserRoles, u => u.Id,
                ur => ur.UserId, (u, ur) => new {
                    Id = u.Id,
                    Name = u.Name,
                    Firstname = u.Firstname,
                    RoleId = ur.RoleId
                })
                .Join(_context.Roles, x => x.RoleId, r => r.Id, (x, r) => new {
                    Id = x.Id,
                    Name = x.Name,
                    Firstname = x.Firstname,
                    RoleName = r.Name
                })
                                                .Where(x => x.RoleName == "Pilote"), "Id", "Firstname", vol.PiloteId);

            return View(vol);
        }

        // POST: Vols/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditByPilote(int id, [Bind("Id,AeroportDepartId,AeroportArriveId,NombrePlace,HeureDepartPrevue,HeureArrivePrevue,HeureDepartReelle,HeureArriveReelle,PiloteId,Distance,AppareilId,Recurrence,Retard,Raison")] Vol vol)
        {
            if (id != vol.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vol);
                   

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VolExists(vol.Id))
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
            ViewData["AeroportArriveId"] = new SelectList(_context.Aeroport, "Id", "Nom", vol.AeroportArriveId);
            ViewData["AeroportDepartId"] = new SelectList(_context.Aeroport, "Id", "Nom", vol.AeroportDepartId);
            ViewData["AppareilId"] = new SelectList(_context.Appareil, "Id", "Nom", vol.AppareilId);
            ViewData["PiloteId"] = new SelectList(_context.Users
                .Join(_context.UserRoles, u => u.Id,
                ur => ur.UserId, (u, ur) => new {
                    Id = u.Id,
                    Name = u.Name,
                    Firstname = u.Firstname,
                    RoleId = ur.RoleId
                })
                .Join(_context.Roles, x => x.RoleId, r => r.Id, (x, r) => new {
                    Id = x.Id,
                    Name = x.Name,
                    Firstname = x.Firstname,
                    RoleName = r.Name
                })
                                                .Where(x => x.RoleName == "Pilote"), "Id", "Firstname", vol.PiloteId);
            return View(vol);
        }
        // GET: Vols/Delete/5
        public async Task<IActionResult> Delete(int? id)
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
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vol == null)
            {
                return NotFound();
            }

            return View(vol);
        }

        // POST: Vols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vol == null)
            {
                return Problem("Entity set 'JITCDbContext.Vol'  is null.");
            }
            var vol = await _context.Vol.FindAsync(id);
            if (vol != null)
            {
                _context.Vol.Remove(vol);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: ModifVols
        public async Task<IActionResult> ListModif()
        {
            var jITCDbContext = _context.ModifVol.Include(v => v.Vols);
            return View(await jITCDbContext.ToListAsync());
        }

        // GET: Vols/DetailsModif/5
        public async Task<IActionResult> DetailsModif(int? id)
        {
            if (id == null || _context.ModifVol == null)
            {
                return NotFound();
            }

            var modifVol = await _context.ModifVol
                .Include(v => v.Vols)
                .FirstOrDefaultAsync(m => m.Id == id);
            var vol = await _context.Vol
                .Include(v => v.AeroportArrive)
                .Include(v => v.AeroportDepart)
                .Include(v => v.Appareil)
                .Include(v => v.Pilote)
                .FirstOrDefaultAsync(v => v.ModifVolId == id);
            if (modifVol == null)
            {
                return NotFound();
            }
            
            return View( modifVol);
        }


        private bool VolExists(int id)
        {
          return (_context.Vol?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        private double getDistanceFromLatLonInKm(double lat1, double lon1,  double lat2, double lon2)
        {
            var R = 6371; // Radius of the earth in km
            var dLat = deg2rad(lat2 - lat1);  // deg2rad below
            var dLon = deg2rad(lon2 - lon1);
            var a =
              Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
              Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) *
              Math.Sin(dLon / 2) * Math.Sin(dLon / 2)
              ;
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = R * c; // Distance in km
            return d;
        }

        private double deg2rad(double deg)
        {
            return deg * (Math.PI / 180);
        }
    }
}
