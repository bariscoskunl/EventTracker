using System.Diagnostics;
using EventTracker.Models;
using EventTracker.ViewModels;
using Microsoft.AspNetCore.Mvc;
using EventTracker.Controllers;
using EventTracker.Data;

namespace EventTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var sourceData = _context.Events.ToList();
            var viewModel = sourceData             
                .OrderByDescending(x => x.IsPinned)
                .ThenBy(x => x.Date) 
                .Where(x => x.IsPinned == true)
                .Select(x => new EventViewModel
                {
                    Id = x.Id,
                    Title = (x.IsPinned ? "📌 " : "") + x.Title,
                    ShortDescription = (x.Description != null)
                    ? (x.Description.Length > 50 ? x.Description.Substring(0, 50) + "..." : x.Description): "",
                    FormattedDate = x.Date.HasValue ? x.Date.Value.ToString("dd MMMM yyyy") : "Tarih Yok"
                })
                .ToList();

            return View(viewModel);            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
