using FlyHigh.Domain.Models;

namespace FlyHigh.Interfaces
{
    public interface IQueryFlights
    {
        Task<List<Flight>> GetFlightsByFilters(string originCode, string destinationCode, string airlineCode);

    }
}
