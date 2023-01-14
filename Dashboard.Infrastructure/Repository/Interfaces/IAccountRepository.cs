using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.Core.Entities;
using Dashboard.Helper.Dtos.Account;

namespace Dashboard.Infrastructure.Repository.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<List<Account>> GetAccountsAysnc(AccountFilterDto AccountFilterDto);
        Task<List<Account>> GetAccountsByTelAysnc(AccountTelDto AccountTelDto);
    }

}
