namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Repository;

    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IRepository<Location> _locationRepository;

        public LocationController(IRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Location>> GetAllLocations()
        {
            var locations = _locationRepository.GetAll().ToList();
            return Ok(locations);
        }

        [HttpPost]
        public ActionResult CreateLocation([FromBody] LocationDto locationDto)
        {
            if (locationDto == null)
            {
                return BadRequest("Invalid data");
            }

            // Mapper :/
            var location = new Location
            {
                Coordinate = locationDto.Coordinate,
                Address = locationDto.Address,
                RegionId = locationDto.RegionId,
            };

            _locationRepository.Insert(location);

            return Ok(location);
        }
    }
}
