using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wriststone.Models.ViewModel;

namespace Wriststone.Models.DAO
{
    public class OrderProductDAO : IEntityDAO<OrderProductModel>
    {
        readonly WriststoneContext db = new WriststoneContext();

        public void DeleteById(OrderProductModel entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(OrderProductModel entity)
        {
            throw new NotImplementedException();
        }

        public OrderProductModel Select(long? id)
        {
            throw new NotImplementedException();
        }

        public OrderProductModel SelectItemByAccount(string user, long? id)
        {
            var orders = from order in db.Orders
                         join orderdetail in db.OrderDetails on order.Id equals orderdetail.Order
                         join account in db.Accounts on order.Account equals account.Id
                         join product in db.Products on orderdetail.Product equals product.Id
                         where account.Login.Equals(user) && order.Id == id
                         select new ProductOrderModel
                         {
                             Product = product,
                             OrderDetails = orderdetail
                         };
            var result = from order in db.Orders
                         join currency in db.Currencies on order.Currency equals currency.Id
                         join account in db.Accounts on order.Account equals account.Id
                         where account.Login.Equals(user) && order.Id == id
                         select new OrderProductModel
                         {
                             Order = order,
                             Currency = currency,
                             Orders = orders.ToList()
                         };
            return result.Single();
        }

        public List<OrderProductModel> SelectItems()
        {
            throw new NotImplementedException();
        }

        public void UpdateById(long id, OrderProductModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
