namespace SeatYourself.Models
{
    public class Ticket
    {
        public int TicketId { get; set; } // Primary Key

        // Foreign Keys to link everything together
        public int OccasionId { get; set; }
        public int SeatId { get; set; }

        // Navigation properties for Entity Framework
        public virtual Occasion? vOccasion { get; set; }
        public virtual Seat? vSeat { get; set; }
    }
}
