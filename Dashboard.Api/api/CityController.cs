using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Dashboard.Helper.Dtos.City;
using Dashboard.Infrastructure.Repository.Interfaces;

namespace Dashboard.Api.api
{
    [Route("api/[controller]")]
    public class CityController : BaseApiController
    {
        ICityRepository _cityRepository;
        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll([FromBody] CityFilterDto cityFilterDto)
        {
            return await Execute(_cityRepository.GetCitiesAysnc, cityFilterDto);
        }
    }
}
