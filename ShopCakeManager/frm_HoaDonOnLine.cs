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
    public partial class frm_HoaDonOnLine : Form
    {
        ServiceReference.WebServiceSoapClient webservice = new ServiceReference.WebServiceSoapClient();

        public static string values;

        ConvertDataTable convert = new ConvertDataTable();

        DataTable dt = new DataTable();

        public static frm_HoaDonOnLine inst;

        public frm_HoaDonOnLine()
        {
            InitializeComponent();

            load_PhieuDatOnline();

            load_PhieuDatTaiQuay();

            load_PhieuDatDangGiao();
        }

        public static frm_HoaDonOnLine getForm_PhieuDat
        {
            get
            {
                if( inst == null || inst.IsDisposed)
                    inst = new frm_HoaDonOnLine();
                return inst; 
            }
        
        }

        private void load_PhieuDatOnline()
        {

            dt = convert.ToDataTable(webservice.get_DanhSachPhieuDat_Online());

            dtgv_DonHangOnline.AutoGenerateColumns = false;

            dtgv_DonHangOnline.DataSource = dt;

            foreach( DataGridViewRow row in dtgv_DonHangOnline.Rows)
            {
                if (row.Cells["DaThanhToan"].Value.ToString() == null)
                    return;
                if (row.Cells["DaThanhToan"].Value.ToString() == "False")
                {
                    row.Cells["DaThanhToan"].Value = "Chưa";
                }
                else
                {
                    row.Cells[8].Value = "Rồi";
                }
            }

            dtgv_DonHangOnline.Refresh();
        }

        private void load_PhieuDatTaiQuay()
        {
            dt = convert.ToDataTable(webservice.get_DanhSachPhieuDat_TaiQuay());

            dtgv_DonHangTaiQuay.AutoGenerateColumns = false;

            dtgv_DonHangTaiQuay.DataSource = dt;

            foreach (DataGridViewRow row in dtgv_DonHangTaiQuay.Rows)
            {
                if (row.Cells["DaThanhToan_Quay"].Value.ToString() == null)
                    return;
                if (row.Cells["DaThanhToan_Quay"].Value.ToString() == "False")
                {
                    row.Cells["DaThanhToan_Quay"].Value = "Chưa";
                }
                else
                {
                    row.Cells[8].Value = "Rồi";
                }
            }

            dtgv_DonHangTaiQuay.Refresh();
        }

        private void load_PhieuDatDangGiao()
        {
            dt = convert.ToDataTable(webservice.get_DanhSachPhieuDat_DangGiao());

            dtgv_DonHangGiao.AutoGenerateColumns = false;

            dtgv_DonHangGiao.DataSource = dt;

            foreach (DataGridViewRow row in dtgv_DonHangGiao.Rows)
            {
                if (row.Cells["TrangThaiOnline"].Value.ToString() == null)
                    return;

                if (row.Cells["TrangThaiOnline"].Value.ToString() == "False" && row.Cells["DaThanhToan_Giao"].Value.ToString() == "False")
                {
                    row.Cells["TrangThaiOnline"].Value = "Off";
                    row.Cells["DaThanhToan_Giao"].Value = "Chưa";
                }
                else if (row.Cells["TrangThaiOnline"].Value.ToString() == "False" && row.Cells["DaThanhToan_Giao"].Value.ToString() == "True")
                {
                    row.Cells["TrangThaiOnline"].Value = "Off";
                    row.Cells["DaThanhToan_Giao"].Value = "Rồi";
                }
                else if (row.Cells["TrangThaiOnline"].Value.ToString() == "True" && row.Cells["DaThanhToan_Giao"].Value.ToString() == "True")
                {
                    row.Cells["TrangThaiOnline"].Value = "Onl";
                    row.Cells["DaThanhToan_Giao"].Value = "Rồi";
                }
                else
                {
                    row.Cells["TrangThaiOnline"].Value = "Onl";
                    row.Cells["DaThanhToan_Giao"].Value = "Chưa";
                }
            }

            dtgv_DonHangGiao.Refresh();
        }

        private void dtgv_DonHangOnline_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dtgv_DonHangOnline.Rows[e.RowIndex].Cells["STT2"].Value = e.RowIndex + 1;
        }

        private void dtgv_DonHangGiao_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dtgv_DonHangGiao.Rows[e.RowIndex].Cells["STT3"].Value = e.RowIndex + 1;
        }

        private void dtgv_DonHangTaiQuay_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dtgv_DonHangTaiQuay.Rows[e.RowIndex].Cells["STT1"].Value = e.RowIndex + 1;
        }

        public void btn_XemChiTietPhieuDat_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTabIndex == 0)
                {
                    values = dtgv_DonHangTaiQuay.CurrentRow.Cells[1].Value.ToString();
                }
                else if (tabControl1.SelectedTabIndex == 1)
                {
                    values = dtgv_DonHangOnline.CurrentRow.Cells[1].Value.ToString();
                }
                else
                {
                    values = dtgv_DonHangGiao.CurrentRow.Cells[1].Value.ToString();
                }

                frm_ChiTietPhieuDat ct = new frm_ChiTietPhieuDat();
                ct.Show();

            }
            catch (Exception)
            {
                MessageBox.Show("Bạn chưa chọn phiếu đặt");
            }
            
        }

        private void btn_XacNhanGiao_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTabIndex == 0) // đang ở tag đơn hàng tại quầy
            {
                values = dtgv_DonHangTaiQuay.CurrentRow.Cells["MaPD_1"].Value.ToString();
                if (MessageBox.Show("Xác nhận giao đơn hàng " + values.ToString() + "?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dtgv_DonHangTaiQuay.Rows.Remove(dtgv_DonHangTaiQuay.CurrentRow);

                    webservice.set_TinhTrangDangGiaoHangPhieuDat(values);

                    load_PhieuDatDangGiao();
                }
            }
            else if (tabControl1.SelectedTabIndex == 1) // tag đơn hàng đặt online
            {
                values = dtgv_DonHangOnline.CurrentRow.Cells["MaPD_2"].Value.ToString();

                if (MessageBox.Show("Xác nhận giao đơn hàng " + values.ToString() + "?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dtgv_DonHangOnline.Rows.Remove(dtgv_DonHangOnline.CurrentRow);

                    webservice.set_TinhTrangDangGiaoHangPhieuDat(values);

                    load_PhieuDatDangGiao();
                }
            }
            else
            {
                values = dtgv_DonHangGiao.CurrentRow.Cells["MaPD_3"].Value.ToString();

                if (MessageBox.Show("Xác nhận đơn hàng " + values.ToString() + "đã giao?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dtgv_DonHangGiao.Rows.Remove(dtgv_DonHangGiao.CurrentRow);

                    webservice.set_TinhTrangGiaoHangXong(values);

                    load_PhieuDatDangGiao();
                }
            }
        }

        private void btn_QuayVe_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            //frm_Menu.getForm.Show();
        }

        private void txt_TimKiem2_KeyPress(object sender, KeyPressEventArgs e)
        {
            values = txt_TimKiem2.Text;

            dt = convert.ToDataTable(webservice.search_PhieuDatDangGiao(values));

            dtgv_DonHangGiao.DataSource = dt;
        }

        private void btn_TimKiem2_Click(object sender, EventArgs e)
        {
            values = txt_TimKiem2.Text;

            dt = convert.ToDataTable(webservice.search_PhieuDatDangGiao(values));

            if (dt == null)
            {
                MessageBox.Show("Không có dữ liệu? ok");
            }
            else
                dtgv_DonHangGiao.DataSource = dt;
        }

        private void txt_TimKiem1_KeyPress(object sender, KeyPressEventArgs e)
        {
            values = txt_TimKiem1.Text;

            dt = convert.ToDataTable(webservice.search_PhieuDatOnline(values));

            dtgv_DonHangOnline.DataSource = dt;
        }

        private void btn_TimKiem1_Click(object sender, EventArgs e)
        {
            values = txt_TimKiem1.Text;

            dt = convert.ToDataTable(webservice.search_PhieuDatOnline(values));

            if (dt == null)
            {
                MessageBox.Show("Không có dữ liệu? ok");
            }
            else
                dtgv_DonHangOnline.DataSource = dt;
        }

        private void txt_TimKiem0_KeyPress(object sender, KeyPressEventArgs e)
        {
            values = txt_TimKiem0.Text;

            dt = convert.ToDataTable(webservice.search_PhieuDatTaiQuay(values));

            dtgv_DonHangTaiQuay.DataSource = dt;
        }

        private void btn_TimKiem0_Click(object sender, EventArgs e)
        {
            values = txt_TimKiem0.Text;

            dt = convert.ToDataTable(webservice.search_PhieuDatTaiQuay(values));

            if (dt == null)
            {
                MessageBox.Show("Không có dữ liệu? ok");
            }
            else
                dtgv_DonHangTaiQuay.DataSource = dt;
        }


    }
}
