using e_Tickets.Data;
using e_Tickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZendeskApi_v2.Models.Constants;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ActorsController : Controller
    {
       private readonly AppDbContext _dbContext;

       public ActorsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var actors = await _dbContext.Actors.ToListAsync();
            if (actors == null)
            {
                return NotFound();
            }
            return View(actors);
        }

        ////Get: Actors/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(actor);
        //    }
        //    _dbContext.Actors.Add(actor);
        //    return RedirectToAction(nameof(Index));
        //}

        ////Get: Actors/Details/1
        //[AllowAnonymous]
        //public IActionResult Details(int id)
        //{
        //    var actorDetails = _dbContext.Actors.Find(id);

        //    if (actorDetails == null) return View("NotFound");
        //    return View(actorDetails);
        //}

        ////Get: Actors/Edit/1
        //public IActionResult Edit(int id)
        //{
        //    var actorDetails =  _dbContext.Actors.Find(id);
        //    if (actorDetails == null) return View("NotFound");
        //    return View(actorDetails);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(actor);
        //    }
        //     _dbContext.Actors.Update(actor);
        //    return RedirectToAction(nameof(Index));
        //}

        ////Get: Actors/Delete/1
        //public IActionResult Delete(int id)
        //{
        //    var actorDetails = _dbContext.Actors.Find(id);
        //    if (actorDetails == null) return View("NotFound");
        //    return View(actorDetails);
        //}

        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeleteConfirmed(int id)
        //{
        //    var actorDetails = _dbContext.Actors.Find(id);
        //    if (actorDetails == null) return View("NotFound");
        //    Actor actor = _dbContext.Actors.Find(id);
        //    _dbContext.Actors.Remove(actor);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}