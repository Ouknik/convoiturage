namespace Client.Models
{
    public class ReservationResponseDto
    {
        public int id { get; set; }
        public int tripId { get; set; }
        public int userId { get; set; }
        public int seatsReserved { get; set; }
        public int paymentId { get; set; }
        public decimal paymentAmount { get; set; }
        public string paymentMethod { get; set; }
        public string paymentStatus { get; set; }
    }

    public class ReservationCreateDto
    {
        public int tripId { get; set; }
        public int seats { get; set; }
        public string paymentMethod { get; set; }
        public string cardHolderName { get; set; }
        public string cardNumber { get; set; }
        public string expiryDate { get; set; }
        public string cvv { get; set; }
    }
}
