using e_Tickets.Data;
using e_Tickets.Data.Services;
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
       private readonly IActorsService _service;

       public ActorsController(IActorsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var actors =  _service.GetAllASync();
            if (actors == null)
            {
                return NotFound();
            }
            return View(actors);
        }

        //Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _service.AddAsync(actor);

            return RedirectToAction(nameof(Index));
        }
        ////Get: Actors/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> DetailsAsync(int id)
        {
            var actorDetails = await _service.GetByIdASync(id);

            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        //Get: Actors/Edit/1
        public IActionResult Edit(int id)
        {
            var actorDetails =  _service.GetByIdASync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.UpdateASync(id, actor);
            return RedirectToAction(nameof(Index));
        }

        ////Get: Actors/Delete/1
        public IActionResult Delete(int id)
        {
            var actorDetails = _service.GetByIdASync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = _service.GetByIdASync(id);
            if (actorDetails == null) return View("NotFound");
            
            await _service.DeleteASync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}