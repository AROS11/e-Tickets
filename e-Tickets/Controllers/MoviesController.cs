using Microsoft.AspNetCore.Mvc;

namespace e_Tickets.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
