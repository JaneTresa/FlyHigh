using FlyHigh.Domain.DTO;

namespace FlyHigh.Interfaces
{
    public interface IFlightService
    {
        Task<List<FlightsResponse>> GetFlightsByFilters(string originCode, string destinationCode, string airlineCode);
    }
}
