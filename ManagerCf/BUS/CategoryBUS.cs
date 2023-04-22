using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public static class CategoryBUS
    {
        static ICategoryFood icategoryFood;
        static CategoryBUS()
        {
            icategoryFood = new CategoryFoodDAO();
        }
        public static List<CategoryFood> GetAll()
        {
            return icategoryFood.GetAll();
        }
    }

}
