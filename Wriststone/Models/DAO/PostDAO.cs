using System;
using System.Collections.Generic;
using System.Linq;
using Wriststone.Models.Table;

namespace Wriststone.Models.DAO
{
    public class PostDAO : IEntityDAO<Post>
    {
        WriststoneContext db = new WriststoneContext();

        public void DeleteById(Post entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(Post entity)
        {
            db.Posts.Add(entity);
            db.SaveChanges();
        }

        public Post Select(long? id)
        {
            return db.Posts.Where(e => e.Id == id).Single();
        }

        public long SelectFirstPostByThread(long accountid, long creatorid)
        {
            return db.Posts.Where(e => e.Account == accountid && e.Thread == creatorid).Min(e => e.ThreadOrder).Value;
        }

        public long SelectLastPostByThread(long threadid)
        {
            return db.Posts.Where(e => e.Thread == threadid).Max(e => e.ThreadOrder).Value;
        }

        public List<Post> SelectItemsByThread(long threadid)
        {
            return db.Posts.Where(e => e.Thread == threadid).ToList();
        }

        public List<Post> SelectItems()
        {
            throw new NotImplementedException();
        }

        public void UpdateById(long id, Post entity)
        {
            Post post = db.Posts.Where(e => e.Id == id).Single();
            if (post.Context != null) post.Context = entity.Context;
            db.SaveChanges();
        }
    }
}
