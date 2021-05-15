using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wriststone.Models.ViewModel;

namespace Wriststone.Models.DAO
{
    public class AccountProductDAO : IEntityDAO<AccountProductModel>
    {
        readonly WriststoneContext db = new WriststoneContext();
        public void DeleteById(AccountProductModel entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(AccountProductModel entity)
        {
            throw new NotImplementedException();
        }

        public AccountProductModel Select(long? id)
        {
            throw new NotImplementedException();
        }

        public List<AccountProductModel> SelectItemsByAccount(string user)
        {

            var result = from order in db.Orders
                         join currency in db.Currencies on order.Currency equals currency.Id
                         join orderdetail in db.OrderDetails on order.Id equals orderdetail.Order
                         join account in db.Accounts on order.Account equals account.Id
                         join product in db.Products on orderdetail.Product equals product.Id
                         where account.Login.Equals(user)
                         select new AccountProductModel 
                         { 
                             Product = product,
                             Order = order,
                             OrderDetails = orderdetail,
                             Currency = currency
                         };
            return result.ToList();
        }

        public List<AccountProductModel> SelectItems()
        {
            throw new NotImplementedException();
        }

        public void UpdateById(long id, AccountProductModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
