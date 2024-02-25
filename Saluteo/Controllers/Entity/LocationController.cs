namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Services.Entity;

    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly LocationService _locationService;

        public LocationController(LocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetAllLocations()
        {
            var locations = await _locationService.GetAllLocationsAsync();

            return Ok(locations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocationById(long id)
        {
            var location = await _locationService.GetLocationByIdAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        [HttpPost]
        public async Task<ActionResult<Location>> CreateLocation([FromBody] LocationDto locationDto)
        {
            var createdLocation = await _locationService.CreateLocationAsync(locationDto);
            if (createdLocation == null)
            {
                return BadRequest("Invalid data");
            }

            return Ok(createdLocation);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Location>> UpdateLocation(long id, [FromBody] LocationDto updatedLocationDto)
        {
            var updatedLocation = await _locationService.UpdateLocationAsync(id, updatedLocationDto);
            if (updatedLocation == null)
            {
                return NotFound();
            }

            return Ok(updatedLocation);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLocation(long id)
        {
            var isDeleted = await _locationService.DeleteLocationAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
