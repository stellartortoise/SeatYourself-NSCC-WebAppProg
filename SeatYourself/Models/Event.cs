namespace SeatYourself.Models
{
    public class Event
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime EventTime { get; set; }
        public string Location { get; set; }
        public string Owner { get; set; }
        public DateTime CreatedAt { get; set; }

        // Available Seats will to here at some point
    }
}
