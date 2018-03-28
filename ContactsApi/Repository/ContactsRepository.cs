using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsApi.Data;
using ContactsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsApi.Repository
{
    public class ContactsRepository : IContactsRepository
    {
        private ContactsDbContext _dbContext;

        public ContactsRepository(ContactsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Contacts item)
        {
            await _dbContext.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Contacts>> GetAll()
        {
            return await _dbContext.Contacts.ToListAsync();
        }

        public async Task<Contacts> Find(string key)
        {
            return await _dbContext.Contacts
                .Where(e => e.MobilePhone.Equals(key))
                .SingleOrDefaultAsync();
        }

        public async Task Remove(string id)
        {
            var itemToRemove = await _dbContext.Contacts.SingleOrDefaultAsync(r => r.MobilePhone == id);
            if (itemToRemove != null)
            {
                _dbContext.Contacts.Remove(itemToRemove);
               await _dbContext.SaveChangesAsync();
            }
            
        }

        public async Task Update(Contacts item)
        {
            var itemToUpdate = await _dbContext.Contacts.SingleOrDefaultAsync(r => r.MobilePhone == item.MobilePhone);
            if (itemToUpdate != null)
            {
                itemToUpdate.FirstName = item.FirstName;
                itemToUpdate.LastName = item.LastName;
                itemToUpdate.IsFamilyMember = item.IsFamilyMember;
                itemToUpdate.Company = item.Company;
                itemToUpdate.JobTitle = item.JobTitle;
                itemToUpdate.Email = item.Email;
                itemToUpdate.MobilePhone = item.MobilePhone;
                itemToUpdate.DateOfBirth = item.DateOfBirth;
                itemToUpdate.AnniversaryDate = item.AnniversaryDate;
                await _dbContext.SaveChangesAsync();
            }

            
        }

    }
}
