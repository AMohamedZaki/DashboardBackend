using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.Core.Entities;
using Dashboard.Helper.Dtos;
using Dashboard.Helper.Dtos.Account;

namespace Dashboard.Infrastructure.Serives.interfaces
{
    public interface IAccountService
    {
        Task<Account> Add(AccountDto accountDto);
        Task<List<Account>> GetAccountByPhone(AccountTelDto AccountFilterDto);
        Task<Account> Update(AccountDto accountDto);
        Task<List<Account>> GetAccountsAysnc(AccountFilterDto AccountFilterDto);
    }
}
