using AutoMapper;
using Dashboard.Core.Entities;
using Dashboard.Helper.Dtos;
using Dashboard.Helper.Dtos.Contact;

namespace Dashboard.Api.MappingProfiles
{
    public class AccountMapProfile: Profile
    {
        public AccountMapProfile()
        {
            
            // Map Account
            CreateMap<AccountDto, Account>();
            CreateMap<Account, AccountDto>();


            // Map Contract
            CreateMap<ContactDto, Contact>();
            CreateMap<Contact, ContactDto>();
        }
    }
}
