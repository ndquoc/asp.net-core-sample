using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyCms.DAL.Entities;

namespace TinyCms.DAL.Repositories
{
    public interface IContactRepository: IGenericRepository<Contact>
    {
        Contact GetSingle(int contactId);
    }
}
