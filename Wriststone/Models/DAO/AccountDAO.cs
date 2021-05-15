using System;
using System.Collections.Generic;
using System.Linq;
using Wriststone.Models.Table;
using Wriststone_Administration.Cache;

namespace Wriststone.Models.DAO
{
    public class AccountDAO : IEntityDAO<Account>
    {
        readonly WriststoneContext db = new WriststoneContext();
        public void Insert(Account entity)
        {
            var sol = MD5Hash.RandomString();
            entity.Sol = sol;
            entity.Password = MD5Hash.GetHash(entity.Password + sol);
            db.Accounts.Add(entity);
            db.SaveChanges();
        }
        public void DeleteById(Account entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateById(long id, Account entity)
        {
            
            var user = db.Accounts.Where(e => e.Id == id).Single();
            if (entity.Email != null) user.Email = entity.Email;
            if (entity.Password != null)
            {
                var sol = MD5Hash.RandomString();
                user.Sol = sol;
                user.Password = MD5Hash.GetHash(entity.Password + sol);
            }
            if (entity.Fullname != null) user.Fullname = entity.Fullname;
            if (entity.Avatar != null) user.Avatar = entity.Avatar;
            db.SaveChanges();
        }

        public void UpdatePassword(string email, string password)
        {
            var sol = MD5Hash.RandomString();
            Account user = db.Accounts.Where(e => e.Email == email).Single();
            user.Sol = sol;
            user.Password = MD5Hash.GetHash(password + sol);
            db.SaveChanges();
        }

        public void UpdateById(Account entity)
        {
            throw new NotImplementedException();
        }

        public Account Select(long? id)
        {
            return db.Accounts.Where(e => e.Id == id).Single();
        }

        public long SelectId(string login, string password)
        {
            return SelectItemByCreditals(login, password).Id.Value;
        }

        public Account SelectItemByCreditals(string login, string password)
        {
            var sol = db.Accounts.Where(e => e.Login.Equals(login) || e.Email.Equals(login)).Single().Sol;
            return db.Accounts.Where(e => (e.Login.Equals(login) || e.Email.Equals(login)) 
                && e.Password.Equals(MD5Hash.GetHash(password + sol))).Single();
        }

        public Account SelectItemByLogin(string login)
        {
            return db.Accounts.Where(e => e.Login.ToLower().Equals(login.ToLower())).DefaultIfEmpty().SingleOrDefault();
        }

        public Account SelectItemByEmail(string email)
        {
            return db.Accounts.Where(e => e.Email.ToLower().Equals(email.ToLower())).DefaultIfEmpty().Single();
        }

        public List<Account> SelectItems()
        {
            throw new NotImplementedException();
        }

        public List<Account> SelectItemsByText(string text)
        {
            throw new NotImplementedException();
        }
        public List<string> SelectToComboBox(string path)
        {
            throw new NotImplementedException();
        }
    }
}
