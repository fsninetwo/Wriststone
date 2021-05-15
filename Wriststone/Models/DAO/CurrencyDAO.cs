using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wriststone.Models.Table;

namespace Wriststone.Models.DAO
{
    public class CurrencyDAO : IEntityDAO<Currency>
    {
        readonly WriststoneContext db = new WriststoneContext();

        public void DeleteById(Currency entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(Currency entity)
        {
            throw new NotImplementedException();
        }

        public Currency Select(long? id)
        {
            throw new NotImplementedException();
        }

        public Currency SelectBySymbol(string symbol)
        {
            return db.Currencies.Where(e => e.Symbol.Equals(symbol)).SingleOrDefault();
        }

        public List<Currency> SelectItems()
        {
            throw new NotImplementedException();
        }

        public void UpdateById(long id, Currency entity)
        {
            throw new NotImplementedException();
        }
    }
}
