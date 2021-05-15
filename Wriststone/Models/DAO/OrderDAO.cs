using System;
using System.Linq;
using System.Collections.Generic;
using Wriststone.Models.Table;

namespace Wriststone.Models.DAO
{
    public class OrderDAO : IEntityDAO<Order>
    {
        readonly WriststoneContext db = new WriststoneContext();
        public void DeleteById(Order entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(Order entity)
        {
            db.Orders.Add(entity);
            db.SaveChanges();
        }

        public Order Select(long? id)
        {
            throw new NotImplementedException();
        }

        public List<Order> SelectItemsByAccountName(string name)
        {
            var orders = from order in db.Orders
                         join account in db.Accounts on order.Account equals account.Id
                         where account.Login == name
                         select order;
            return orders.ToList();
        }

        public List<Order> SelectItems()
        {
            throw new NotImplementedException();
        }

        public void UpdateById(long id, Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
