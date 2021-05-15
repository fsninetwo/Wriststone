using System.Collections.Generic;

namespace Wriststone.Models.DAO
{
    public interface IEntityDAO<T>
    {
        public void Insert(T entity);
        public T Select(long? id);
        void DeleteById(T entity);
        void UpdateById(long id, T entity);
        List<T> SelectItems();
    }
}
