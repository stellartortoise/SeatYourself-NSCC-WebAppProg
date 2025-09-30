namespace SeatYourself.Models
{
    public class Seat
    {
        public int SeatId { get; set; }
        public char Row { get; set; }
        public int Number { get; set; }
        public int VenueId { get; set; }
        public virtual Venue? Venue { get; set; }
        //public bool IsAvailable { get; set; }
        public virtual ICollection<Ticket>? Tickets { get; set; }

    }
}
