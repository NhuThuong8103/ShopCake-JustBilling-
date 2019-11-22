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
    public partial class frm_CheckBanhHetHan : Form
    {
        ServiceReference.WebServiceSoapClient webservive = new ServiceReference.WebServiceSoapClient();

        ConvertDataTable convert = new ConvertDataTable();

        DataTable dt = new DataTable();

        public static frm_CheckBanhHetHan inst;

        public int countLoai = 0, countBanh = 0, maBanhTrongNgay;

        public frm_CheckBanhHetHan()
        {
            InitializeComponent();
            Load_DanhSachBanhHetHan();
        }

        public static frm_CheckBanhHetHan getFrom
        {
            get
            {
                if( inst == null || inst.IsDisposed)
                    inst = new frm_CheckBanhHetHan();
                return inst;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void Load_DanhSachBanhHetHan()
        {
            dt = convert.ToDataTable(webservive.get_ListBanhHetHan());

            dtgv_ThongKeBanhHetHan.AutoGenerateColumns = false;

            dtgv_ThongKeBanhHetHan.DataSource = dt;

            lb_SoloaiHH.Text = Load_SoLoaiBanhHetHan().ToString();

            lb_SoBanhHH.Text = Load_SoBanhHetHan().ToString();

        }

        private void dtgv_ThongKeBanhHetHan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private int Load_SoLoaiBanhHetHan()
        {
            countLoai = webservive.get_CountSoLoaiBanh_HetHan();
            return countLoai;
        }

        private int Load_SoBanhHetHan()
        {
            //countBanh = webservive.get_ThongKeSoBanhHetHanTrongNgay();
            countBanh = webservive.get_CountBanhHetHan();
            return countBanh;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (dtgv_ThongKeBanhHetHan.CurrentRow == null)
            {
                MessageBox.Show("Bạn chưa chọn bánh để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else 
            {
                maBanhTrongNgay = Int32.Parse(dtgv_ThongKeBanhHetHan.CurrentRow.Cells["MaBTN"].Value.ToString());
                webservive.set_TinhTrangBanhTrongNgayHetHanThanhFalse(maBanhTrongNgay);
                Load_DanhSachBanhHetHan();
                Load_SoBanhHetHan();
                Load_SoLoaiBanhHetHan();
            }
        }

        private void btn_XoaTatCa_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtgv_ThongKeBanhHetHan.RowCount; i++)
            {
                maBanhTrongNgay = Int32.Parse(dtgv_ThongKeBanhHetHan.Rows[i].Cells["MaBTN"].Value.ToString());
                webservive.set_TinhTrangBanhTrongNgayHetHanThanhFalse(maBanhTrongNgay);
            }
            Load_DanhSachBanhHetHan();
        }

        private void txt_TimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
