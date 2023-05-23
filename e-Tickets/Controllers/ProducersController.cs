using e_Tickets.Data;
using e_Tickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZendeskApi_v2.Models.Constants;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProducersController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ProducersController(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var allProducers =  _dbContext.Producers.ToList();
            return View(allProducers);
        }

        //GET: producers/details/1
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var producerDetails =  _dbContext.Producers.Find(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);

            await _dbContext.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        //GET: producers/edit/1
        public IActionResult Edit(int id)
        {
            var producerDetails =  _dbContext.Producers.Find(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);

            if (id == producer.Id)
            {
                _dbContext.Producers.Update(producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }

        //GET: producers/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails =  _dbContext.Producers.Find(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var producerDetails =  _dbContext.Producers.Find(id);
            if (producerDetails == null) return View("NotFound");
            Producer producer = new Producer ();
            _dbContext.Producers.Remove(producerDetails);
            return RedirectToAction(nameof(Index));
        }
    }
}
