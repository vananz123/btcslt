using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class BillInfoDAO : IBillInfo
    {
        public void Delete(BillInfo obj)
        {
            throw new NotImplementedException();
        }

        public List<BillInfo> GetAll()
        {
            using (qlcafe db =new qlcafe())
            {
                return db.BillInfoes.ToList();
            }
        }

        public BillInfo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public BillInfo Insert(BillInfo obj)
        {
            using (qlcafe db = new qlcafe())
            {
                db.BillInfoes.Add(obj);
                db.SaveChanges();
                return obj;
            }
        }

        public void Update(BillInfo obj)
        {
            throw new NotImplementedException();
        }
    }
}
