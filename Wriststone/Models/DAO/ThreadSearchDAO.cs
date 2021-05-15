using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wriststone.Models.ViewModel;

namespace Wriststone.Models.DAO
{
    public class ThreadSearchDAO : IEntityDAO<ThreadSearchModel>
    {
        WriststoneContext db = new WriststoneContext();
        public void DeleteById(ThreadSearchModel entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(ThreadSearchModel entity)
        {
            throw new NotImplementedException();
        }

        public ThreadSearchModel Select(long? id)
        {
            throw new NotImplementedException();
        }

        public List<ThreadSearchModel> FindThreads(string name)
        {
            var result = from thread in db.Threads
                         join post in db.Posts on thread.Id equals post.Thread
                         where post.Context.ToLower().Contains(name.ToLower())
                         select new ThreadSearchModel
                         {
                             Thread = thread,
                             Post = post,
                             Creator = db.Accounts.Where(e => e.Id == thread.Account).Single(),
                             Poster = db.Accounts.Where(e => e.Id == post.Account.Value).Single(),
                             Posts = db.Posts.Where(e => e.Thread == thread.Id).Count(), 
                         };
            var threads = result.ToList();
            var words = name.Split(" ");
            foreach (var word in words)
            {
                var secondresult = from thread in db.Threads
                                   join post in db.Posts on thread.Id equals post.Thread
                                   where post.Context.ToLower().Contains(word.ToLower()) && !threads.Select(e => e.Post.Id).Contains(post.Id)
                                   select new ThreadSearchModel
                                   {
                                       Thread = thread,
                                       Post = post,
                                       Creator = db.Accounts.Where(e => e.Id == thread.Account).Single(),
                                       Poster = db.Accounts.Where(e => e.Id == post.Account.Value).Single(),
                                       Posts = db.Posts.Where(e => e.Thread == thread.Id).Count(),
                                   };
                threads.AddRange(secondresult.ToList());
            }
            return threads.OrderByDescending(e => e.Post.Created).ToList();
        }

        public List<ThreadSearchModel> SelectItems()
        {
            throw new NotImplementedException();
        }

        public void UpdateById(long id, ThreadSearchModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
