using System;
using System.Collections.Generic;
using System.Linq;
using Wriststone.Models.ViewModel;

namespace Wriststone.Models.DAO
{
    public class AccountRatingDAO : IEntityDAO<AccountRatingModel>
    {
        readonly WriststoneContext db = new WriststoneContext();

        public void DeleteById(AccountRatingModel entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(AccountRatingModel entity)
        {
            throw new NotImplementedException();
        }

        public AccountRatingModel Select(long? id)
        {
            throw new NotImplementedException();
        }

        public long SelectId(string name, string path)
        {
            throw new NotImplementedException();
        }

        public List<AccountRatingModel> SelectItems()
        {
            throw new NotImplementedException();
        }

        public List<AccountRatingModel> SelectItemsByText(string text)
        {
            throw new NotImplementedException();
        }

        public List<AccountRatingModel> SelectItemsByProduct(long productid)
        {
            var result = from product in db.Products
                         join rating in db.Ratings on product.Id equals rating.Product
                         join account in db.Accounts on rating.Account equals account.Id
                         where product.Id == productid
                         select new AccountRatingModel { Rating = rating, Account = account };
            return result.ToList();
        }

        public void UpdateById(long id, AccountRatingModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
