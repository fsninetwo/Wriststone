using System;
using System.Collections.Generic;
using System.Linq;
using Wriststone.Models.Table;

namespace Wriststone.Models.DAO
{
    public class RatingDAO : IEntityDAO<Rating>
    {
        private readonly WriststoneContext db = new WriststoneContext();
        public void DeleteById(Rating entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(Rating entity)
        {
            db.Ratings.Add(entity);
            db.SaveChanges();
        }

        public Rating Select(long? id)
        {
            throw new NotImplementedException();
        }

        public long SelectId(string name, string path)
        {
            throw new NotImplementedException();
        }
        public Rating SelectItemByAccount(long account)
        {
            return db.Ratings.Where(e => e.Account == account).DefaultIfEmpty().Single();
        }

        public double SelectAverageRateByProduct(Product product)
        {
            return db.Ratings.Where(e => e.Product == product.Id).Average(e => e.Rate).Value;
        }

        public List<Rating> SelectItems()
        {
            throw new NotImplementedException();
        }

        public List<Rating> SelectItemsByText(string text)
        {
            throw new NotImplementedException();
        }

        public List<Rating> SelectItemsByProduct(long product)
        {
            return db.Ratings.Where(e => e.Product == product).ToList();
        }

        public void UpdateById(long id, Rating entity)
        {
            Rating item = db.Ratings.Where(e => e.Id == id).Single();
            if (entity.Message != null) item.Message = entity.Message;
            if (entity.Rate != null) item.Rate = entity.Rate;
            if (entity.Created != null) item.Created = entity.Created;
            if (entity.Updated != null) item.Updated = entity.Updated;
            db.SaveChanges();
        }
    }
}
