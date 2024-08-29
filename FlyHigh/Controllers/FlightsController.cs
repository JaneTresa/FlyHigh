using AutoMapper;
using FlyHigh.Domain.DTO;
using FlyHigh.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FlyHigh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightService _flightService;
        private readonly IMapper _mapper;

        public FlightsController(IFlightService flightService, IMapper mapper)
        {
            _flightService = flightService;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns flights based on the filters applied
        /// </summary>
        /// <param name="FromAirport"></param>
        /// <param name="ToAirport"></param>
        /// <param name="Airline"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("flights")]
        public async Task<IActionResult> GetFlightsByFilters(string? FromAirport, string? ToAirport, string? Airline)
        {
            var content = new FailedRequest();
            try
            {
                var result = await _flightService.GetFlightsByFilters(FromAirport, ToAirport, Airline);
                if (!result.Any())
                {
                    content.Error = "No data found";
                    content.StatusCode = NoContent().StatusCode;
                    return Content(JsonConvert.SerializeObject(content), "application/json");
                }
                return Ok(result);
            }
            catch(Exception ex)
            {
                content.Error = ex.Message;
                content.StatusCode = BadRequest().StatusCode;
                return Content(JsonConvert.SerializeObject(content), "application/json");
            }
        }
    }
}
