using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;

namespace BUS
{
    public static class BillBUS
    {
        static IBill ibill;
        static IBillInfo ibillinfo;
        static BillBUS()
        {
            ibill = new BillDAO();
            ibillinfo = new BillInfoDAO();
        }
        public static Bill Insert(Bill obj)
        {
            return ibill.Insert(obj);
        }
        public static BillInfo InsertBillInfo(BillInfo obj)
        {
            return ibillinfo.Insert(obj);
        }
        public static bool Pay(int idTable,int totalprice, DataTable dataBillInfo)
        {
            try
            {
                Bill bill = new Bill() { AtCreate = DateTime.Now, TableID = idTable, TotalPrice = totalprice, Status = 1 };
                Bill b = BillBUS.Insert(bill);
                foreach (DataRow dr in dataBillInfo.Rows)
                {
                    int FoodID = Int32.Parse(dr["ID"].ToString());
                    int Amount = Int32.Parse(dr["Amount"].ToString());
                    BillInfo billInfo = new BillInfo() { BillID = b.ID, FoodID = FoodID, Amount = Amount };
                    InsertBillInfo(billInfo);
                }
                return true;
            }catch (Exception e)
            {
                return false;
            }
        }
    }
}
