using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IFood
    {
        List<Food> GetAll();
        Food GetById(int id);
        Food Insert(Food obj);
        void Update(Food obj);
        void Delete(Food obj);
    }
}
