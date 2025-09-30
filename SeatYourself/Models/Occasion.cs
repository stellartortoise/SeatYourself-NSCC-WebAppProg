using System.ComponentModel.DataAnnotations;

namespace SeatYourself.Models
{
    public class Occasion
    {
        public enum CategoryType
        {
            Concert = 1,
            Theater = 2,
            Sports = 3,
            Comedy = 4,
            Other = 5
        }
        public enum VenueType
        {
            Stadium = 1,
            Arena = 2,
            Theater = 3,
            Club = 4,
            Other = 5
        }


        [Display(Name = "ID")]
        public int OccasionId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public CategoryType Category { get; set; } //Photo will be assigned based on category
        public VenueType Venue { get; set; }
        
        [Display(Name = "Date")]
        public DateTime OccasionDate { get; set; }
        
        [Display(Name = "Time")]
        public DateTime OccasionTime { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Owner { get; set; } = string.Empty;

        [ScaffoldColumn(false)] // <-- This will hide the field in the Create and Edit views; interacted with GitHub Copilot to get this
        [Display(Name = "Created")]
        public DateTime CreatedAt { get; set; }

        public List<Seat> AvailableSeats { get; set; } = new List<Seat>();

        public Occasion()
        {
            // Initialize AvailableSeats with some default seats
            for (char row = 'A'; row <= 'D'; row++)
            {
                for (int number = 1; number <= 10; number++)
                {
                    AvailableSeats.Add(new Seat
                    {
                        Row = row,
                        Number = number,
                        IsAvailable = true
                    });
                }
            }
        }

    }
}
