using CSM.Data;
using CSM.Models;
using CSM.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace CSM.Areas.User.Controllers
{
	[Area("User")]
    [Authorize(Roles = "User")]
    public class HomeController : Controller
	{
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(ApplicationDbContext db, UserManager<ApplicationUser>userManager)
        {
            _db = db;
            this.userManager = userManager;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var x = _db.Bookings.Include(i => i.Route).Where(i => i.UserId == userManager.GetUserAsync(User).Result.Id);
            return View(x);
            //return View(_db.Bookings.Where(i => i.UserId == userManager.GetUserAsync(User).Result.Id).ToList());
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new BookingViewModel()
            {
                Routes = await _db.Routes.ToListAsync()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookingViewModel model)
        {
            var user = await userManager.GetUserAsync(User);
            if (!ModelState.IsValid)
                return View(model);

            Console.Write(model.Destination + " " + model.Source);
            //var sql = "SELECT Id FROM Routs WHERE Source == sec AND Destination == dtn";
            var Routes = await _db.Routes.Where(op => op.source == model.Source && op.Destination == model.Destination).FirstAsync();
            var routeId = Routes.Id;
            Console.Write(routeId);
            await _db.Bookings.AddAsync(new Booking()
            {
                Date = model.Date,
                RouteId = routeId,
                UserId = user.Id
            });


            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(ConfirmRide),"Home", new {Area = "User", id=routeId});
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmRide(int id)
        {
            var Routes = _db.Routes.Where(i => i.Id == id).First();
            //Console.WriteLine(id);
            //var res = new RoutesViewModel
            //{
            //    Route = ,
            //};
            //Console.WriteLine();
            return View(new RoutesViewModel
            {
                Source = Routes.source,
                Destination = Routes.Destination,
                Cost = Routes.Cost

            });
        }

     
        public async Task<IActionResult> Delete(int id)
        {
            var Book = await _db.Bookings.FindAsync(id);
            if (Book == null)
                return NotFound();

            _db.Bookings.Remove(Book);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool Validity()
        {
            // your code based on that you can return true or false
            //return true;
            return false;
        }
    }
}
