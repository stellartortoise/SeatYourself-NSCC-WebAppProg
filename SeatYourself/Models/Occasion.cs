namespace SeatYourself.Models
{
    public class Occasion
    {
        public int OccasionId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public DateTime OccasionDate { get; set; }
        public string OccasionTime { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Owner { get; set; } = string.Empty;
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
