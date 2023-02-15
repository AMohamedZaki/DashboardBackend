using Dashboard.Helper.Dtos.Location;
using Dashboard.Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dashboard.Api
{
    [Route("api/[controller]")]
    public class LocationController : BaseApiController
    {
        IRegionRepository _regionRepository;
        ICityRepository _cityRepository;
        IDistrictRepository _districtRepository;
        public LocationController(IRegionRepository regionRepository,
            ICityRepository cityRepository,
            IDistrictRepository districtRepository
            )
        {
            _regionRepository = regionRepository;
            _cityRepository = cityRepository;
            _districtRepository = districtRepository;
        }

        [HttpPost("GetAllRegion")]
        public async Task<IActionResult> GetAllRegion([FromBody]RegionDto regionDto)
        {
            return await Execute(_regionRepository.GetRegionsAysnc, regionDto);
        }


        [HttpPost("GetAllCities")]
        public async Task<IActionResult> GetAllCities([FromBody]CityDto cityDto)
        {
            return await Execute(_cityRepository.GetCitiesAysnc, cityDto);
        }
        
        
        [HttpPost("GetAllDistricts")]
        public async Task<IActionResult> GetAllDistricts([FromBody]DistrictDto districtDto)
        {
            return await Execute(_districtRepository.GetDistrictsAysnc, districtDto);
        }
    }
}
