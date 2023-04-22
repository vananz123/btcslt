using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class AccountDAO : IAccount
    {
        public void Delete(Account obj)
        {
            using (qlcafe db = new qlcafe())
            {
                db.Accounts.Attach(obj);
                db.Accounts.Remove(obj);
                db.SaveChanges();
            }
        }


        public List<Account> GetAll()
        {
            using (qlcafe db = new qlcafe())
            {
                var acc = from a in db.Accounts
                          select a;
                return acc.ToList();
            }
        }

        public Account GetById(int id)
        {
            using (qlcafe db = new qlcafe())
            {
                return db.Accounts.Find(id);
            }
        }

        public Account Insert(Account obj)
        {
            using (qlcafe db = new qlcafe())
            {
                db.Accounts.Add(obj);
                db.SaveChanges();
                return obj;
            }
        }

        public void Update(Account obj)
        {
            using (qlcafe db = new qlcafe())
            {
                db.Accounts.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
