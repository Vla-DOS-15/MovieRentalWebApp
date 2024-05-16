using Microsoft.AspNetCore.Mvc;
using MovieRentalWebApp.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace MovieRentalWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            _context.Movies.Add(new Movie { Title = "Wednesday", Actor = "Jenna Ortega", Director = "James Marshall", Time = 45, Genre = "Comedy horror", Image = @"https://upload.wikimedia.org/wikipedia/en/thumb/6/66/Wednesday_Netflix_series_poster.png/220px-Wednesday_Netflix_series_poster.png", Trailer = @"https://youtu.be/Di310WS8zLk", Description = "At the center of the plot is the slightly gloomy Wednesday, the eldest daughter of the eccentric Addams family, who changed schools eight times in five years due to her shocking antics. The school is run with an iron grip by Larissa Weems, the sworn enemy of her mother Morticia." });
            _context.SaveChanges();
            return View();
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