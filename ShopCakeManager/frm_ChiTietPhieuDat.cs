using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopCakeManager
{
    public partial class frm_ChiTietPhieuDat : Form
    {
        ServiceReference.WebServiceSoapClient webservice = new ServiceReference.WebServiceSoapClient();

        //frm_HoaDonOnLine hd = new frm_HoaDonOnLine();

        string ma_phieudat = frm_HoaDonOnLine.values;

        public frm_ChiTietPhieuDat()
        {
            InitializeComponent();
            Load_ChiTietPhieuDat();
            Load_ThongTinPhieuDat();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Load_ChiTietPhieuDat()
        {

            DataTable dt = new DataTable();

            ConvertDataTable convert = new ConvertDataTable();

            dt = convert.ToDataTable(webservice.get_ChiTietPhieuDat(ma_phieudat));

            dtgv_PhieuDatChiTiet.AutoGenerateColumns = false;

            dtgv_PhieuDatChiTiet.DataSource = dt;
        }

        private void Load_ThongTinPhieuDat()
        {
            DataTable dt = new DataTable();

            ConvertDataTable convert = new ConvertDataTable();

            dt = convert.ToDataTable(webservice.get_ThongTinPhieuDat(ma_phieudat));

            CultureInfo cultu = new CultureInfo("vi-VN");

            foreach (DataRow item in dt.Rows)
            {
                lb_tenKH.Text = item["tenKH"].ToString();
                lb_sdt.Text = item["sdt"].ToString();
                lb_NgayNhan.Text = item["ngaynhan"].ToString();
                lb_NgayDat.Text = item["ngaydat"].ToString();
                lb_maPhieuDat.Text = item["maPD"].ToString();
                lb_DiaChi.Text = item["diachiKH"].ToString();
                lb_tongtien.Text = item["tongtien"].ToString();
            }
        }

        private void dtgv_PhieuDatChiTiet_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dtgv_PhieuDatChiTiet.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

        private void btn_QuayVePhieuDat_Click(object sender, EventArgs e)
        {
            this.Hide();
    //        this.Close();
        }

        private void btn_InPhieu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vui lòng kết nối máy in!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
}
