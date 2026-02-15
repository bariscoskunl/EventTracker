using EventTracker.Data;
using EventTracker.Models;
using EventTracker.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Linq;



namespace EventTracker.Controllers
{
    public class EventsController : Controller
    {
        private readonly AppDbContext _context;

        public EventsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var events = _context.Events
                .OrderBy(e => e.Date)
                .Select(e => new EventViewModel
                {
                    Id = e.Id,
                    Title = e.Title,
                    ShortDescription = e.Description,
                    FormattedDate = e.Date.HasValue ? e.Date.Value.ToString("dd MMMM yyyy") : "Tarih Yok",
                    IsPinned = e.IsPinned
                })
                .ToList();

            return View(events);
        }

        public IActionResult Details(int id)
        {
            var eventById = _context.Events.Find(id);

            if (eventById is null)
            {
                return NotFound();
            }
            return View(eventById);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EventModel newEvent)
        {
            if (!ModelState.IsValid)
            {
                return View(newEvent);
            }
            if (newEvent.Date is null)
            {
                newEvent.Date = DateTime.Now;
            }

            int id = _context.Events.Any() ? _context.Events.Max(x => x.Id) : 0;
            newEvent.Id = id + 1;

            _context.Events.Add(newEvent);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var eventToEdit = _context.Events.Find(id);

            if (eventToEdit is null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(eventToEdit);
        }

        [HttpPost]
        public IActionResult Edit(EventModel formdangelenEvent)
        {
            if (!ModelState.IsValid)
            {
                return View(formdangelenEvent);
            }

            var duzenlenenEvent = _context.Events.FirstOrDefault(x => x.Id == formdangelenEvent.Id);

            if (duzenlenenEvent is null)
            {
                return RedirectToAction(nameof(Index));
            }

            duzenlenenEvent.Title = formdangelenEvent.Title;
            duzenlenenEvent.Description = formdangelenEvent.Description;
            if (formdangelenEvent.Date is not null)
            {
                duzenlenenEvent.Date = formdangelenEvent.Date;
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var eventToDelete = _context.Events.FirstOrDefault(x => x.Id == id);

            if (eventToDelete is null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(eventToDelete);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteOnay(int id)
        {
            var eventToDelete = _context.Events.FirstOrDefault(x => x.Id == id);

            if (eventToDelete != null)
            {
                _context.Events.Remove(eventToDelete);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult TogglePin(int id)
        { 
        var eventItem = _context.Events.Find(id);
            if (eventItem != null)
            {
                eventItem.IsPinned = !eventItem.IsPinned;
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
