using System;
using System.Collections.Generic;
using System.Linq;
using Wriststone.Models.Table;

namespace Wriststone.Models.DAO
{
    public class ThreadDAO : IEntityDAO<Thread>
    {
        WriststoneContext db = new WriststoneContext();

        public void DeleteById(Thread entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(Thread entity)
        {
            db.Threads.Add(entity);
            db.SaveChanges();
        }

        public Thread Select(long? id)
        {
            return db.Threads.Where(e => e.Id == id).Single();
        }

        public Thread SelectBySubject(string subject)
        {
            return db.Threads.Where(e => e.Subject.Equals(subject)).Single();
        }

        public List<Thread> SelectItems()
        {
            throw new NotImplementedException();
        }
        public void ViewsCount(long id)
        {
            Thread thread = db.Threads.Where(e => e.Id == id).Single();
            thread.Views++;
            db.SaveChanges();
        }

        public void UpdateById(long id, Thread entity)
        {
            Thread thread = db.Threads.Where(e => e.Id == id).Single();
            if (entity.Updated != null) thread.Updated = entity.Updated;
            if (entity.Subject != null) thread.Subject = entity.Subject;
            db.SaveChanges();
        }
    }
}
