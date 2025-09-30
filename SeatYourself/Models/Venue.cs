namespace SeatYourself.Models
{
    public class Venue
    {
        public int VenueId { get; set; }
        public string Name { get; set; } = string.Empty;
        // ... other venue properties like address, capacity, etc. to be added later

        // A venue has a collection of seats
        public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();
    }
}
