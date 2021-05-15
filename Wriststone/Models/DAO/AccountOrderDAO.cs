using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wriststone.Models.ViewModel;

namespace Wriststone.Models.DAO
{
    public class AccountOrderDAO : IEntityDAO<AccountOrderModel>
    {
        readonly WriststoneContext db = new WriststoneContext();

        public void DeleteById(AccountOrderModel entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(AccountOrderModel entity)
        {
            throw new NotImplementedException();
        }

        public AccountOrderModel Select(long? id)
        {
            throw new NotImplementedException();
        }

        public List<AccountOrderModel> SelectItems()
        {
            throw new NotImplementedException();
        }

        public List<AccountOrderModel> SelectItemsByAccount(string user)
        {

            var result = from order in db.Orders
                         join currency in db.Currencies on order.Currency equals currency.Id
                         join account in db.Accounts on order.Account equals account.Id
                         where account.Login.Equals(user)
                         select new AccountOrderModel
                         {
                             Order = order,
                             Currency = currency
                         };
            return result.ToList();
        }

        public void UpdateById(long id, AccountOrderModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
