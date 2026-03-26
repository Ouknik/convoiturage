namespace Serveur.DTOs.Trips;

public class TripQueryParamsDto
{
    private const int MaxPageSize = 50;

    public string? City { get; set; }
    public DateTime? Date { get; set; }

    public int PageNumber { get; set; } = 1;

    private int _pageSize = 10;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
    }
}
