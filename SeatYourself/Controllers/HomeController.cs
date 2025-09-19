using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using SeatYourself.Models;

namespace SeatYourself.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Event()
        {
            List<Event> events = new List<Event>();
            DateTime dt = new DateTime(1955, 11, 5, 9, 0, 0);
            int hour = dt.Hour;
            int minute = dt.Minute;
            string timeString = dt.ToString("hh:mm");
            events.Add(new Event
            {
             
                Title = "First Event",
                Description = "This is a sample event description.",
                Category = "Conference",
                EventDate = new DateTime(1955, 11, 5),
                EventTime = timeString,
                Location = "123 Main St, Halifax, NS",
                Owner = "John Doe",
                CreatedAt = DateTime.Now
            });
            events.Add(new Event
            {

                Title = "Second Event",
                Description = "This is a sample event description.",
                Category = "Concert",
                EventDate = new DateTime(2025, 11, 5),
                EventTime = timeString,
                Location = "246 Main St, Halifax, NS",
                Owner = "Jane Doe",
                CreatedAt = DateTime.Now
            });
            return View(events);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
