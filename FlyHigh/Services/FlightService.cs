using AutoMapper;
using FlyHigh.Domain.DTO;
using FlyHigh.Domain.Models;
using FlyHigh.Interfaces;
using System.Text.RegularExpressions;

namespace FlyHigh.Services
{
    public class FlightService : IFlightService
    {
        private readonly IQueryFlights _queryFlights;
        private readonly IMapper _mapper;
        private readonly ILoggerService _logger;

        public FlightService(IQueryFlights queryFlights, IMapper mapper, ILoggerService logger) 
        {
            _queryFlights = queryFlights;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// validates filters and maps query result from database
        /// </summary>
        /// <param name="originCode"></param>
        /// <param name="destinationCode"></param>
        /// <param name="airlineCode"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<FlightsResponse>> GetFlightsByFilters(string originCode, string destinationCode, string airlineCode)
        {
            try
            {
                InputValidation(originCode, destinationCode, airlineCode);
                var queryResult = await _queryFlights.GetFlightsByFilters(originCode, destinationCode, airlineCode);
                _logger.Log($"Mapping models to Dto at {DateTime.UtcNow}");
                return _mapper.Map<List<Flight>, List<FlightsResponse>>(queryResult);
            }
            catch (Exception ex) 
            {
                _logger.Log($"{ex.Message} event at {DateTime.UtcNow}");
                throw new Exception(ex.Message);
            }
            
        }

        private static void InputValidation(string originCode, string destinationCode, string airlineCode)
        {
            var regex = new Regex(@"^[a-zA-Z]{3}$");
            var regexAirlineCode = new Regex(@"^[a-zA-Z]{2}$");
            if(!string.IsNullOrEmpty(originCode) && !regex.IsMatch(originCode))
            {
                throw new ArgumentException("From airport code is invalid", nameof(originCode));
            }
            if (!string.IsNullOrEmpty(destinationCode) && !regex.IsMatch(destinationCode))
            {
                throw new ArgumentException("To airport code is invalid", nameof(destinationCode));
            }
            if (!string.IsNullOrEmpty(airlineCode) && !regexAirlineCode.IsMatch(airlineCode))
            {
                throw new ArgumentException("Airline code is invalid", nameof(airlineCode));
            }
        }
    }
}
