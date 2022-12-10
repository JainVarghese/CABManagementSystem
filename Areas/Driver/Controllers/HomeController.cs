using CSM.Data;
using CSM.Models;
using CSM.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CSM.Areas.Driver.Controllers
{
	[Area("Driver")]
	public class HomeController : Controller
	{
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(ApplicationDbContext db,UserManager<ApplicationUser> userManager)
        {
            _db = db;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
		{
            var model = new BookingViewModel()
            {
                Routes = await _db.Routes.ToListAsync(),
                ApplicationUsers = await _db.ApplicationUsers.ToListAsync()
            };
            return View(_db.Bookings.ToList());
        }
      
        public async Task<IActionResult> CommitRide(int id)
        {
            var user = await userManager.GetUserAsync(User);
            var bk = await _db.Bookings.FindAsync(id);
            if (bk == null)
            {
                return NotFound();
            }
            bk.DriverId = user.Id;
            bk.Status = true;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));



        }
    }
}
