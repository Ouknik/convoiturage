using System.Collections.Generic;

namespace Client.Models
{
    public class TripResponseDto
    {
        public int id { get; set; }
        public string departure { get; set; }
        public string destination { get; set; }
        public string departureTime { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string startTime { get; set; }
        public int numberOfDays { get; set; }
        public decimal pricePerSeat { get; set; }
        public string createdAt { get; set; }
        public string status { get; set; }
        public int availableSeats { get; set; }
        public int driverId { get; set; }
    }

    public class TripCreateDto
    {
        public string departure { get; set; }
        public string destination { get; set; }
        public string departureTime { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string startTime { get; set; }
        public int numberOfDays { get; set; }
        public decimal pricePerSeat { get; set; }
        public int availableSeats { get; set; }
    }

    public class PagedResultDto<T>
    {
        public List<T> items { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public int totalCount { get; set; }
    }
}
