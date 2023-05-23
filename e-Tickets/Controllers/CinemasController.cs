using e_Tickets.Data;
using e_Tickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZendeskApi_v2.Models.Constants;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CinemasController : Controller
    {
        private readonly AppDbContext _context;

        public CinemasController(AppDbContext db)
        {
            _context = db;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allCinemas = await _context.Cinemas.ToListAsync();
            return View(allCinemas);
        }


        //Get: Cinemas/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
        //{
        //    if (!ModelState.IsValid) return View(cinema);
        //    await _service.AddAsync(cinema);
        //    return RedirectToAction(nameof(Index));
        //}

        ////Get: Cinemas/Details/1
        //[AllowAnonymous]
        //public async Task<IActionResult> Details(int id)
        //{
        //    var cinemaDetails = await _service.GetByIdAsync(id);
        //    if (cinemaDetails == null) return View("NotFound");
        //    return View(cinemaDetails);
        //}

        ////Get: Cinemas/Edit/1
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var cinemaDetails = await _service.GetByIdAsync(id);
        //    if (cinemaDetails == null) return View("NotFound");
        //    return View(cinemaDetails);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Cinema cinema)
        //{
        //    if (!ModelState.IsValid) return View(cinema);
        //    await _service.UpdateAsync(id, cinema);
        //    return RedirectToAction(nameof(Index));
        //}

        ////Get: Cinemas/Delete/1
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var cinemaDetails = await _service.GetByIdAsync(id);
        //    if (cinemaDetails == null) return View("NotFound");
        //    return View(cinemaDetails);
        //}

        //[HttpPost, ActionName("Delete")]
        //public async Task<IActionResult> DeleteConfirm(int id)
        //{
        //    var cinemaDetails = await _service.GetByIdAsync(id);
        //    if (cinemaDetails == null) return View("NotFound");

        //    await _service.DeleteAsync(id);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}