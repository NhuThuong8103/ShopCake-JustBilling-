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
    public partial class frm_SanPham : Form
    {
        private static frm_SanPham inst;

        ConvertDataTable convert = new ConvertDataTable();

        DataTable dt;

        int maBanhKemDangChon;

        int local;

        public string img;

        ServiceReference.WebServiceSoapClient webservice = new ServiceReference.WebServiceSoapClient();

        UC_ListSanPham uc_banhkem;

        List<UC_ListSanPham> lis = new List<UC_ListSanPham>();

        public delegate void delegate_clickChucNangSanPham(int id);
        public static event delegate_clickChucNangSanPham event_ClickChucNangSanPham;

        public delegate void delagate_CapNhatSanPham(int idBK);
        public static event delagate_CapNhatSanPham event_CapNhatSanPham;

        public delegate void delagate_MaSizeBanhDangChon(int idMSB);
        public static event delagate_MaSizeBanhDangChon event_MaSizeBanhDangChon;

        public frm_SanPham()
        {
            InitializeComponent();
        }

        public static frm_SanPham getForm
        {
            get
            {
                if (inst == null || inst.IsDisposed)
                {
                    inst = new frm_SanPham();
                }
                return inst;
            }
        }

        private void loadBanhKem()
        {
            dt = convert.ToDataTable(webservice.get_ThongTinQuanLyBanhKem());

            foreach (DataRow item in dt.Rows)
            {
                uc_banhkem = new UC_ListSanPham();

                uc_banhkem.MaBK = Int32.Parse(item["maBK"].ToString());

                uc_banhkem.TenBanhKem = item["tenBanhkem"].ToString();

                uc_banhkem.TenLoai = item["tenLoai"].ToString();

                uc_banhkem.HinhAnhBanhKem = item["hinhAnhBK"].ToString();

                txtMoTa.Text = item["moTa"].ToString();

                uc_banhkem.ClickSanPham += User_ClickSanPham;

                uc_banhkem.Dock = DockStyle.Top;

                fl_listBanhKem.Controls.Add(uc_banhkem);

                lis.Add(uc_banhkem);
            }
            for (int i = 0; i < dt.Rows.Count; i++) // cho chọn mặc định UC đầu tiên.
            {
                lis[0].IsSelected = true;

                maBanhKemDangChon = lis[0].MaBK;
            }
           load_PanelRight(maBanhKemDangChon);
        }

        void load_PanelRight(int maBKDC)
        {
            dt = convert.ToDataTable(webservice.get_ThongTinBanhKemDangChon(maBKDC));
            lbTenBanhKem.Text = dt.Rows[0]["tenBanhKem"].ToString();
            lbTenLoai.Text = dt.Rows[0]["tenLoai"].ToString();
            txtMoTa.Text = dt.Rows[0]["moTa"].ToString();
            txtGG.Text = dt.Rows[0]["tenGG"].ToString();
            img = dt.Rows[0]["hinhAnhBK"].ToString();

            if (img == string.Empty)
            {
                img = "product.png";
            }
            var imageMS = new MemoryStream(webservice.get_imageFile(img));

            Image imageFS = Image.FromStream(imageMS);

            anhSanPham.Image = imageFS;

           
            load_CbSize(maBKDC);
            cbSize.SelectedIndex = 0;
            
        }

        void load_CbSize(int mabanhkem)
        {
            dt = convert.ToDataTable(webservice.get_SizeSanPhamDangChon(mabanhkem));
            cbSize.DataSource = dt;
            cbSize.DisplayMember = "tenSize";
            cbSize.ValueMember = "maSB"; // hihihihihiihihihi
            cbSize.SelectedIndex = 0;
            
        }

        void User_ClickSanPham(object sender, EventArgs e)
        {
            foreach (Control c in fl_listBanhKem.Controls)
            {
                if (c is UC_ListSanPham)
                {
                    ((UC_ListSanPham)c).IsSelected = false;
                }
            }
            maBanhKemDangChon = Int32.Parse((sender as UC_ListSanPham).Tag.ToString());
            load_PanelRight(Int32.Parse((sender as UC_ListSanPham).Tag.ToString()));
        }

        private void frm_SanPham_Load(object sender, EventArgs e)
        {
            loadBanhKem();
        }

        int get_GiaSanPham()
        {
            var bk = cbSize.SelectedValue;
            DataRowView da = (DataRowView)cbSize.SelectedItem;
            int maSB;

            if (da != null)
            {
                maSB = webservice.get_GiaSanPhamTheoSize(int.Parse(da[1].ToString()));
                return maSB;
            }
            return -1;
        }

        private void cbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGia.Text = get_GiaSanPham().ToString();
        }

        private void btn_ThemSP_Click(object sender, EventArgs e)
        {
            //MaskedDialog.ShowDialog(this,frm_ThemSanPham.getForm);
            frm_ThemSanPham.even_LoadSanPham += frm_ThemSanPham_even_LoadSanPham;
            frm_ThemSanPham.getForm.Show();
            local = 1;
            event_ClickChucNangSanPham(local);
        }

        void frm_ThemSanPham_even_LoadSanPham()
        {
           // throw new NotImplementedException();
            fl_listBanhKem.Controls.Clear();
            loadBanhKem();
        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            int idmsb = int.Parse(cbSize.SelectedValue.ToString());
            frm_ThemSanPham.getForm.Show();
            //MaskedDialog.ShowDialog(this, frm_ThemSanPham.getForm);
            local = 2;
            event_ClickChucNangSanPham(local);
            event_CapNhatSanPham(maBanhKemDangChon);
            event_MaSizeBanhDangChon(idmsb);

            frm_ThemSanPham.event_loadContentRightSanPham += frm_ThemSanPham_event_loadContentRightSanPham;

            //MessageBox.Show(idmsb.ToString());
        }

        void frm_ThemSanPham_event_loadContentRightSanPham()
        {
            //throw new NotImplementedException();
            load_PanelRight(maBanhKemDangChon);
            fl_listBanhKem.Controls.Clear();
            loadBanhKem();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Không thể xóa vì Sản phẩm đang được sử dụng", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        
    }
}
