using FlyHigh.Domain.DTO;
using FlyHigh.Domain.Models;
using AutoMapper;

namespace FlyHigh.Services
{
    public class MapperService : Profile
    {
        public MapperService() 
        {
            CreateMap<Flight, FlightsResponse>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.FlightId))
            .ForMember(dest => dest.FlightOrigin, opt => opt.MapFrom(src => src.OriginStation))
            .ForMember(dest => dest.FlightDestination, opt => opt.MapFrom(src => src.DestinationStation))
            .ForMember(dest => dest.AvailableFrom, opt => opt.MapFrom(src => src.FlightsAvailableFrom))
            .ForMember(dest => dest.AvailableTo, opt => opt.MapFrom(src => src.FlightsAvailableTo))
            .ForMember(dest => dest.AircraftCode, opt => opt.MapFrom(src => src.AirlineCode));
            CreateMap<FlightsResponse, Flight>();
        }
    }
}
