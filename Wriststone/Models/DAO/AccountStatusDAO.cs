using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wriststone.Models.Table;

namespace Wriststone.Models.DAO
{
    public class AccountStatusDAO : IEntityDAO<AccountStatus>
    {
        WriststoneContext db = new WriststoneContext();

        public void DeleteById(AccountStatus entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(AccountStatus entity)
        {
            throw new NotImplementedException();
        }

        public AccountStatus Select(long? id)
        {
            throw new NotImplementedException();
        }

        public long SelectByName(string name)
        {
            return db.AccountStatuses.Where(e => e.Name.Equals(name)).Single().Id.Value;
        }

        public List<AccountStatus> SelectItems()
        {
            throw new NotImplementedException();
        }

        public void UpdateById(long id, AccountStatus entity)
        {
            throw new NotImplementedException();
        }
    }
}
