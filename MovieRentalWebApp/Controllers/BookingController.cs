using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRentalWebApp.Models;
using MovieRentalWebApp.ViewModels;

namespace MovieRentalWebApp.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationContext _context;

        public BookingController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooking(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            var userId = _context.Users.FirstOrDefault(m => m.Email == User.Identity.Name).Id;

            var booking = new Booking
            {
                MovieId = movie.Id,
                UserId = userId,
            };

            return View("Booking", booking);
        }

        [HttpPost]
        public IActionResult PostBooking(BookingModel bookingModel)
        {
            if (ModelState.IsValid)
            {
                bookingModel.BookingDate = DateTime.Now;

                var booking = new Booking
                {
                    BookingDate = bookingModel.BookingDate,
                    AdditionalNotes = bookingModel.AdditionalNotes,
                    MovieId = bookingModel.MovieId,
                    UserId = bookingModel.UserId
                };

                _context.Bookings.Add(booking);
                _context.SaveChanges();
                return RedirectToAction("Index", "Movie");
            }
            return View("Booking", bookingModel);
        }
        public IActionResult BookingList()  
        {
            var bookings = _context.Bookings.ToList();
            return View("BookingList", bookings);
        }
    }
}
