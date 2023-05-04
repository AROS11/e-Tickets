using e_Tickets.Data;
using eTickets.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace e_Tickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allProducert = await _context.Movies.ToListAsync();
            return View();
        }
    }
}
