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
    public partial class frm_DangNhap : Form
    {
        public static int w_slide=0;
        public static bool hided = true;
        public static int IDNV = 0;
        private static frm_DangNhap inst;
        
        public ServiceReference.WebServiceSoapClient webservice = new ServiceReference.WebServiceSoapClient();
        public frm_DangNhap()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
            
            panelslide.Width = w_slide;

            
        }
        public static frm_DangNhap getForm
        {
            get
            {
                if(inst==null || inst.IsDisposed){
                    inst = new frm_DangNhap();
                }
               
                return inst;
            }
        }
        private void frm_DangNhap_Load(object sender, EventArgs e)
        {
            enable_btn();
            if(IDNV!=0){
                getListHoatDong();
            }
        }

        private void cbxShowPass_OnChange(object sender, EventArgs e)
        {
            if (cbxShowPass.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;

                bunifuCustomLabel3.ForeColor = Color.SteelBlue;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;

                bunifuCustomLabel3.ForeColor = Color.White;
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn thực sự muốn thoát :((", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            panel1.BackColor = Color.SteelBlue;
            txtUsername.ForeColor = Color.Red;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            panel2.BackColor = Color.SteelBlue;
            txtPassword.ForeColor = Color.Red;
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.White;
            txtUsername.ForeColor = Color.Black;
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.White;
            txtPassword.ForeColor = Color.Black;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int tmp = 0;
            tmp=webservice.get_Count_UserNV(txtUsername.Text);
            if (tmp == 0)
            {
                MessageBox.Show("Bạn đã sai tên đăng nhập :))");
                return;
            }
            tmp = webservice.get_CountUser_PassNV(txtUsername.Text,txtPassword.Text);
            if(tmp!=1){
                MessageBox.Show("Bạn đã sai mật khẩu :))");
                return;
            }
            IDNV = webservice.get_IDNV(txtUsername.Text, txtPassword.Text);

            timer1.Start();

            getListHoatDong();

            frm_Alert.Alert("Bạn đã đăng nhập thành công",frm_Alert.AlertType.success);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (hided)
            {
                //MessageBox.Show(Int32.Parse((this.Width * 0.25).ToString()).ToString());
                panelslide.Width += Int32.Parse(((this.Width) * 25 /100).ToString());
                if (panelslide.Width >= this.Width*90/100)
                {
                    timer1.Stop();
                    hided = false;
                    this.Refresh();
                }
            }
            else
            {
                panelslide.Width -= Int32.Parse((this.Width *25 / 100).ToString());
                if(panelslide.Width<=0)
                {
                    timer1.Stop();
                    hided = true;
                    this.Refresh();
                }
            }
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            timer1.Start();

            txtPassword.ResetText();

            enable_btn();
        }

        private void enable_btn()
        {
            btnBH.Enabled = false;
            btnTK.Enabled = false;
            btnQL.Enabled = false;
        }

        public void getListHoatDong()
        {
            List<Int32> listHD = null; // giữ list hoạt động

            int t = webservice.get_MaQuyenNV(IDNV);
            //MessageBox.Show(t.ToString());
            listHD = webservice.get_MaHoatDong(t);

            foreach (var item in listHD)
            {
                switch (item)
                {
                    case 8:
                        btnBH.Enabled = true;
                        break;
                    case 9:
                        btnTK.Enabled = true;
                        break;
                    case 10:
                        btnQL.Enabled = true;
                        break;
                    default:
                        break;
                }
            }


        }

        private void btnBH_Click(object sender, EventArgs e)
        {
            this.Hide();

            frm_BanHang.getForm.Show();            
        }

        private void btnQL_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_QuanLy.getForm.Show();
          
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            this.Hide();

            frm_ThongKe.getFrom.Show();
        }

    }
}
