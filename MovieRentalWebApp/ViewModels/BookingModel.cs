using MovieRentalWebApp.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieRentalWebApp.ViewModels
{
    public class BookingModel
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public DateTime BookingDate { get; set; }
        public string AdditionalNotes { get; set; }
    }
}
