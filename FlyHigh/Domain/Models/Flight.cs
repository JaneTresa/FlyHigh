namespace FlyHigh.Domain.Models
{
    public class Flight
    {
        public long FlightId { get; set; }
        public string OriginStation { get; set; }
        public string DestinationStation { get; set; }
        public DateTime FlightsAvailableFrom { get; set; }
        public DateTime FlightsAvailableTo { get; set; }
        public string AirlineCode { get; set; }

    }
}
