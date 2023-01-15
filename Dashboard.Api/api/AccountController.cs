using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Dashboard.Helper.Dtos;
using Dashboard.Helper.Dtos.Account;
using Dashboard.Infrastructure.Serives.interfaces;

namespace Dashboard.Api.api
{
    [Route("api/[controller]")]
    public class AccountController : BaseApiController
    {
        IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll(AccountFilterDto accountFilterDto)
        {
            return await Execute(_accountService.GetAccountsAysnc, accountFilterDto);
        }

        [HttpPost("AddAccount")]
        public async Task<IActionResult> AddAccount([FromBody] AccountDto AccountDto)
        {
            return await Execute(_accountService.Add, AccountDto);
        }
        
        
        [HttpPost("UpdateAccount")]
        public async Task<IActionResult> UpdateAccount([FromBody] AccountDto AccountDto)
        {
            var account = _accountService.Update(AccountDto);
            return Ok(account);
        }

        [HttpPost("getAccountByPhone")]
        public async Task<IActionResult> getAccountByPhone([FromBody] AccountTelDto accountTelDto)
        {
            return await Execute(_accountService.GetAccountByPhone, accountTelDto);
        }



    }
}
