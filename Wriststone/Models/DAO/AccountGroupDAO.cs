using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wriststone.Models.Table;

namespace Wriststone.Models.DAO
{
    public class AccountGroupDAO : IEntityDAO<AccountGroup>
    {
        WriststoneContext db = new WriststoneContext();

        public void DeleteById(AccountGroup entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(AccountGroup entity)
        {
            throw new NotImplementedException();
        }

        public AccountGroup Select(long? id)
        {
            throw new NotImplementedException();
        }

        public long SelectByName(string name)
        {
            return db.AccountGroups.Where(e => e.Name.Equals(name)).Single().Id.Value;
        }

        public List<AccountGroup> SelectItems()
        {
            throw new NotImplementedException();
        }

        public void UpdateById(long id, AccountGroup entity)
        {
            throw new NotImplementedException();
        }
    }
}
