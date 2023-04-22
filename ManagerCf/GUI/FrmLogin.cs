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

namespace GUI
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (AccountBUS.CheckLogin(txtUser.Text, txtPass.Text))
            {
                FrmMain main =new FrmMain();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("ko");
            }
        }

    }
}