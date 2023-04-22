using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IBill
    {
        List<Bill> GetAll();
        Bill GetById(int id);
        Bill Insert(Bill obj);
        void Update(Bill obj);
        void Delete(Bill obj);
    }
}
