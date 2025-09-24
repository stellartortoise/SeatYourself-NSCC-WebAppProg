namespace SeatYourself.Models
{
    public class Seat
    {
        public int SeatId { get; set; }
        public char Row { get; set; }
        public int Number { get; set; }
        public bool IsAvailable { get; set; }

    }
}
