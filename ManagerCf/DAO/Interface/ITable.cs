using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface ITable
    {
        List<TableCoffee> GetAll();
        TableCoffee GetById(int id);
        TableCoffee Insert(TableCoffee obj);
        void Update(TableCoffee obj);
        void Delete(TableCoffee obj);
    }
}
