using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public static class TableBUS
    {
        static ITable itable;
        static TableBUS()
        {
            itable = new TableDAO();
        }
        public static List<TableCoffee> GetAll()
        {
            return itable.GetAll();
        }
        public static TableCoffee Insert(string name)
        {
            TableCoffee obj = new TableCoffee() { Name = name,Status="Trống" };
            return itable.Insert(obj);
        }
        public static TableCoffee GetById(int id)
        {
            return itable.GetById(id);
        }
        public static void Delete(TableCoffee obj)
        {
            itable.Delete(obj);
        }
        public static void Update(TableCoffee obj)
        {
            itable.Update(obj);
        }
        public static void UpdateStaticTable(int id,bool status)
        {
            TableCoffee tableCoffee = GetById(id);
            if (status == true)
            {
                tableCoffee.Status = "Đã có";
            }
            else
            {
                tableCoffee.Status = "Trống";
            }
            Update(tableCoffee);
        }
        public static List<TableCoffee> GetByStatus(string status)
        {
            return itable.GetAll().Where(p => p.Status.Contains(status)).ToList();
        }
    }
}
