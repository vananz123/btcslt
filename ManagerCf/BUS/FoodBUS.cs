using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;

namespace BUS
{
    public static class FoodBUS
    {
        static IFood ifood;
        static FoodBUS()
        {
            ifood = new FoodDAO();
        }
        public static List<Food> GetAll()
        {
            return ifood.GetAll();
        }
        public static void DataFoodView(DataGridView data)
        {
            var f = from i in FoodBUS.GetAll()
                    select new
                    {
                        i.Name
                    };
            data.DataSource = f.ToList();
        }
        public static List<Food> GetFoodByIdCategory(int id)
        {
            var food = ifood.GetAll().Where(p => p.CategoryID == id);
            return food.ToList();
        }
        public static Food GetById(int id)
        {
            return ifood.GetById(id);
        }
    }
}
