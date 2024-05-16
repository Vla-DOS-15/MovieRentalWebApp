using System.ComponentModel.DataAnnotations;

namespace MovieRentalWebApp.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Actor { get; set; }
        public string Director { get; set; }
        public int Time { get; set; }
        public string Genre { get; set; }
        public string Image { get; set; }
        public string Trailer { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Booking> Bookings { get;}
    }
}
