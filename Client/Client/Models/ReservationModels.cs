namespace Client.Models
{
    public class ReservationResponseDto
    {
        public int id { get; set; }
        public int tripId { get; set; }
        public int userId { get; set; }
        public int seatsReserved { get; set; }
    }

    public class ReservationCreateDto
    {
        public int tripId { get; set; }
        public int seatsReserved { get; set; }
    }
}
