using System.Collections.Generic;

namespace Client.Models
{
    public class TripResponseDto
    {
        public int id { get; set; }
        public string departure { get; set; }
        public string destination { get; set; }
        public string date { get; set; }
        public int availableSeats { get; set; }
        public int driverId { get; set; }
    }

    public class TripCreateDto
    {
        public string departure { get; set; }
        public string destination { get; set; }
        public string date { get; set; }
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
