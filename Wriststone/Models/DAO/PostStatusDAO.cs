using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wriststone.Models.Table;

namespace Wriststone.Models.DAO
{
    public class PostStatusDAO : IEntityDAO<PostStatus>
    {
        WriststoneContext db = new WriststoneContext();

        public void DeleteById(PostStatus entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(PostStatus entity)
        {
            throw new NotImplementedException();
        }

        public long SelectByName(string name)
        {
            return db.PostStatuses.Where(e => e.Name.Equals(name)).Single().Id.Value;
        }

        public void UpdateById(long id, PostStatus entity)
        {
            throw new NotImplementedException();
        }

        PostStatus IEntityDAO<PostStatus>.Select(long? id)
        {
            throw new NotImplementedException();
        }

        List<PostStatus> IEntityDAO<PostStatus>.SelectItems()
        {
            throw new NotImplementedException();
        }
    }
}
