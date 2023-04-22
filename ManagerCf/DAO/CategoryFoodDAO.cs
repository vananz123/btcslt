using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CategoryFoodDAO : ICategoryFood
    {
        public void Delete(CategoryFood obj)
        {
            using (qlcafe db = new qlcafe())
            {
                db.CategoryFoods.Attach(obj);
                db.CategoryFoods.Remove(obj);
                db.SaveChanges();
            }
        }

        public List<CategoryFood> GetAll()
        {
            using (qlcafe db = new qlcafe())
            {
                return db.CategoryFoods.ToList();
            }
        }

        public CategoryFood GetById(int id)
        {
            using (qlcafe db = new qlcafe())
            {
                return db.CategoryFoods.Find(id);
            }
        }

        public CategoryFood Insert(CategoryFood obj)
        {
            using (qlcafe db = new qlcafe())
            {
                db.CategoryFoods.Add(obj);
                db.SaveChanges();
                return obj;
            }
        }

        public void Update(CategoryFood obj)
        {
            using (qlcafe db = new qlcafe())
            {
                db.CategoryFoods.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
