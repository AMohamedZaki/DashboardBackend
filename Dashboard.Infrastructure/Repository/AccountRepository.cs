using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Core.Entities;
using Dashboard.Helper;
using Dashboard.Helper.Dtos.Account;
using Dashboard.Infrastructure.Data;
using Dashboard.Infrastructure.Repository.Interfaces;

namespace Dashboard.Infrastructure.Repository
{
    public class AccountRepository : RepositoryBaseGeneric<Account>, IAccountRepository
    {
        public AccountRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<List<Account>> GetAccountsAysnc(AccountFilterDto AccountFilterDto)
        {
            var accounts = GetQuerable();
            if (AccountFilterDto != null && !string.IsNullOrEmpty(AccountFilterDto.Name))
            {
                accounts = accounts.Where(acc => acc.Name.ToLower().Contains(AccountFilterDto.Name.ToLower()));
            }
            if (AccountFilterDto != null && !string.IsNullOrEmpty(AccountFilterDto.Tel))
            {
                accounts = accounts.Where(acc => acc.Tel.ToLower().Contains(AccountFilterDto.Tel.ToLower()));
            }
            if (AccountFilterDto != null && !string.IsNullOrEmpty(AccountFilterDto.Tel2))
            {
                accounts = accounts.Where(acc => acc.Tel2.ToLower().Contains(AccountFilterDto.Tel2.ToLower()));
            }
            if (AccountFilterDto != null && !string.IsNullOrEmpty(AccountFilterDto.Tel3))
            {
                accounts = accounts.Where(acc => acc.Tel3.ToLower().Contains(AccountFilterDto.Tel3.ToLower()));
            }

            return new PagedList<Account>(accounts, AccountFilterDto.PageIndex, AccountFilterDto.PageSize);
        }

        public override void Add(Account entity)
        {
            try
            {
                // enter your code
                base.Add(entity);
                base.SaveDbChanges();
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        public async Task<List<Account>> GetAccountsByTelAysnc(AccountTelDto AccountTelDto)
        {
            var accounts = GetDbSet()
                .Include(account => account.Contact)
                .Include(account => account.City)
                .Include(account => account.District)
                .AsQueryable();
            if (AccountTelDto != null && !string.IsNullOrEmpty(AccountTelDto.tel))
            {
                accounts = accounts.Where(acc =>
                acc.Tel.ToLower().Contains(AccountTelDto.tel.ToLower()) ||
                acc.Tel2.ToLower().Contains(AccountTelDto.tel.ToLower()) ||
                acc.Tel3.ToLower().Contains(AccountTelDto.tel.ToLower()) ||
                acc.Contact.Any(contact => contact.Mob.ToLower().Contains(AccountTelDto.tel.ToLower()) ||
                contact.Mob2.ToLower().Contains(AccountTelDto.tel.ToLower()) ||
                contact.Mob3.ToLower().Contains(AccountTelDto.tel.ToLower())
                ));
            }
            var _accounts = accounts.ToList().Select(_account =>
             {
                 _account.City= null;
                 _account.City.Account = null;

                 _account.District.Account = null;
                 _account.District.City= null;
                 return _account;

             });

            return new PagedList<Account>(_accounts, AccountTelDto.PageIndex, AccountTelDto.PageSize);
        }
    }
}
