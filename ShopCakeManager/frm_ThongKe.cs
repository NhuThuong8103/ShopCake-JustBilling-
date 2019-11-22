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
    public partial class frm_ThongKe : Form
    {
        ServiceReference.WebServiceSoapClient webservice = new ServiceReference.WebServiceSoapClient();

        ConvertDataTable convert = new ConvertDataTable();

        DataTable dt = new DataTable();

        public int tong = 0;

        public static frm_ThongKe inst;

        public static string tentab;

        public frm_ThongKe()
        {
            InitializeComponent();

            tabControl1.Enabled = false;
        }

        public static frm_ThongKe getFrom
        {
            get
            {
                if (inst == null || inst.IsDisposed)
                    inst = new frm_ThongKe();
                return inst;
            }
        }

        void Visuble_Ngay()
        {
            time1.Visible = true;
            time2.Visible = true;
            lb_headTuNgay.Visible = true;
            lb_head_DenNgay.Visible = true;
        }

        private void Load_ThongKeHDBan(DateTime tuNgay, DateTime denNgay)
        {
                dt = convert.ToDataTable(webservice.get_HoaDonDaBan(tuNgay, denNgay));

                dtgv_ThongKeHDBan.AutoGenerateColumns = false;

                dtgv_ThongKeHDBan.DataSource = dt;

                lb_TongHD.Text = dtgv_ThongKeHDBan.RowCount.ToString();

                lb_DoanhThuBan.Text = webservice.get_ThongKeTongTien_HDDaBan(tuNgay, denNgay).ToString();
        }

        private void Load_ThongKePhieuDat(DateTime tuNgay, DateTime denNgay)
        {
            
            dt = convert.ToDataTable(webservice.get_ThongKePhieuDat(tuNgay, denNgay));

            dtgv_ThongKePhieuDat.AutoGenerateColumns = false;

            dtgv_ThongKePhieuDat.DataSource = dt;

            lb_TongPD.Text = dtgv_ThongKePhieuDat.RowCount.ToString();

            lb_DoanhSo.Text = webservice.get_ThongKeTongTien_PhieuDat(tuNgay, denNgay).ToString();
        }
        private void Load_ThongKeDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            panel1.Controls.Add(bunifuCharts1);

            bunifuCharts1.colorSet.Add(Color.FromArgb(149, 83, 93));
            bunifuCharts1.colorSet.Add(Color.FromArgb(255, 155, 45));

            lb_doanhThuHD.Text = webservice.get_SoLieu_DoanhThuHD(tuNgay, denNgay).ToString();

            lb_doanhThuPD.Text = webservice.get_SoLieu_DoanhThuPD(tuNgay, denNgay).ToString();

            lb_tongDoanhThu.Text = (webservice.get_SoLieu_DoanhThuHD(tuNgay, denNgay) + webservice.get_SoLieu_DoanhThuPD(tuNgay, denNgay)).ToString();

            lb_tongSoHD.Text = webservice.get_SoLieu_TongSoHD(tuNgay, denNgay).ToString();

            lb_tongSoPD.Text = webservice.get_SoLieu_TongSoPD(tuNgay, denNgay).ToString();
        }

        private int LayDoanhThu_PD()
        {
            for (int row = 0; row < dtgv_ThongKePhieuDat.RowCount; row++)
            {
                tong += Int32.Parse(dtgv_ThongKePhieuDat.Rows[row].Cells["TongTienPD"].Value.ToString());
            }
            return tong;
        } // không còn dùng

        private void btn_Xem_Click(object sender, EventArgs e)
        {
            tentab = tabControl1.SelectedTab.Name.ToString();
            frm_DanhSachKHTiemNang f = new frm_DanhSachKHTiemNang();
            f.Show();
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            tabControl1.Enabled = true;
        }

        private void btn_XemKH_Click(object sender, EventArgs e)
        {
            tentab = tabControl1.SelectedTab.Name.ToString();
            frm_DanhSachKHTiemNang g = new frm_DanhSachKHTiemNang();
            g.Show();
        }

        private void delay_Tick(object sender, EventArgs e)
        {

        }

        void RenderChart() // vẽ biểu đồ
        {
            Bunifu.DataViz.Data data = new Bunifu.DataViz.Data();

            Bunifu.DataViz.DataPoint point = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuCharts._type.spline);
            point.addLabely("Monday", "580");
            point.addLabely("Tuesday", "500");
            point.addLabely("Wednesday", "400");
            point.addLabely("Thursday", "800");
            point.addLabely("Friday", "400");
            point.addLabely("Saturday", "580");
            point.addLabely("Sunday", "500");
            data.addData(point);
            Bunifu.DataViz.DataPoint point2 = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuCharts._type.spline);
            point2.addLabely("Monday", "2800");
            point2.addLabely("Tuesday", "2500");
            point2.addLabely("Wednesday", "3200");
            point2.addLabely("Thursday", "6000");
            point2.addLabely("Friday", "3500");
            point2.addLabely("Saturday", "4000");
            point2.addLabely("Sunday", "8000");
            data.addData(point2);

            bunifuCharts1.Render(data);
        }

        private void tab_ThongKeDoanhThu_Click(object sender, EventArgs e)
        {
            string day1 = time1.Value.ToString("MM/dd/yyyy");

            string day2 = time2.Value.ToString("MM/dd/yyyy");

            lb_TuNgay1.Text = day1;

            lb_DenNgay1.Text = day2;

            Visuble_Ngay();

            RenderChart();

            Load_ThongKeDoanhThu(DateTime.Parse(day1), DateTime.Parse(day2));
        }

        private void time2_onValueChanged(object sender, EventArgs e)
        {
            if (time2.Value < time1.Value)
                time2.Value = time1.Value;
            else
                return;
        }

        private void Load_ThongKeBanhTrongNgay()
        {
            time2.Visible = false;
            time1.Visible = false;
            lb_head_DenNgay.Visible = false;
            lb_headTuNgay.Visible = false;

            dt = convert.ToDataTable(webservice.get_SoLieuBanhTrongNgay());

            dtgv_ThongkeBanhTrongNgay.AutoGenerateColumns = false;

            dtgv_ThongkeBanhTrongNgay.DataSource = dt;

            lb_SoBanhHienTai.Text = webservice.get_ThongKeSoBanhHienTaiTrongNgay().ToString();

            lb_SoBanhHetHan.Text = webservice.get_ThongKeSoBanhHetHanTrongNgay().ToString();

            lb_SoBanhBan.Text = webservice.get_ThongKeSoBanhDaBanTrongNgay().ToString();
        }

        private void tab_ThongKeBanhTrongNgay_Click(object sender, EventArgs e)
        {
            lb_ThongKeNgayBK.Text = DateTime.Today.Date.ToString();

            Load_ThongKeBanhTrongNgay();
        }

        private void tab_ThongKePhieuDat_Click(object sender, EventArgs e)
        {
            string day1 = time1.Value.ToString("MM/dd/yyyy");

            string day2 = time2.Value.ToString("MM/dd/yyyy");

            lb_TuNgay2.Text = day1;

            lb_DenNgay2.Text = day2;

            Visuble_Ngay();

            Load_ThongKePhieuDat(DateTime.Parse(day1), DateTime.Parse(day2));
        }

        private void tab_ThongKeHoaDonBan_Click(object sender, EventArgs e)
        {
            string day1 = time1.Value.ToString("MM/dd/yyyy");

            string day2 = time2.Value.ToString("MM/dd/yyyy");

            lb_TuNgay3.Text = day1;

            lb_DenNgay3.Text = day2;

            Visuble_Ngay();

            Load_ThongKeHDBan(DateTime.Parse(day1), DateTime.Parse(day2));
        }
    }
}