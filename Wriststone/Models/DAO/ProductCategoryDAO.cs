using System;
using System.Collections.Generic;
using System.Linq;
using Wriststone.Models.Table;

namespace Wriststone.Models.DAO
{
    public class ProductCategoryDAO : IEntityDAO<ProductCategory>
    {
        WriststoneContext db = new WriststoneContext();
        public void DeleteById(ProductCategory entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(ProductCategory entity)
        {
            throw new NotImplementedException();
        }

        public ProductCategory Select(long? id)
        {
            return db.ProductCategories.Where(e => e.Id == id).Single();
        }

        public long SelectId(string name, string path)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategory> SelectItems()
        {
            throw new NotImplementedException();
        }

        public List<ProductCategory> SelectItemsByCategory(long? category)
        {
            return db.ProductCategories.Where(e => e.Category == category).ToList();
        }

        public List<ProductCategory> SelectItemsByText(string text)
        {
            throw new NotImplementedException();
        }

        public void UpdateById(long id, ProductCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}
