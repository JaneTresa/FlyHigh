using FlyHigh.Data;
using FlyHigh.Interfaces;
using Microsoft.EntityFrameworkCore;
using FlyHigh.Domain.Models;
using LinqKit;

namespace FlyHigh.Repositories
{
    public class FlightsRepository : IQueryFlights
    {
        private readonly FlightsDbContext _dbContext;
        private readonly ILoggerService _logger;

        public FlightsRepository(FlightsDbContext flightsDbContext, ILoggerService logger) 
        {
            _dbContext = flightsDbContext;
            _logger = logger;
        }

        /// <summary>
        /// Queries database based on the predicate
        /// </summary>
        /// <param name="originCode"></param>
        /// <param name="destinationCode"></param>
        /// <param name="airlineCode"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Flight>> GetFlightsByFilters(string originCode, string destinationCode, string airlineCode)
        {
            try
            {
                var predicate = PredicateBuilder.New<Flight>(true);
                string filters = string.Empty;

                if (!string.IsNullOrEmpty(originCode))
                {
                    predicate = predicate.And(x => x.OriginStation.Equals(originCode));
                    filters += originCode + " ";
                }
                if (!string.IsNullOrEmpty(destinationCode))
                {
                    predicate = predicate.And(x => x.DestinationStation.Equals(destinationCode));
                    filters += destinationCode + " ";
                }
                if (!string.IsNullOrEmpty(airlineCode))
                {
                    predicate = predicate.And(x => x.AirlineCode.Equals(airlineCode));
                    filters += airlineCode + " ";
                }
                _logger.Log($"Search based on filters : {filters}");
                return await _dbContext.Flight.Where(predicate).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.Log(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
