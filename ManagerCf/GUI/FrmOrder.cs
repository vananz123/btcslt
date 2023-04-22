using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using System.Data.Entity;
using DevExpress.Utils.Svg;

namespace GUI
{
    public partial class FrmOrder : DevExpress.XtraEditors.XtraForm
    {
        public FrmOrder()
        {
            InitializeComponent();
        }
        DataTable tablefood = new DataTable("tablefood");
        List<int> listIdTable=new List<int>();
        int IdTable = 0;
        SimpleButton TableBtn(DAO.TableCoffee i)
        {
            SimpleButton btn = new SimpleButton();
            btn.Size = new Size(150, 150);
            btn.Text ="Bàn "+ i.ID.ToString();
            btn.Click += TableBtn_Click;
            if (i.Status == "Đã có")
            {
                btn.Appearance.BackColor =Color.Red;
                btn.Enabled = false;
            }
            return btn;
        }
        private void FrmOrder_Load(object sender, EventArgs e)
        {
            cbCatagory.Properties.Items.Add("Tất cả");
           
            foreach (var i in CategoryBUS.GetAll())
            {
                cbCatagory.Properties.Items.Add(i.Name);
            }
            LoadTable();
            DataColumn col0 = tablefood.Columns.Add("ID", typeof(int));
            DataColumn col1 = tablefood.Columns.Add("Name", typeof(string));
            DataColumn col2 = tablefood.Columns.Add("Size", typeof(string));
            DataColumn col3 = tablefood.Columns.Add("Amount", typeof(int));
            DataColumn col4 = tablefood.Columns.Add("Price", typeof(int));
            gridControlAddFood.DataSource = FoodBUS.GetAll();
            gridControlBillInfo.DataSource = tablefood;
        }
        public void TableBtn_Click(object sender,EventArgs  args)
        {
            SimpleButton btn = (SimpleButton)sender;
            lbTableBill.Text ="Hóa đơn: "+ btn.Text;
            string[] arrStr = btn.Text.Split(' ');
            IdTable = Int32.Parse(arrStr[1]);
            btnPay.Enabled = true;
        }
        public void LoadTable()
        {
            foreach (var i in TableBUS.GetAll())
            {
                flowLayoutPanel1.Controls.Add(TableBtn(i));
            }
            
        }

        private void cBFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Console.WriteLine();
        }

        bool CheckTableFood(int id)
        {
            foreach(DataRow dr in tablefood.Rows)
            {
                if (dr["ID"].ToString() == id.ToString())
                {
                    return true;
                }
            }
            return false;
        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridViewAddFood.RowCount; i++)
            {
                var food = (DAO.Food)gridViewAddFood.GetRow(i);
                if (food != null)
                {
                    if (gridViewAddFood.IsRowSelected(i) == true)
                    {
                        if (CheckTableFood(food.ID) == true)
                        {
                            foreach (DataRow dr in tablefood.Rows)
                            {
                                string id = dr["ID"].ToString();
                                if ( id== food.ID.ToString())
                                {
                                    int amount = Int32.Parse(dr["Amount"].ToString())+ Int32.Parse(cbAmount.Text);
                                    
                                    dr["Amount"] = amount;
                                    dr["Price"] = amount * FoodBUS.GetById(Int32.Parse(id)).Price;
                                }
                            }
                        }
                        else
                        {
                            DataRow dr = tablefood.NewRow();
                            dr["ID"] = food.ID;
                            dr["Name"] = food.Name;
                            dr["Size"] = food.Size;
                            dr["Amount"] =Int32.Parse(cbAmount.Text);
                            dr["Price"] = food.Price * Int32.Parse(cbAmount.Text);
                            tablefood.Rows.Add(dr);
                        }
                    }
                }
            }
            int kt = cbCatagory.SelectedIndex;
            ReloadFoodAdd(kt);
            gridControlBillInfo.RefreshDataSource();
        }
        void ReloadFoodAdd(int kt)
        {
            if (kt > 0)
            {
                var list = FoodBUS.GetFoodByIdCategory(kt);
                gridControlAddFood.DataSource = list.ToList();
            }
            else
            {
                gridControlAddFood.DataSource = FoodBUS.GetAll();
            }
        }
        private void cbCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int kt = cbCatagory.SelectedIndex;
            ReloadFoodAdd(kt);
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow data = gridViewBillInfo.GetFocusedDataRow();
            List<DataRow> toDelete = new List<DataRow>();
            foreach (DataRow dr in tablefood.Rows)
            {
                if (data["ID"].ToString() == dr["ID"].ToString())
                {
                    toDelete.Add(dr);
                }
            }
            foreach (DataRow dr in toDelete)
            {
                tablefood.Rows.Remove(dr);
            }
            gridControlBillInfo.RefreshDataSource();
            
        }
        private void repositoryItemSpinEdit1_ValueChanged(object sender, EventArgs e)
        {
            SpinEdit spin = (SpinEdit)sender;
            DataRow dr = gridViewBillInfo.GetFocusedDataRow();
            int ID = Int32.Parse(dr["ID"].ToString());
            int soLuong = Int32.Parse(spin.Text.TrimEnd('.'));
            int priceS = FoodBUS.GetById(ID).Price;
            int price = soLuong * priceS;
            System.Console.WriteLine(spin.Text.TrimEnd('.'));
            foreach (DataRow d in tablefood.Rows)
            {
                if (d["ID"].ToString() == ID.ToString())
                {
                    d["Amount"] = soLuong;
                    d["Price"] = price.ToString();
                }
            }
            gridControlBillInfo.RefreshDataSource();
        }
        int TotalPrice()
        {
            int totalprice = 0;
            foreach(DataRow dr in tablefood.Rows)
            {
                int price = Int32.Parse(dr["PRice"].ToString());
                totalprice += price;
            }
            return totalprice;
        }
        void HideBtnTable()
        {
            foreach(SimpleButton btn in flowLayoutPanel1.Controls.OfType<SimpleButton>())
            {
                string[] arrStr = btn.Text.Split(' ');
                int simpbtn = Int32.Parse(arrStr[1]);
                foreach(int id in listIdTable)
                {
                    if(simpbtn == id)
                    {
                        btn.Enabled = false;
                    }
                }
            }
        }
        private void btnPay_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Đồng ý", "Thoát", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if(IdTable > 0 )
                {
                    if(tablefood.Rows.Count > 0)
                    {
                        //tạo bill
                        bool kt= BillBUS.Pay(IdTable, TotalPrice(), tablefood);
                        if(kt == true)
                        {
                            listIdTable.Add(IdTable);
                            MessageBox.Show("Thánh toán thành công");
                            TableBUS.UpdateStaticTable(IdTable,true);
                            LoadTable();
                            tablefood.Rows.Clear();
                            gridControlBillInfo.RefreshDataSource();
                        }
                        else
                        {
                            MessageBox.Show("Thanh toán không thành công");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng thêm món vào hóa đơn");
                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

    }
}