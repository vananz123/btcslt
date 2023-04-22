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
using DAO;

namespace GUI
{
    public partial class FrmTableStatus : DevExpress.XtraEditors.XtraForm
    {
        public FrmTableStatus()
        {
            InitializeComponent();
        }


        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i < gridViewTableStatus.RowCount; i++)
            {
                var r = (TableCoffee)gridViewTableStatus.GetRow(i);
                if (r != null)
                {
                    if (gridViewTableStatus.IsRowSelected(i) == true)
                    {
                       if(r.Status == "Trống")
                       {
                            TableBUS.UpdateStaticTable(r.ID, true);

                       }
                       else
                       {
                            TableBUS.UpdateStaticTable(r.ID, false);
                       }
                    }
                }
            }
            gridControlTableStatus.DataSource =TableBUS.GetAll();
        }

        private void FrmTableStatus_Load(object sender, EventArgs e)
        {
            gridControlTableStatus.DataSource = TableBUS.GetAll();
            cbTableStatus.SelectedIndex = 0;
        }

        private void cbTableStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbTableStatus.SelectedIndex > 0)
            {
                gridControlTableStatus.DataSource = TableBUS.GetByStatus(cbTableStatus.Text);
            }
            else
            {
                gridControlTableStatus.DataSource = TableBUS.GetAll();
            }
        }
    }
}