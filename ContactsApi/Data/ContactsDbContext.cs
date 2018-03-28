using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsApi.Data
{
    public class ContactsDbContext : DbContext
    {
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
            :base(options) { }
        public ContactsDbContext(){ }
        public DbSet<Contacts> Contacts { get; set; }
    }
}
