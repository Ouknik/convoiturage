using System.Collections.Generic;

namespace Client.Models
{
    public class PaymentResponseDto
    {
        public int id { get; set; }
        public int reservationId { get; set; }
        public decimal amount { get; set; }
        public string method { get; set; }
        public string status { get; set; }
        public string createdAt { get; set; }
    }

    public class AdminUserDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string role { get; set; }
    }

    public class AdminReservationDto
    {
        public int id { get; set; }
        public int tripId { get; set; }
        public int userId { get; set; }
        public int seatsReserved { get; set; }
        public string paymentMethod { get; set; }
        public string paymentStatus { get; set; }
    }
}
