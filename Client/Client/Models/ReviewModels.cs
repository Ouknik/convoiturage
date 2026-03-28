using System.Collections.Generic;

namespace Client.Models
{
    public class ReviewCreateDto
    {
        public int tripId { get; set; }
        public int rating { get; set; }
        public string comment { get; set; }
    }

    public class ReviewResponseDto
    {
        public int id { get; set; }
        public int driverId { get; set; }
        public int passengerId { get; set; }
        public int tripId { get; set; }
        public int rating { get; set; }
        public string comment { get; set; }
        public string createdAt { get; set; }
        public string passengerName { get; set; }
    }

    public class DriverProfileDto
    {
        public int driverId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public string bio { get; set; }
        public int totalTripsCreated { get; set; }
        public int totalReservationsReceived { get; set; }
        public double averageRating { get; set; }
        public int totalReviews { get; set; }
        public List<ReviewResponseDto> reviews { get; set; }
    }
}
