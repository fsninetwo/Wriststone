using System;
using System.Collections.Generic;
using System.Linq;
using Wriststone.Models.Table;

namespace Wriststone.Models.DAO
{
    public class OrderDetailsDAO : IEntityDAO<OrderDetails>
    {
        readonly WriststoneContext db = new WriststoneContext();
        public void DeleteById(OrderDetails entity)
        {
            db.OrderDetails.Remove(entity);
            db.SaveChanges();
        }

        public void Insert(OrderDetails entity)
        {
            db.OrderDetails.Add(entity);
            db.SaveChanges();
        }

        public OrderDetails Select(long? id)
        {
            throw new NotImplementedException();
        }

        public long SelectId(string name, string path)
        {
            throw new NotImplementedException();
        }

        public List<OrderDetails> SelectItems()
        {
            throw new NotImplementedException();
        }

        public List<OrderDetails> SelectItemsByText(string text)
        {
            throw new NotImplementedException();
        }
        public List<OrderDetails> SelectItemsByAccountAndProduct(string user, long productid)
        {
            var orderdetails = from account in db.Accounts
                               join order in db.Orders on account.Id equals order.Account
                               join orderdetail in db.OrderDetails on order.Id equals orderdetail.Order
                               join product in db.Products on orderdetail.Product equals product.Id
                               where account.Login == user && product.Id == productid
                               select orderdetail;
            return orderdetails.ToList();
        }

        public void UpdateById(long id, OrderDetails entity)
        {
            throw new NotImplementedException();
        }
    }
}
