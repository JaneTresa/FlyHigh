namespace FlyHigh.Domain.DTO
{
    public class FlightsResponse
    {
        public long Id { get; set; }
        public string FlightOrigin { get; set; }
        public string FlightDestination { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableTo { get; set; }
        public string AircraftCode { get; set; }

    }
}
