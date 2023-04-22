using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class FoodDAO : IFood
    {
        public void Delete(Food obj)
        {
            throw new NotImplementedException();
        }

        public List<Food> GetAll()
        {
            using (qlcafe db = new qlcafe())
            {

                return db.Foods.ToList();
            }
        }

        public Food GetById(int id)
        {
            using (qlcafe db = new qlcafe())
            {

                return db.Foods.Find(id);
            }
        }

        public Food Insert(Food obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Food obj)
        {
            throw new NotImplementedException();
        }
    }
}
