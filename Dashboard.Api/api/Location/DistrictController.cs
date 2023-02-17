using Dashboard.Helper.Dtos.Location;
using Dashboard.Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dashboard.Api
{
    [Route("api/[controller]")]
    public class DistrictController : BaseApiController
    {
        IDistrictRepository _districtRepository;
        public DistrictController(
            IDistrictRepository districtRepository
            )
        {
            _districtRepository = districtRepository;
        }
        
        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllDistricts([FromBody]DistrictDto districtDto)
        {
            return await Execute(_districtRepository.GetDistrictsAysnc, districtDto);
        }
    }
}
