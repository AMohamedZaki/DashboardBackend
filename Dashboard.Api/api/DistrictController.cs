using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Dashboard.Helper.Dtos.City;
using Dashboard.Infrastructure.Repository.Interfaces;

namespace Dashboard.Api.api
{
    [Route("api/[controller]")]
    public class DistrictController : BaseApiController
    {
        IDistrictRepository _districtRepository;
        public DistrictController(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll([FromBody] DistrictFilterDto districtFilterDto)
        {
            return await Execute(_districtRepository.GetDistrictsAysnc, districtFilterDto);
        }

    }
}
