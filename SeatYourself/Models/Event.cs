namespace SeatYourself.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public DateTime EventDate { get; set; }
        public string EventTime { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Owner { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public List<Seat> AvailableSeats { get; set; } = new List<Seat>();

        public Event()
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
