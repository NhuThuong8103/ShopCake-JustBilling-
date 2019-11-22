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
    public partial class frm_GiamGia : Form
    {
        private static frm_GiamGia inst;

        ConvertDataTable convert = new ConvertDataTable();

        DataTable dt;

        ServiceReference.WebServiceSoapClient webservice = new ServiceReference.WebServiceSoapClient();

        public frm_GiamGia()
        {
            InitializeComponent();
        }

        public static frm_GiamGia getForm
        {
            get
            {
                if (inst == null || inst.IsDisposed)
                {
                    inst = new frm_GiamGia();
                }
                return inst;
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void load_dtgvGG()
        {
            dt = convert.ToDataTable(webservice.get_ListGiamGia());
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
            
        }

        private void frm_GiamGia_Load(object sender, EventArgs e)
        {
            txtTenGG.Focus();
            load_dtgvGG();
        }

        private void btn_ThemSP_Click(object sender, EventArgs e)
        {
            string tenGG = txtTenGG.Text;
            if (tenGG == "")
            {
                MessageBox.Show("Giảm giá chưa đặt tên!");
            }
            else
            {
                webservice.InsertGiamGia(tenGG);
                load_dtgvGG();
                txtTenGG.Text = "";
            }
        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            string tengg = txtTenGG.Text;
            if (tengg == "")
            {
                MessageBox.Show("Giảm giá chưa đặt tên!");
            }
            else
            {
                int magg = int.Parse(dataGridView1.CurrentRow.Cells["MaGG"].Value.ToString());
                webservice.UpdateGiamGia(magg, tengg);
                load_dtgvGG();
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            int magg = int.Parse(dataGridView1.CurrentRow.Cells["MaGG"].Value.ToString());
            try
            {
                webservice.DeleteGiamGia(magg);
                load_dtgvGG();
                MessageBox.Show("Đã xóa thành công!");
            }
            catch (Exception)
            {
                MessageBox.Show("Mã giảm giá đang được sử dụng!");
                //throw;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtTenGG_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
