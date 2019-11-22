using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShopCakeManager.UC;
using System.IO;

namespace ShopCakeManager
{
    public partial class frm_TheLoaiSanPham : Form
    {
        private static frm_TheLoaiSanPham inst;

        ConvertDataTable convert = new ConvertDataTable();

        DataTable dt;

        int maBanhKemDangChon;

        public string img;

        ServiceReference.WebServiceSoapClient webservice = new ServiceReference.WebServiceSoapClient();

        UC_LoaiSP uc_banhkem;

        List<UC_LoaiSP> lis = new List<UC_LoaiSP>();


        public frm_TheLoaiSanPham()
        {
            InitializeComponent();
        }
        public static frm_TheLoaiSanPham getForm
        {
            get
            {
                if (inst == null || inst.IsDisposed)
                {
                    inst = new frm_TheLoaiSanPham();
                }
                return inst;
            }
        }

        private void loadLoaiSP()
        {
            dt = convert.ToDataTable(webservice.get_ThongTinSanPham());

            foreach (DataRow item in dt.Rows)
            {
                uc_banhkem = new UC_LoaiSP();

                uc_banhkem.MaLoai = Int32.Parse(item["MaLoai"].ToString());

                uc_banhkem.TenLoai = item["TenLoai"].ToString();

                uc_banhkem.HinhAnhBanhKem = item["HinhAnhLoai"].ToString();

                uc_banhkem.ClickLoaiSP += User_ClickSanPham;

                uc_banhkem.Dock = DockStyle.Top;

                fl_listBanhKem.Controls.Add(uc_banhkem);

                lis.Add(uc_banhkem);
            }
            for (int i = 0; i < dt.Rows.Count; i++) // cho chọn mặc định UC đầu tiên.
            {
                lis[0].IsSelected = true;

                maBanhKemDangChon = lis[0].MaLoai;
            }
            load_PanelRight(maBanhKemDangChon);
        }

        void User_ClickSanPham(object sender, EventArgs e)
        {
            foreach (Control c in fl_listBanhKem.Controls)
            {
                if (c is UC_LoaiSP)
                {
                    ((UC_LoaiSP)c).IsSelected = false;
                }
            }
            maBanhKemDangChon = Int32.Parse((sender as UC_LoaiSP).Tag.ToString());
            load_PanelRight(Int32.Parse((sender as UC_LoaiSP).Tag.ToString()));
            MessageBox.Show(maBanhKemDangChon.ToString());
        }

        void load_PanelRight(int maBKDC)
        {
            dt = convert.ToDataTable(webservice.get_ThongTinLoaiSPDangChon(maBKDC));
            lbTenLoai.Text = dt.Rows[0]["TenLoai"].ToString();
            img = dt.Rows[0]["HinhAnhLoai"].ToString();

            if (img == string.Empty)
            {
                img = "product.png";
            }
            var imageMS = new MemoryStream(webservice.get_imageFile(img));

            Image imageFS = Image.FromStream(imageMS);

            anhSanPham.Image = imageFS;
        }

       
        private void frm_TheLoaiSanPham_Load(object sender, EventArgs e)
        {
            loadLoaiSP();
        }



    }
}
