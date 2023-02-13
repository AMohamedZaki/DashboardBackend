using Microsoft.AspNetCore.Mvc;

namespace Zanobia.Api.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : BaseApiController
    {
        public BranchController()
        {
        }

        //[HttpPost("GetAll")]
        //public async Task<IActionResult> GetAll([FromBody] BranchDto branchFilterDto)
        //{
        //    return await Execute(_branchRepository.GetBranchesAysnc, branchFilterDto);
        //}
    }
}
