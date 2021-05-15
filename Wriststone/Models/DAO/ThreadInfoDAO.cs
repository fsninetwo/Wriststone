using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wriststone.Models.ViewModel;

namespace Wriststone.Models.DAO
{
    public class ThreadInfoDAO : IEntityDAO<ThreadInfoModel>
    {
        WriststoneContext db = new WriststoneContext();

        public void DeleteById(ThreadInfoModel entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(ThreadInfoModel entity)
        {
            throw new NotImplementedException();
        }

        public ThreadInfoModel Select(long? id)
        {
            throw new NotImplementedException();
        }

        public List<ThreadInfoModel> SelectItems()
        {
            throw new NotImplementedException();
        }

        public List<ThreadInfoModel> SelectItemsByCateogry(long category)
        {
            var result = from thread in db.Threads
                         join forumcategories in db.ForumCategories on thread.Category equals forumcategories.Id
                         where forumcategories.Id == category
                         select new ThreadInfoModel
                         {
                             Thread = thread,
                             Creator = db.Accounts.Where(e => e.Id == thread.Account).Single(),
                             Poster = db.Accounts.Where(e => e.Id == db.Posts.Where(e => e.Thread == thread.Id
                             && e.ThreadOrder == db.Posts.Where(e => e.Thread == thread.Id).Max(e => e.ThreadOrder)).Single().Account).Single(),
                             Posts = db.Posts.Where(e => e.Thread == thread.Id).Count(),
                             LastPost = db.Posts.Where(e => e.Thread == thread.Id).OrderByDescending(e => e.ThreadOrder).FirstOrDefault()
                         };
            return result.ToList();
        }

        public List<ThreadInfoModel> SelectItemsBySearch(string search)
        {
            var result = from thread in db.Threads
                         join forumcategories in db.ForumCategories on thread.Category equals forumcategories.Id
                         where thread.Subject.Contains(search)
                         select new ThreadInfoModel
                         {
                             Thread = thread,
                             Creator = db.Accounts.Where(e => e.Id == thread.Account).Single(),
                             Poster = db.Accounts.Where(e => e.Id == db.Posts.Where(e => e.Thread == thread.Id
                             && e.Created == db.Posts.Where(e => e.Thread == thread.Id).OrderByDescending(e => e.Created).FirstOrDefault().Created).Single().Account).Single(),
                             Posts = db.Posts.Where(e => e.Thread == thread.Id).Count()
                         };
            return result.ToList();
        }

        public void UpdateById(long id, ThreadInfoModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
