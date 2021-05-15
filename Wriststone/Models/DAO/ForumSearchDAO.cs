using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wriststone.Models.ViewModel;

namespace Wriststone.Models.DAO
{
    public class ForumSearchDAO : IEntityDAO<ForumSearchModel>
    {
        readonly WriststoneContext db = new WriststoneContext();
        ThreadSearchDAO ThreadSearchDAO = new ThreadSearchDAO();
        public void DeleteById(ForumSearchModel entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(ForumSearchModel entity)
        {
            throw new NotImplementedException();
        }

        public ForumSearchModel Select(long? id)
        {
            throw new NotImplementedException();
        }



        public List<ForumSearchModel> FindThreads(string search)
        {
            throw new NotImplementedException();
        }

        public ForumSearchModel SelectByPage(string search, long page = 0, int capacity = 20)
        {
            var threads = ThreadSearchDAO.FindThreads(search).OrderByDescending(e => e.Thread.Updated);
            var pages = threads.Count() / capacity;
            return new ForumSearchModel
            {
                Threads = threads.Skip(capacity* (int) page).Take(capacity),
                Search = search,
                Page = page,
                Pages = (threads.Count() - 1) / capacity
            };
        }

        public List<ForumSearchModel> SelectItems()
        {
            throw new NotImplementedException();
        }

        public void UpdateById(long id, ForumSearchModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
