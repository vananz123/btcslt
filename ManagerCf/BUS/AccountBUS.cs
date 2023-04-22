using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public static class AccountBUS
    {
        static IAccount iaccount;
        static AccountBUS()
        {
            iaccount = new AccountDAO();
        }
        public static bool CheckLogin(string user,string pw)
        {
            var list = iaccount.GetAll();
            foreach( var i in list)
            {
                if(i.UserName ==user && i.Password == pw)
                {
                    return true;
                }
            }
            return false;
        }
        public static List<Account> GetALL()
        {
            return iaccount.GetAll();
        }
        public static Account GetById(int id)
        {
            return iaccount.GetById(id);
        }
        public static Account Insert(Account obj)
        {
            return iaccount.Insert(obj);
        }
        public static void Update(Account obj)
        {
            iaccount.Update(obj);
        }
        public static void Delete(Account obj)
        {
            iaccount.Delete(obj);
        }

    }
}
