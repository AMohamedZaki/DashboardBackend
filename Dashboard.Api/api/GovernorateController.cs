using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Dashboard.Helper.Dtos.City;
using Dashboard.Infrastructure.Repository.Interfaces;

namespace Dashboard.Api.api
{
    [Route("api/[controller]")]
    public class GovernorateController : BaseApiController
    {
        IGovernorateRepository _govRepository;
        public GovernorateController(IGovernorateRepository governorateRepository)
        {
            _govRepository = governorateRepository;
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll(GovernorateFilterDto gvernorateFilterDto)
        {
            return await Execute(_govRepository.GetGovernoratesAysnc, gvernorateFilterDto);
        }

    }
}
