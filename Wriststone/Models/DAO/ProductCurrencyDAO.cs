using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wriststone.Models.Table;

namespace Wriststone.Models.DAO
{
    public class ProductCurrencyDAO : IEntityDAO<ProductCurrency>
    {
        readonly WriststoneContext db = new WriststoneContext();

        public void DeleteById(ProductCurrency entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(ProductCurrency entity)
        {
            throw new NotImplementedException();
        }

        public ProductCurrency Select(long? id)
        {
            throw new NotImplementedException();
        }

        public ProductCurrency SelectByProductAndCurrencyId(long? product, long? currency)
        {
            return db.ProductCurrencies.Where(e => e.Product == product && e.Currency == e.Currency).SingleOrDefault();
        }

        public List<ProductCurrency> SelectItems()
        {
            throw new NotImplementedException();
        }

        public void UpdateById(long id, ProductCurrency entity)
        {
            throw new NotImplementedException();
        }
    }
}
