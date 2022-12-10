using CSM.Data;
using CSM.Models;
using CSM.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CSM.Areas.Admin.Controllers
{
		[Area("Admin")]
		[Authorize(Roles = "Admin")]
	public class HomeController : Controller
	{
		private readonly ApplicationDbContext _db;

		public HomeController(ApplicationDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			return View(_db.Routes.ToList());
		}

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var route = await _db.Routes.FindAsync(id);
            if (route == null)
                return NotFound();

            return View(new RoutesViewModel()
            {
                Source = route.source,
                Destination = route.Destination,
                Cost = route.Cost
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, RoutesViewModel model)
        {
            var routes = await _db.Routes.FindAsync(id);
            if (routes == null)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            routes.source = model.Source;
            routes.Destination = model.Destination;
            routes.Cost = model.Cost;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoutesViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _db.Routes.Add(new Routes()
            {
                source = model.Source,
                Destination = model.Destination,
                Cost = model.Cost
            });
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
		public async Task<IActionResult> Delete(int id)
		{
			var movie = await _db.Routes.FindAsync(id);
			if (movie == null)
				return NotFound();

			_db.Routes.Remove(movie);
			await _db.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	}
}
