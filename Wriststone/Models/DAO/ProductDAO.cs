using System;
using System.Collections.Generic;
using System.Linq;
using Wriststone.Models.Table;

namespace Wriststone.Models.DAO
{
    public class ProductDAO : IEntityDAO<Product>
    {
        private readonly WriststoneContext db = new WriststoneContext();
        public void DeleteById(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Select(long? id)
        {
            return db.Products.Where(e => e.Id == id).Single();
        }

        public decimal SelectPrice(long? id, string presentCurrency = "USD")
        {
            var prices = from productcurrency in db.ProductCurrencies
                         join currency in db.Currencies on productcurrency.Currency equals currency.Id
                         where productcurrency.Id == id && (currency.Name.Equals(presentCurrency) || currency.Symbol.Equals(presentCurrency))
                         select productcurrency.Price.Value;
            return prices.Single();
        }

        public List<Product> SelectItemsByAccountName(string name)
        {
            var products = from product in db.Products
                           join orderdetails in db.OrderDetails on product.Id equals orderdetails.Product
                           join order in db.Orders on orderdetails.Order equals order.Id
                           join account in db.Accounts on order.Account equals account.Id
                           where account.Login == name
                           select product;
            return products.ToList();
        }

        public List<Product> SelectItemsByCategory(long category)
        {
            return db.Products.Where(e => e.Category == category).ToList();
        }

        public long SelectId(string name, string path)
        {
            throw new NotImplementedException();
        }

        public List<Product> SelectItems()
        {
            throw new NotImplementedException();
        }

        public List<Product> SelectItemsByText(string text)
        {
            throw new NotImplementedException();
        }

        public void UpdateById(Product entity)
        {
            throw new NotImplementedException();
        }

        public static implicit operator ProductDAO(AccountDAO v)
        {
            throw new NotImplementedException();
        }

        internal object SelectByAccountId(long login)
        {
            throw new NotImplementedException();
        }

        public void UpdateById(long id, Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
