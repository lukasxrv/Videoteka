using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Diagnostics;
using Videoteka.DataModel;
using Videoteka.Models;

namespace Videoteka.Controllers
{
    public class HomeController : Controller
    {
        private readonly VideotekaDbContext dbContext;

        public HomeController(VideotekaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await dbContext.Film.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await dbContext.Film.SingleOrDefaultAsync(m => m.IDFilm == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nazev,RokVydani,Zanr,Hodnoceni")] Film film)
        {
            if (ModelState.IsValid)
            {
                dbContext.Film.Add(film);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(HomeController.Index));
            }
            return View(film);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await dbContext.Film.SingleOrDefaultAsync(m => m.IDFilm == id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDFilm,Nazev,RokVydani,Zanr,Hodnoceni")] Film film)
        {
            if (id != film.IDFilm)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                dbContext.Film.Attach(film);
                dbContext.Entry(film).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(HomeController.Index));
            }
            return View(film);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await dbContext.Film.SingleOrDefaultAsync(m => m.IDFilm == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var film = await dbContext.Film.SingleOrDefaultAsync(m => m.IDFilm == id);
            dbContext.Film.Remove(film);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(HomeController.Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}