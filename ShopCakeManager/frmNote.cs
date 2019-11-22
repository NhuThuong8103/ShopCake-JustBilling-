using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopCakeManager
{
    public partial class frmNote : Form
    {
        public static string note;
        public static DateTime ngaynhan;
        private static frmNote inst;
        public frmNote()
        {
            InitializeComponent();

        }

        public static frmNote getForm
        {
            get
            {
                if(inst == null || inst.IsDisposed){
                    inst = new frmNote();
                }
                return inst;
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Nhập ghi chú tại đây...";
            dtpk_ngaynhan.Value = DateTime.Now;
            this.Hide();
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (richTextBox1.Text == "Nhập ghi chú tại đây...")
                richTextBox1.Text = "";
        }

        private void richTextBox1_Leave(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
                richTextBox1.Text = "Nhập ghi chú tại đây...";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "" || richTextBox1.Text == "Nhập ghi chú tại đây...")
            {
                note = null;
            }
            else
                note = richTextBox1.Text;
            richTextBox1.Text = "Nhập ghi chú tại đây...";
            ngaynhan = dtpk_ngaynhan.Value;
            frm_Alert.Alert("Nhập ghi chú, ngày nhận success", frm_Alert.AlertType.success);
            this.Hide();
        }

        private void dtpk_ngaynhan_onValueChanged(object sender, EventArgs e)
        {
            if(dtpk_ngaynhan.Value < DateTime.Now){
                dtpk_ngaynhan.Value = DateTime.Now;
            }
        }

    }
}
