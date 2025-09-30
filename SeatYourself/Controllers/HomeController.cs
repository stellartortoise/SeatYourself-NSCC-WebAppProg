using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeatYourself.Data;
using SeatYourself.Models;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace SeatYourself.Controllers
{
    public class HomeController : Controller
    {
        private readonly SeatYourselfContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(SeatYourselfContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Occasion.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //public IActionResult Occasion()
        //{
        //    List<Occasion> occasions = new List<Occasion>();
        //    DateTime dt = new DateTime(1955, 11, 5, 9, 0, 0);
        //    int hour = dt.Hour;
        //    int minute = dt.Minute;
        //    string timeString = dt.ToString("hh:mm");
        //    occasions.Add(new Occasion
        //    {
             
        //        Title = "First Event",
        //        Description = "This is a sample event description.",
        //        Category = "Conference",
        //        OccasionDate = new DateTime(1955, 11, 5),
        //        OccasionTime = timeString,
        //        Location = "123 Main St, Halifax, NS",
        //        Owner = "John Doe",
        //        CreatedAt = DateTime.Now
        //    });
        //    occasions.Add(new Occasion
        //    {

        //        Title = "Second Event",
        //        Description = "This is a sample event description.",
        //        Category = "Concert",
        //        OccasionDate = new DateTime(2025, 11, 5),
        //        OccasionTime = timeString,
        //        Location = "246 Main St, Halifax, NS",
        //        Owner = "Jane Doe",
        //        CreatedAt = DateTime.Now
        //    });
        //    return View(occasions);
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
