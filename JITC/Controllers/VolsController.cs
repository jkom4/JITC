using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JITC.Models;
using Microsoft.AspNetCore.Authorization;
using JITC.Models.ViewModels;
using System.Security.Claims;
using Newtonsoft.Json;

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
        public async Task<IActionResult> Index(int? DepartId, int? ArriveId, DateTime? DepartDate, string? airport)
        {
            if (DepartId != null && ArriveId != null && DepartDate != null)
            {
                var jITCDbContext = _context.Vol.Include(v => v.AeroportArrive).Include(v => v.AeroportDepart).Include(v => v.Appareil).Include(v => v.Pilote)
                                    .Where(v => v.AeroportDepartId == DepartId && v.AeroportArriveId == ArriveId && v.HeureArrivePrevue.Date == DepartDate);
                return View(await jITCDbContext.ToListAsync());
            }
            else if (airport != null) 
            {
                var jITCDbContext = _context.Vol.Include(v => v.AeroportArrive).Include(v => v.AeroportDepart).Include(v => v.Appareil).Include(v => v.Pilote)
                                    .Where(v => v.AeroportArrive.Nom == airport).Where(v => v.HeureDepartPrevue >= DateTime.Now);
                return View(await jITCDbContext.ToListAsync());
            }
            else
            {
                var jITCDbContext = _context.Vol.Include(v => v.AeroportArrive).Include(v => v.AeroportDepart).Include(v => v.Appareil).Include(v => v.Pilote).Where(v => v.HeureDepartPrevue >= DateTime.Now);
                return View(await jITCDbContext.ToListAsync());
            }
            
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
        public async Task<IActionResult> Create(string[] Recurrence,[Bind("Id,AeroportDepartId,AeroportArriveId,NombrePlace,HeureDepartPrevue,HeureArrivePrevue,HeureDepartReelle,HeureArriveReelle,PiloteId,Distance,AppareilId,Recurrence,NombreMois,Retard,Raison")] Vol vol)
        {
            
                vol.Recurrence = JsonConvert.SerializeObject(Recurrence);
              if (ModelState.IsValid)
              {

                Aeroport Depart = await _context.Aeroport.Where(a => a.Id == vol.AeroportDepartId).FirstOrDefaultAsync();
                Aeroport Arrive = await _context.Aeroport.Where(a => a.Id == vol.AeroportArriveId).FirstOrDefaultAsync();
                vol.Distance = getDistanceFromLatLonInKm(Depart.Latitude, Depart.Longitude, Arrive.Latitude, Arrive.Longitude);
                var volsValid = new List<Vol>();
                var modifValid = new List<ModifVol>();
                int nber = 0;
                for (int i = 0; i < vol.NombreMois; i++) 
                {
                    foreach (var jour in Recurrence) 
                    {
                        var jours = GetDates(DateTime.Now.Year, DateTime.Now.Month + i).Where(j => j.DayOfWeek.ToString() == jour);
                        foreach (var jr in jours)
                        {
                            if (jr > DateTime.Now)
                            {
                                var vol1 = new Vol();
                                vol1.AeroportDepartId = vol.AeroportDepartId;
                                vol1.AeroportArriveId = vol.AeroportArriveId;
                                vol1.AppareilId = vol.AppareilId;
                                vol1.Distance = vol.Distance;
                                vol1.NombreMois = vol.NombreMois;
                                vol1.NombrePlace = vol.NombrePlace;
                                vol1.PiloteId = vol.PiloteId;
                                vol1.Recurrence = vol.Recurrence;

                                DateTime departDate = jr.AddHours(vol.HeureDepartPrevue.Hour).AddMinutes(vol.HeureDepartPrevue.Minute).AddSeconds(vol.HeureDepartPrevue.Second);
                                DateTime arriveDate = jr.AddHours(vol.HeureArrivePrevue.Hour).AddMinutes(vol.HeureArrivePrevue.Minute).AddSeconds(vol.HeureArrivePrevue.Second);
                                vol1.HeureDepartPrevue = departDate;
                                vol1.HeureArrivePrevue = arriveDate;

                                ModifVol modifVol = new ModifVol();
                                VolViewModel volViewModel = CreateViewModel(vol1, _context);
                                modifVol.VolModifs.Add(CreateModifObject(volViewModel));
                                vol1.ModifVol = modifVol;
                                
                                modifValid.Add(modifVol);
                                
                                volsValid.Add(vol1);
                            }
                        }
                    }
                }

                _context.Vol.AddRange(volsValid);
                _context.ModifVol.AddRange(modifValid);
                
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
        public static List<DateTime> GetDates(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))  // Days: 1, 2 ... 31 etc.
                             .Select(day => new DateTime(year, month, day)) // Map each day to a date
                             .ToList();
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
            volViewModel.Recurrence = JsonConvert.DeserializeObject<string[]>(vol.Recurrence);
            return volViewModel;
        }

        private string CreateModifObject(VolViewModel vol)
        {
           return JsonConvert.SerializeObject(vol,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
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
                try
                {
                 
                   
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

                if (vol.HeureDepartReelle != null || vol.HeureArriveReelle != null)
                {

                    if(vol.HeureArriveReelle != null && vol.HeureArriveReelle > vol.HeureArrivePrevue && vol.Raison == null)
                    {
                        
                        ModelState.AddModelError("", "Un retard a été constaté Vous devez renseigner la raison ");
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
                    try
                    {
                        if (vol.HeureArriveReelle > vol.HeureArrivePrevue) { vol.Retard = true; }
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
                    return RedirectToAction(nameof(DashboardPilote));
                }
                else
                {
                    ModelState.AddModelError("", "Vous devez renseigner au moins la date de depart reelle ou la date d'arrivé reelle");
                }

                
               
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

       
        // GET: Vols/DetailsModif/5
        public async Task<IActionResult> DetailsModif(int? idVol)
        {
            if (idVol == null || _context.ModifVol == null)
            {
                return NotFound();
            }

            var modifVol = await _context.ModifVol
                .Include(v => v.Vols)
                .FirstOrDefaultAsync(m => m.Vols.FirstOrDefault().Id == idVol);
            var vol = await _context.Vol
                .Include(v => v.AeroportArrive)
                .Include(v => v.AeroportDepart)
                .Include(v => v.Appareil)
                .Include(v => v.Pilote)
                .FirstOrDefaultAsync(v => v.Id == idVol);
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

        // GET: VolsPilote
        [Authorize(Roles = "Pilote")]
        public async Task<IActionResult> DashboardPilote()
        {
            var jITCDbContext = _context.Vol.Include(v => v.AeroportArrive).Include(v => v.AeroportDepart).Include(v => v.Appareil).Include(v => v.Pilote).Where(v => v.Pilote.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return View(await jITCDbContext.ToListAsync());
        }

        // GET: Chart
        [Authorize(Roles = "Responsable")]
        public async Task<IActionResult> Chart()
        {
            var appareils = _context.Appareil.ToList();
            var tabAppareil = new string[appareils.Count];
            int nber = 0;
            int nberData = 0;
            int nbreVolWithAppareil = 0;
            foreach (var item in appareils)
            {
                tabAppareil[nber] = item.Nom;
                nber++;
            }
            var vols = _context.Vol.Where(v => v.HeureArriveReelle != null).ToList();
            var tabData = new double[appareils.Count];

            foreach (var appareil in appareils)
            { 
                foreach(var vol in vols)
                {
                    if (vol.Appareil == appareil)
                    {
                        tabData[nberData] += ((double)vol.NbrePersonnes / (double)vol.NombrePlace) * 100;
                        nbreVolWithAppareil = 0;
                    }
                }
                if (nbreVolWithAppareil != 0) 
                {
                    tabData[nberData] = Math.Round(tabData[nberData] / nbreVolWithAppareil, 1);
                    nbreVolWithAppareil = 0;    
                }
                nberData++;
                
            }

            ViewBag.Data = tabData;
            ViewBag.ObjectName = tabAppareil;
            return View();
        }
        // GET: Chart
        [Authorize(Roles = "Responsable")]
        public async Task<IActionResult> ChartRetard()
        {
            var jITCDbContext = _context.Vol.Include(v => v.AeroportArrive).Include(v => v.AeroportDepart).Include(v => v.Appareil).Include(v => v.Pilote).Where(v => v.Retard == true).ToListAsync().Result;
            return View(jITCDbContext);
            
        }

    }
}
