using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class BillDAO : IBill
    {
        public void Delete(Bill obj)
        {
            using (qlcafe db =new qlcafe())
            {
                db.Bills.Attach(obj);
                db.Bills.Remove(obj);
                db.SaveChanges();
            }
        }

        public List<Bill> GetAll()
        {
            using (qlcafe db =new qlcafe())
            {
                return db.Bills.ToList();
            }
        }

        public Bill GetById(int id)
        {
            using (qlcafe db =new qlcafe())
            {
                return db.Bills.Find(id);
            }
        }

        public Bill Insert(Bill obj)
        {
            using (qlcafe db =new qlcafe())
            {
                db.Bills.Add(obj);
                db.SaveChanges();
                return obj;
            }
        }

        public void Update(Bill obj)
        {
            using (qlcafe db =new qlcafe())
            {
                db.Bills.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
