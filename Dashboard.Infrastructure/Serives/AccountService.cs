using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.Core.Entities;
using Dashboard.Helper.Dtos;
using Dashboard.Helper.Dtos.Account;
using Dashboard.Infrastructure.Repository.Interfaces;
using Dashboard.Infrastructure.Serives.interfaces;

namespace Dashboard.Infrastructure.Serives
{
    public class AccountService : IAccountService
    {
        private IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        public AccountService(IMapper mapper, IAccountRepository accountRepository)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
        }
        public async Task<Account> Add(AccountDto accountDto)
        {
            var account = _mapper.Map<Account>(accountDto);
            await Task.Run(() => _accountRepository.Add(account));
            return account;
        }

        public async Task<List<Account>> GetAccountByPhone(AccountTelDto AccountFilterDto)
        {
            var accounts = await _accountRepository.GetAccountsByTelAysnc(AccountFilterDto);
            return accounts;
        }

        public async Task<Account> Update(AccountDto accountDto)
        {
            // var account = _accountRepository.GetById(accountDto.Id);


            return null;
        }

        public async Task<List<Account>> GetAccountsAysnc(AccountFilterDto AccountFilterDto)
        {
            return await _accountRepository.GetAccountsAysnc(AccountFilterDto);
        }
    }
}
