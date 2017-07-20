using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyCms.DAL.Entities;

namespace TinyCms.DAL.Repositories
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        public ContactRepository(ApplicationDataContext dbContext) : base(dbContext)
        {
        }

        public Contact GetSingle(int contactId)
        {
            return GetAll().FirstOrDefault(p => p.Id == contactId);            
        }
    }
}
