using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContactsApi.Models;

namespace ContactsApi.Repository
{
    public interface IContactsRepository
    {
        Task Add(Contacts item);
        Task<IEnumerable<Contacts>> GetAll();
        Task<Contacts> Find(string key);
        Task Remove(string id);
        Task Update(Contacts item);
    }
}
