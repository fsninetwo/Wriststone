using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wriststone.Models.Table;
using Wriststone.Models.ViewModel;

namespace Wriststone.Models.DAO
{
    public class ProductCartDAO : IEntityDAO<ProductCartModel>
    {
        WriststoneContext db = new WriststoneContext();
        public void DeleteById(ProductCartModel entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(ProductCartModel entity)
        {
            throw new NotImplementedException();
        }

        public ProductCartModel Select(long? id)
        {
            throw new NotImplementedException();
        }

        public ProductCartModel SelectProduct(long? id, string currencyname)
        {
            var result = from productcurrency in db.ProductCurrencies
                         join currency in db.Currencies on productcurrency.Currency equals currency.Id
                         join product in db.Products on productcurrency.Product equals product.Id
                         where product.Id == id && currency.Symbol.Equals(currencyname)
                         select new ProductCartModel
                         {
                             Product = product,
                             ProductCurrency = productcurrency,
                             Currency = currency,
                         };
            return result.Single();
        }

        public List<ProductCartModel> SelectProductsByCategory(long? id, string currencyname)
        {
            var result = from productcurrency in db.ProductCurrencies
                         join currency in db.Currencies on productcurrency.Currency equals currency.Id
                         join product in db.Products on productcurrency.Product equals product.Id
                         where product.Category == id && currency.Symbol.Equals(currencyname)
                         select new ProductCartModel
                         {
                             Product = product,
                             ProductCurrency = productcurrency,
                             Currency = currency,
                         };
            return result.ToList();
        }

        public void GetCategory(long category, ref List<long> categories)
        {
            var result = db.ProductCategories.Where(e => e.Category == category).ToList();
            foreach (var item in result)
            {
                categories.Add(item.Id.Value);
                GetCategory(item.Id.Value, ref categories);
            }

        }

        public List<ProductCartModel> FindProducts(string name, string currencyname)
        {
            var result = from productcurrency in db.ProductCurrencies
                         join currency in db.Currencies on productcurrency.Currency equals currency.Id
                         join product in db.Products on productcurrency.Product equals product.Id
                         where currency.Symbol.Equals(currencyname) && product.Name.ToLower().Contains(name.ToLower())
                         select new ProductCartModel
                         {
                             Product = product,
                             ProductCurrency = productcurrency,
                             Currency = currency,
                         };
            return result.ToList();
        }

        public List<ProductCartModel> SelectProductsByHierarchy(long category, long? id, string currencyname)
        {
            var subset = new List<long> { category };
            GetCategory(category, ref subset);
            var result = from productcurrency in db.ProductCurrencies
                         join currency in db.Currencies on productcurrency.Currency equals currency.Id
                         join product in db.Products on productcurrency.Product equals product.Id
                         where subset.Contains(product.Category.Value) && currency.Symbol.Equals(currencyname)
                         select new ProductCartModel
                         {
                             Product = product,
                             ProductCurrency = productcurrency,
                             Currency = currency,
                         };
            return result.ToList();
        }

        public List<ProductCartModel> SelectItems()
        {
            throw new NotImplementedException();
        }

        public void UpdateById(long id, ProductCartModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
