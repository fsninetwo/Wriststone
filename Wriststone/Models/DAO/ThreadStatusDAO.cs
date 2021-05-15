using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wriststone.Models.Table;

namespace Wriststone.Models.DAO
{
    public class ThreadStatusDAO : IEntityDAO<ThreadStatus>
    {
        WriststoneContext db = new WriststoneContext();

        public void DeleteById(ThreadStatus entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(ThreadStatus entity)
        {
            throw new NotImplementedException();
        }

        public ThreadStatus Select(long? id)
        {
            throw new NotImplementedException();
        }

        public long SelectByName(string name)
        {
            return db.ThreadStatuses.Where(e => e.Name.Equals(name)).Single().Id;
        }

        public List<ThreadStatus> SelectItems()
        {
            throw new NotImplementedException();
        }

        public void UpdateById(long id, ThreadStatus entity)
        {
            throw new NotImplementedException();
        }
    }
}
