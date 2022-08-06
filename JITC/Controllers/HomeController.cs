using JITC.Models;
using JITC.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace JITC.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly JITCDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(ILogger<HomeController> logger, JITCDbContext context, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Aeroport = _context.Aeroport.ToList();
            
            if (User.Identities.Any())
            {
                var reservations = await _context.Reservation.Include(r => r.vol).Where(r => r.UserId == _userManager.GetUserId(User)).Where( r => r.vol.ModifDate).Where(r => r.vol.HeureDepartPrevue >= DateTime.Now).ToListAsync();
                ViewBag.Reservations = reservations;
            }
            return View();
        }
        [Authorize(Roles = "Responsable")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    
    }
}