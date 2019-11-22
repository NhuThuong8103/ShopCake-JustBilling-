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
    public partial class frm_DanhSachKHTiemNang : Form
    {
        ServiceReference.WebServiceSoapClient webservice = new ServiceReference.WebServiceSoapClient();

        ConvertDataTable convert = new ConvertDataTable();

        DataTable dt = new DataTable();

        public static frm_DanhSachKHTiemNang inst;

        public string tab;
 

        public frm_DanhSachKHTiemNang()
        {
            InitializeComponent();
            tab = frm_ThongKe.tentab;
            if (tab == "tab_ThongKeHoaDonBan")
                Load_KHTiemNang();
            else if (tab == "tab_ThongKePhieuDat")
                Load_KHTiemNang_DatHang();
            else { }
        }
        public frm_DanhSachKHTiemNang(string tab)
        {

        }


        public static frm_DanhSachKHTiemNang getForm
        {
            get
            {
                if (inst == null || inst.IsDisposed)
                    inst = new frm_DanhSachKHTiemNang();
                return inst;
            }

        }

        public void Load_KHTiemNang()
        {
            dt.Clear();

            dt = convert.ToDataTable(webservice.get_KH_TiemNang());

            dtgv_KHTiemNang.AutoGenerateColumns = false;

            dtgv_KHTiemNang.DataSource = dt;

        }

        public void Load_KHTiemNang_DatHang()
        {
            dt.Clear();
            dtgv_KHTiemNang.ClearSelection();

            dt = convert.ToDataTable(webservice.get_KH_TiemNang_DatHang());

            dtgv_KHTiemNang.AutoGenerateColumns = false;

            dtgv_KHTiemNang.DataSource = dt;

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Refresh();
            this.Hide();
            
        }

        private void btn_Dong_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
