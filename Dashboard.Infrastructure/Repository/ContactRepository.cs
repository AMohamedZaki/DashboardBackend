using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Core.Entities;
using Dashboard.Helper;
using Dashboard.Helper.Dtos.City;
using Dashboard.Helper.Dtos.Contact;
using Dashboard.Infrastructure.Data;
using Dashboard.Infrastructure.Repository.Interfaces;

namespace Dashboard.Infrastructure.Repository
{
    public class ContactRepository : RepositoryBaseGeneric<Contact>, IContactRepository
    {
        public ContactRepository(AppDbContext context) : base(context)
        {

        }

         public async Task<List<Contact>> GetContactsAysnc(ContactFilterDto ContactFilterDto)
        {
            var contacts = GetQuerable();
            if (ContactFilterDto != null)
            {
                if (!string.IsNullOrEmpty(ContactFilterDto.Name))
                {
                    contacts = contacts.Where(acc => acc.Name.ToLower().Contains(ContactFilterDto.Name.ToLower()));
                }
                if (!string.IsNullOrEmpty(ContactFilterDto.Mob))
                {
                    contacts = contacts.Where(acc => acc.Mob.ToLower().Contains(ContactFilterDto.Mob.ToLower()));
                }
                if (!string.IsNullOrEmpty(ContactFilterDto.Mob2))
                {
                    contacts = contacts.Where(acc => acc.Mob2.ToLower().Contains(ContactFilterDto.Mob2.ToLower()));
                }
                if (!string.IsNullOrEmpty(ContactFilterDto.Mob3))
                {
                    contacts = contacts.Where(acc => acc.Mob3.ToLower().Contains(ContactFilterDto.Mob3.ToLower()));
                } 
            }

            return new PagedList<Contact>(contacts, ContactFilterDto.PageIndex, ContactFilterDto.PageSize);
        }


    }
}
