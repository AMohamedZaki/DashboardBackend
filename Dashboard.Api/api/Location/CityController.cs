using Dashboard.Helper.Dtos.Location;
using Dashboard.Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dashboard.Api
{
    [Route("api/[controller]")]
    public class CityController : BaseApiController
    {
        ICityRepository _cityRepository;
        public CityController(IRegionRepository regionRepository,
            ICityRepository cityRepository,
            IDistrictRepository districtRepository
            )
        {
            _cityRepository = cityRepository;
        }


        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll([FromBody]CityDto cityDto)
        {
            return await Execute(_cityRepository.GetCitiesAysnc, cityDto);
        }
    }
}
