using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class TableDAO : ITable
    {
        public void Delete(TableCoffee obj)
        {
            using (qlcafe db = new qlcafe())
            {
                db.TableCoffees.Attach(obj);
                db.TableCoffees.Remove(obj);
                db.SaveChanges();
            }
        }

        public List<TableCoffee> GetAll()
        {
            using (qlcafe db = new qlcafe())
            {
                var t = from s in db.TableCoffees
                        select s;
                return t.ToList();
            }
        }

        public TableCoffee GetById(int id)
        {
            using (qlcafe db = new qlcafe())
            {
                return db.TableCoffees.Find(id);
            }
        }

        public TableCoffee Insert(TableCoffee obj)
        {
            using (qlcafe db = new qlcafe())
            {
                db.TableCoffees.Add(obj);
                db.SaveChanges();
                return obj;
            }
        }

        public void Update(TableCoffee obj)
        {
            using (qlcafe db = new qlcafe())
            {
                db.TableCoffees.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
