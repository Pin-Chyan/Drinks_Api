namespace Saluteo.Services.Entity
{
    using Saluteo.Models.Entity;
    using Saluteo.Repository;

    public class LocationService
    {
        private readonly IGenericRepository<Location> _locationRepository;

        public LocationService(IGenericRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<List<Location>> GetAllLocationsAsync()
        {
            var locations = await _locationRepository.GetAllAsync();

            return locations.ToList();
        }

        public async Task<Location?> CreateLocationAsync(LocationDto locationDto)
        {
            if (locationDto == null)
            {
                return null;
            }

            var location = new Location
            {
                Coordinate = locationDto.Coordinate,
                Address = locationDto.Address,
                RegionId = locationDto.RegionId,
            };

            await _locationRepository.InsertAsync(location);

            return location;
        }

        public async Task<Location?> GetLocationByIdAsync(long id)
        {
            var location = await _locationRepository.GetByIdAsync(id);

            return location;
        }

        public async Task<Location?> UpdateLocationAsync(long id, LocationDto updatedLocationDto)
        {
            var existingLocation = await _locationRepository.GetByIdAsync(id);
            if (existingLocation == null)
            {
                return null;
            }

            existingLocation.Coordinate = updatedLocationDto.Coordinate;
            existingLocation.Address = updatedLocationDto.Address;
            existingLocation.RegionId = updatedLocationDto.RegionId;

            await _locationRepository.UpdateAsync(existingLocation);
            return existingLocation;
        }

        public async Task<bool> DeleteLocationAsync(long id)
        {
            var existingLocation = await _locationRepository.GetByIdAsync(id);
            if (existingLocation == null)
            {
                return false;
            }

            await _locationRepository.DeleteAsync(id);
            return true;
        }
    }
}
