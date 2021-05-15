using System;
using System.Collections.Generic;
using System.Linq;
using Wriststone.Models.Table;

namespace Wriststone.Models.DAO
{
    public class ForumCategoryDAO : IEntityDAO<ForumCategory>
    {
        WriststoneContext db = new WriststoneContext();

        public void DeleteById(ForumCategory entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(ForumCategory entity)
        {
            throw new NotImplementedException();
        }

        public ForumCategory Select(long? id)
        {
            return db.ForumCategories.Where(e => e.Id == id).Single();
        }

        public long SelectId(string name, string path)
        {
            throw new NotImplementedException();
        }

        public List<ForumCategory> SelectItems()
        {
            throw new NotImplementedException();
        }

        public List<ForumCategory> SelectItemsByCategory(long? category)
        {
            return db.ForumCategories.Where(e => e.Category == category).ToList();
        }

        public List<ForumCategory> SelectItemsByText(string text)
        {
            throw new NotImplementedException();
        }
        public void UpdateById(long id, ForumCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}
