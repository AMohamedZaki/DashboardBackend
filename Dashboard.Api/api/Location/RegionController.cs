using Dashboard.Helper.Dtos.Location;
using Dashboard.Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dashboard.Api
{
    [Route("api/[controller]")]
    public class RegionController : BaseApiController
    {
        IRegionRepository _regionRepository;
        public RegionController(IRegionRepository regionRepository,
            ICityRepository cityRepository,
            IDistrictRepository districtRepository
            )
        {
            _regionRepository = regionRepository;
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll([FromBody]RegionDto regionDto)
        {
            return await Execute(_regionRepository.GetRegionsAysnc, regionDto);
        }

    }
}
