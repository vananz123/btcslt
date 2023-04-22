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
using DevExpress.XtraGrid.Views.Grid;
using System.Data.Entity;

namespace GUI
{
    public partial class FrmTable : DevExpress.XtraEditors.XtraForm
    {
        public FrmTable()
        {
            InitializeComponent();
            
            DAO.qlcafe dbContext = new DAO.qlcafe();
        }
        void LoadData()
        {
            gridControlTable.DataSource = TableBUS.GetAll();
          
        }
        void AddBinding()
        {
            txtEditTable.DataBindings.Add(new Binding("Text", gridControlTable.DataSource, "Name"));
        }
        void BtnHide(bool kt)//true la mo add,edit,del, f = tat
        {
            txtEditTable.Enabled = !kt;
            barBtnAdd.Enabled = kt;
            barBtnDel.Enabled = kt;
            barBtnEdit.Enabled = kt;
            barBtnSave.Enabled = !kt;
            barBtnCanel.Enabled = !kt;
            
        }
        void EditGrid(bool kt)//true la mo chon nhien dong , f la tat
        {
            gridViewTable.OptionsSelection.MultiSelect = kt;
            if(kt == true)
            {
                gridViewTable.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            }
            else
            {
                gridViewTable.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            }
            
        }
        bool ADD = false;
        bool DEL = false;
        bool EDIT = false;

        private void FrmTable_Load(object sender, EventArgs e)
        {
            LoadData();
            BtnHide(true);
            AddBinding();
            txtEditTable.Enabled = false;
        }
        private void barBtnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ADD = true;
            BtnHide(false);
        }

        private void barBtnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (DEL == true)
            {
                for (int i = 0; i < gridViewTable.RowCount; i++)
                {
                    var r = (TableCoffee)gridViewTable.GetRow(i);
                    if(r != null)
                    {
                        if (gridViewTable.IsRowSelected(i) == true)
                        {
                            TableBUS.Delete(r);
                        }
                    }
                }
                DEL = false;
                EditGrid(DEL);
            }
            if(ADD == true)
            {
                string name = txtEditTable.Text;
                try
                {
                    TableBUS.Insert(name);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("lỗi");
                }
                ADD = false;
            }
            if (EDIT == true)
            {
                
                try
                {
                    string name = txtEditTable.Text;
                    var i = (TableCoffee)gridViewTable.GetRow(gridViewTable.GetFocusedDataSourceRowIndex());
                    i.Name = name;
                    TableBUS.Update(i);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("lỗi");
                }
                EDIT = false;
            }
            BtnHide(true);
            LoadData();

        }

        private void barBtnCanel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(DEL == true)
            {
                DEL = false;
                EditGrid(DEL);
            }
            BtnHide(true);
        }

        private void barBtnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EDIT = true;

            BtnHide(false);
        }

        private void barBtnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DEL = true;
            EditGrid(DEL);
            BtnHide(false);
        }


    }
}