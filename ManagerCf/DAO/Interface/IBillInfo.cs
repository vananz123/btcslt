using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IBillInfo
    {
        List<BillInfo> GetAll();
        BillInfo GetById(int id);
        BillInfo Insert(BillInfo obj);
        void Update(BillInfo obj);
        void Delete(BillInfo obj);
    }
}
