using e_Tickets.Data;
using e_Tickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZendeskApi_v2.Models.Constants;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class MoviesController : Controller
    {
        private readonly AppDbContext _dbContext;

        public MoviesController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var allMovies = _dbContext.Movies.ToList();
            return View(allMovies);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = _dbContext.Movies.ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = allMovies.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allMovies);
        }

        //GET: Movies/Details/1
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var movieDetail = _dbContext.Movies.Find(id);
            return View(movieDetail);
        }

        //GET: Movies/Create
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            _dbContext.Movies.AddAsync(movie);

            //ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            //ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            //ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
            return View(movie);
            //return View();
        }


        //GET: Movies/Edit/1
        [HttpPost]
        public IActionResult Edit(int id)
        {
            var movieDetails = _dbContext.Movies.Find(id);
            if (movieDetails == null) return View("NotFound");

            var response = new Movie()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                ImageURL = movieDetails.ImageURL,
                MovieCategory = movieDetails.MovieCategory,
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorsMovies = movieDetails.ActorsMovies.ToList(),
            };

            //var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
            //ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            //ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            //ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View(response);
        }

        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        //{
        //    if (id != movie.Id) return View("NotFound");

        //    if (!ModelState.IsValid)
        //    {
        //        var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

        //        ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
        //        ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
        //        ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

        //        return View(movie);
        //    }

        //    await _service.UpdateMovieAsync(movie);
        //    return RedirectToAction(nameof(Index));
        //}

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var movieDetails = _dbContext.Movies.Find(id);
            if (movieDetails == null) return View("NotFound");
            return View(movieDetails);
        }
    }
}
