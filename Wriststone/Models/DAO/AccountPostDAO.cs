using System;
using System.Collections.Generic;
using System.Linq;
using Wriststone.Models.ViewModel;

namespace Wriststone.Models.DAO
{
    public class AccountPostDAO : IEntityDAO<AccountPostModel>
    {
        readonly WriststoneContext db = new WriststoneContext();

        public void DeleteById(AccountPostModel entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(AccountPostModel entity)
        {
            throw new NotImplementedException();
        }

        public AccountPostModel Select(long? id)
        {
            throw new NotImplementedException();
        }

        public List<AccountPostModel> SelectItems()
        {
            throw new NotImplementedException();
        }

        public List<AccountPostModel> SelectItemsByThread(long threadid)
        {
            var result = from post in db.Posts
                         join account in db.Accounts on post.Account equals account.Id
                         orderby post.Id
                         where post.Thread == threadid
                         select new AccountPostModel { Account = account, Post = post };
            return result.ToList();
        }

        public void UpdateById(long id, AccountPostModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
