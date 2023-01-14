using System.Collections.Generic;
using System.Threading.Tasks;
using Dashboard.Core.Entities;
using Dashboard.Helper.Dtos.Contact;

namespace Dashboard.Infrastructure.Repository.Interfaces
{
    public interface IContactRepository : IRepository<Contact>
    {
        Task<List<Contact>> GetContactsAysnc(ContactFilterDto ContactFilterDto);
    }

}
