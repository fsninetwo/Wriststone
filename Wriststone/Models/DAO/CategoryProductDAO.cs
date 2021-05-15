using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wriststone.Models.Table;
using Wriststone.Models.ViewModel;

namespace Wriststone.Models.DAO
{
    public class CategoryProductDAO : IEntityDAO<CategoryProductModel>
    {
        readonly WriststoneContext db = new WriststoneContext();
        public CategoryProductModel SelectProduct(long? id, string currencyname)
        {
            var result = from productcurrency in db.ProductCurrencies
                         join currency in db.Currencies on productcurrency.Currency equals currency.Id
                         join product in db.Products on productcurrency.Product equals product.Id
                         where product.Id == id && currency.Symbol.Equals(currencyname)
                         select new CategoryProductModel
                         {
                             Product = product,
                             ProductCurrency = productcurrency,
                             Currency = currency,
                             Rating = (db.Ratings.Where(e => e.Product == product.Id).Count() != 0)
                             ? db.Ratings.Where(e => e.Product == product.Id).Average(e => e.Rate).Value : 0.0,
                             Downloads = db.OrderDetails.Where(e => e.Product == product.Id).Count()
                         };
            return result.Single();
        }

        public List<CategoryProductModel> SelectProductsByCategory(long? id, string currencyname)
        {
            var result = from productcurrency in db.ProductCurrencies
                         join currency in db.Currencies on productcurrency.Currency equals currency.Id
                         join product in db.Products on productcurrency.Product equals product.Id
                         where product.Category == id && currency.Symbol.Equals(currencyname)
                         select new CategoryProductModel
                         {
                             Product = product,
                             ProductCurrency = productcurrency,
                             Currency = currency,
                             Rating = (db.Ratings.Where(e => e.Product == product.Id).Count() != 0)
                             ? db.Ratings.Where(e => e.Product == product.Id).Average(e => e.Rate).Value : 0.0,
                             Downloads = db.OrderDetails.Where(e => e.Product == product.Id).Count()
                         };
            return result.OrderByDescending(e => e.Downloads).ToList();
        }

        public List<CategoryProductModel> FindProducts(string name, string currencyname)
        {
            var result = from productcurrency in db.ProductCurrencies
                         join currency in db.Currencies on productcurrency.Currency equals currency.Id
                         join product in db.Products on productcurrency.Product equals product.Id
                         where currency.Symbol.Equals(currencyname) && product.Name.ToLower().Contains(name.ToLower())
                         select new CategoryProductModel
                         {
                             Product = product,
                             ProductCurrency = productcurrency,
                             Currency = currency,
                             Rating = (db.Ratings.Where(e => e.Product == product.Id).Count() != 0) 
                             ? db.Ratings.Where(e => e.Product == product.Id).Average(e => e.Rate).Value : 0.0,
                             Downloads = db.OrderDetails.Where(e => e.Product == product.Id).Count()
                         };
            return result.OrderByDescending(e => e.Downloads).ToList();
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

        public List<CategoryProductModel> SelectProductsByHierarchy(long category, string currencyname)
        {
            var subset = new List<long> { category };
            GetCategory(category, ref subset);
            var result = from productcurrency in db.ProductCurrencies
                         join currency in db.Currencies on productcurrency.Currency equals currency.Id
                         join product in db.Products on productcurrency.Product equals product.Id
                         where subset.Contains(product.Category.Value) && currency.Symbol.Equals(currencyname)
                         select new CategoryProductModel
                         {
                             Product = product,
                             ProductCurrency = productcurrency,
                             Currency = currency,
                             Rating = (db.Ratings.Where(e => e.Product == product.Id).Count() != 0)
                             ? db.Ratings.Where(e => e.Product == product.Id).Average(e => e.Rate).Value : 0.0,
                             Downloads = db.OrderDetails.Where(e => e.Product == product.Id).Count()
                         };
            return result.ToList();
        }

        public void Insert(CategoryProductModel entity)
        {
            throw new NotImplementedException();
        }

        public CategoryProductModel Select(long? id)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(CategoryProductModel entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateById(long id, CategoryProductModel entity)
        {
            throw new NotImplementedException();
        }

        public List<CategoryProductModel> SelectItems()
        {
            throw new NotImplementedException();
        }
    }
}
