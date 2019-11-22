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
    public partial class frm_NhapKhachHang : Form
    {
        public static int kt = 0; // khai báo 1 biến để ktra nhập mã hay điển thông tin;
        public static string maKH=null;
        public static string tenKH= null;
        public static string sDTKH = null;
        public static string diaChiKH = null;

        private static frm_NhapKhachHang inst;

        ServiceReference.WebServiceSoapClient webservice = new ServiceReference.WebServiceSoapClient();
        public frm_NhapKhachHang()
        {
            InitializeComponent();

            txtMaTV.Text = "Chưa có mã T/Viên, nhập thông tin nào! ";

            txtMaTV.Enabled = false;
        }

        public static frm_NhapKhachHang getForm
        {
            get
            {
                if(inst == null || inst.IsDisposed){
                    inst = new frm_NhapKhachHang();
                }
                return inst;
            }
        }

        private void cb_thetv_OnChange(object sender, EventArgs e)
        {
            if (cb_thetv.Checked)
            {
                kt = 1;
                //cb_thetv.Checked = false;
                txtMaTV.Text = "";
                txtMaTV.Enabled = true;
                txtTenKH.Enabled = false;
                txtSDTKH.Enabled = false;
                txtDiaChiKH.Enabled = false;
                
            }
            else
            {
                kt = 0;
                //cb_thetv.Checked = true;
                txtMaTV.Text = "Chưa có mã T/Viên, nhập thông tin nào! ";
                txtMaTV.Enabled = false;
                errorProvider1.SetError(txtMaTV,null);
                txtTenKH.Enabled = true;
                txtSDTKH.Enabled = true;
                txtDiaChiKH.Enabled = true;
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {
            //if (cb_thetv.Checked)
            //{
            //    cb_thetv.Checked = false;
            //}
            //else
            //    cb_thetv.Checked = true;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            reset();
            kt = 1;
            this.Hide();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cb_thetv.Checked)
            {
                if (txtMaTV.Text == string.Empty)
                {
                    errorProvider1.SetError(txtMaTV, "Mã thành viên không được rỗng");
                    txtMaTV.Focus();
                    return;
                }
                else
                {
                    errorProvider1.SetError(txtMaTV, null);
                }
                bool t = webservice.check_MaKH(Int32.Parse(txtMaTV.Text));
                if (!t)
                {
                    frm_Alert.Alert("Nhập sai mã thành viên!", frm_Alert.AlertType.error);
                    return;
                }
                maKH = txtMaTV.Text;
                this.Hide();

            }
            else
            {
                if (txtTenKH.Text == string.Empty)
                {
                    errorProvider1.SetError(txtTenKH, "Tên KH không được rỗng");
                    return;
                }
                if (txtSDTKH.Text == string.Empty)
                {
                    errorProvider1.SetError(txtSDTKH, "SĐT KH không được rỗng");
                    return;
                }
                if (txtDiaChiKH.Text == string.Empty)
                {
                    errorProvider1.SetError(txtDiaChiKH, "Địa chỉ KH không được rỗng");
                    return;
                }
                
                tenKH = txtTenKH.Text;
                sDTKH = txtSDTKH.Text;
                diaChiKH = txtDiaChiKH.Text;

                this.Hide();

            }
            frm_Alert.Alert("Nhập khách hàng thành công", frm_Alert.AlertType.success);
            reset();
        }

        private void txtMaTV_Validating(object sender, CancelEventArgs e)
        {
            //if (string.IsNullOrEmpty(txtMaTV.Text))
            //{
            //    e.Cancel = true;
            //    txtMaTV.Focus();
            //    errorProvider1.SetError(txtMaTV, "Nhập vào mã thành viên :)");
            //}
            //else
            //{
            //    e.Cancel = false;
            //    errorProvider1.SetError(txtMaTV, null);
            //}
        }

        private void txtSDTKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar !=(char)8)
            {
                errorProvider1.SetError(txtSDTKH, "Nhập SĐT là số nha:)");
                e.Handled = true;
            }
            else
            {
                errorProvider1.SetError(txtSDTKH, null);
                e.Handled = false;
            }
        }

        private void txtSDTKH_Leave(object sender, EventArgs e)
        {
            if (txtSDTKH.Text.Length != 10)
            {
                errorProvider1.SetError(txtSDTKH, "Nhập SĐT là 10 số :)");
                txtSDTKH.Focus();
            }
            else
            {
                errorProvider1.SetError(txtSDTKH, null);
            }
        }

        private void txtMaTV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                errorProvider1.SetError(txtMaTV, "Nhập Mã Thành Viên là số nha:)");
                e.Handled = true;
            }
            else
            {
                errorProvider1.SetError(txtMaTV, null);
                e.Handled = false;
            }
        }

        public void reset()
        {
            txtMaTV.ResetText();
            txtTenKH.ResetText();
            txtSDTKH.ResetText();
            txtDiaChiKH.ResetText();
        }
    }
}
