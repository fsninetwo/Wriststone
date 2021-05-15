using System;
using System.Collections.Generic;
using System.Linq;
using Wriststone.Models.ViewModel;

namespace Wriststone.Models.DAO
{
    public class CategoryThreadsDAO : IEntityDAO<CategoryThreadsModel>
    {
        WriststoneContext db = new WriststoneContext();
        ThreadInfoDAO ThreadInfoDAO = new ThreadInfoDAO();
        public void DeleteById(CategoryThreadsModel entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(CategoryThreadsModel entity)
        {
            throw new NotImplementedException();
        }

        public CategoryThreadsModel Select(long? id)
        {
            var threads = ThreadInfoDAO.SelectItemsByCateogry(id.Value).OrderByDescending(e => e.Thread.Updated);
            return new CategoryThreadsModel
            {
                Category = db.ForumCategories.Where(e => e.Id == id).Single(),
                Categories = db.ForumCategories.Where(e => e.Category == id).ToList().AsEnumerable(),
                Threads = threads.Take(1),
                Pages = threads.Count() / 1
            };
        }

        public CategoryThreadsModel SelectByPage(long? id, long page, int capacity = 20)
        {
            var threads = ThreadInfoDAO.SelectItemsByCateogry(id.Value).OrderByDescending(e => e.Thread.Updated);
            return new CategoryThreadsModel
            {
                Category = db.ForumCategories.Where(e => e.Id == id).Single(),
                Categories = db.ForumCategories.Where(e => e.Category == id).ToList().AsEnumerable(),
                Threads = threads.Skip(capacity * (int)page).Take(capacity),
                Page = page,
                Pages = threads.Count() / capacity
            };
        }

        public long SelectId(string name, string path)
        {
            throw new NotImplementedException();
        }

        public List<CategoryThreadsModel> SelectItems()
        {
            throw new NotImplementedException();
        }

        public List<CategoryThreadsModel> SelectItemsByText(string text)
        {
            throw new NotImplementedException();
        }

        public void UpdateById(long id, CategoryThreadsModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
