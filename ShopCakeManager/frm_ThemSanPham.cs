using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopCakeManager
{
    public partial class frm_ThemSanPham : Form
    {
        ServiceReference.WebServiceSoapClient webservice = new ServiceReference.WebServiceSoapClient();

        ConvertDataTable convert = new ConvertDataTable();

        DataTable dt = new DataTable();

        public static frm_ThemSanPham inst;


        public delegate void delegate_LoadSanPham();
        public static event delegate_LoadSanPham even_LoadSanPham;

        public delegate void delegate_loadContentRight();
        public static event delegate_loadContentRight event_loadContentRightSanPham;

        int iDSP;
        int iDMSB;

        public frm_ThemSanPham()
        {
            InitializeComponent();
        }

        public static frm_ThemSanPham getForm
        {
            get
            {
                if (inst == null || inst.IsDisposed)
                    inst = new frm_ThemSanPham();
                return inst;
            }
        }

        private void load_CbTheLoai()
        {
            dt = convert.ToDataTable(webservice.get_TenTheLoai());
            cb_TenTheLoai.DataSource = dt;
            cb_TenTheLoai.DisplayMember = "tenTL";
            cb_TenTheLoai.ValueMember = "maTL";
        }

        private void load_CbSize()
        {
            dt = convert.ToDataTable(webservice.get_TenSize());
            cb_Size.DataSource = dt;
            cb_Size.DisplayMember = "tenSize";
            cb_Size.ValueMember = "maSize";
        }

        private void load_CbGiamGia()
        {
            dt = convert.ToDataTable(webservice.get_TenGiamGia());
            cb_GiamGia.DataSource = dt;
            cb_GiamGia.DisplayMember = "tenGG";
            cb_GiamGia.ValueMember = "maGG";
        }

        private void frm_ThemSanPham_Load(object sender, EventArgs e)
        {
            frm_SanPham.event_ClickChucNangSanPham += frm_SanPham_event_ClickChucNangSanPham;

            frm_SanPham.event_MaSizeBanhDangChon += frm_SanPham_event_MaSizeBanhDangChon;
        }

        void frm_SanPham_event_MaSizeBanhDangChon(int idMSB)
        {
            iDMSB = idMSB;
        }

        void frm_SanPham_event_ClickChucNangSanPham(int id)
        {
            if (id == 1)
            {
                load_CbTheLoai();
                load_CbSize();
                load_CbGiamGia();
                btn_CapNhat.Visible = false;
                btn_Luu.Visible = true;
            }
            else
            {
                load_CbTheLoai();
                load_CbSize();
                load_CbGiamGia();
                btn_CapNhat.Visible = true;
                btn_Luu.Visible = false;
                btn_CapNhat.Location = new Point(574,734);

                frm_SanPham.event_CapNhatSanPham += frm_SanPham_event_CapNhatSanPham;
                
            }
        }

        void frm_SanPham_event_CapNhatSanPham(int idBK)
        {
            updateSanPhamDangChon(idBK);
        }

        void updateSanPhamDangChon(int idBanhKem)
        {
            string img;
            //dt = new DataTable();
            dt = convert.ToDataTable(webservice.get_ThongTinSanPhamUpdate1(idBanhKem));
            cb_TenTheLoai.SelectedText = dt.Rows[0]["tenLoai"].ToString();
            cb_TenTheLoai.SelectedValue = dt.Rows[0]["maTL"].ToString();
            cb_Size.SelectedText = dt.Rows[0]["tenSize"].ToString();
            cb_Size.SelectedValue = dt.Rows[0]["maSize"].ToString();
            cb_GiamGia.SelectedText = dt.Rows[0]["tenGG"].ToString();
            cb_GiamGia.SelectedValue = dt.Rows[0]["maGG"].ToString();
            txtGia.Text = dt.Rows[0]["gia"].ToString();
           // dtpk_NgayHetHan.Value = DateTime.Parse(dt.Rows[0]["ngayHetHan"].ToString());

            txtTenBanh.Text = dt.Rows[0]["tenBanhKem"].ToString();
            txtMoTa.Text = dt.Rows[0]["moTa"].ToString();

            img = dt.Rows[0]["hinhAnhBK"].ToString();

            if (img == string.Empty)
            {
                img = "product.png";
            }
            var imageMS = new MemoryStream(webservice.get_imageFile(img));

            Image imageFS = Image.FromStream(imageMS);

            pic_AnhSP.Image = imageFS;

            iDSP = idBanhKem;
        }


        private void btn_trolai_Click(object sender, EventArgs e)
        {
            this.Hide();
           // MaskedDialog.ShowDialog(frm_SanPham.getForm, this);
           // MaskedDialog.ShowDialog(this, frm_SanPham.getForm);
        }

        public static byte[] ImageToByte(Image img)
        {
            byte[] byteArray = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, (System.Drawing.Imaging.ImageFormat.Png));
                stream.Close();

                byteArray = stream.ToArray();
            }
            return byteArray;
        }


        byte[] imgBytes = new byte[0];
        string name;
        private void pic_AnhSP_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog f = new OpenFileDialog();
            ImageConverter converter = new ImageConverter();
            if (f.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(f.FileName);
                //imgBytes = ImageToByte(img);
                pic_AnhSP.Image = img;
                name = Path.GetFileName(f.FileName);
                //imgBytes = (byte[])converter.ConvertTo(img, typeof(byte[]));
            }
            
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (txtTenBanh.Text == "")
            {
                MessageBox.Show("Tên sản phẩm chưa có giá trị!");
            }
            if (txtGia.Text == "")
            {
                MessageBox.Show("Giá sản phẩm chưa có giá trị!");
            }
            else
            {
                int giatien = int.Parse(txtGia.Text.ToString());
                string mota = txtMoTa.Text;
                string tenbanhkem = txtTenBanh.Text;
                string hinhanh = name;
                int masize = int.Parse(cb_Size.SelectedValue.ToString());
                int gia = int.Parse(txtGia.Text.ToString());
                imgBytes = ImageToByte(pic_AnhSP.Image);
                int maloai = int.Parse(cb_TenTheLoai.SelectedValue.ToString());
                int magiamgia = int.Parse(cb_GiamGia.SelectedValue.ToString());
                webservice.UploadFile(imgBytes, name);
                webservice.InsertSanPham(tenbanhkem, hinhanh, mota, maloai, magiamgia);
                int mabk = webservice.getMaxIdBanhKem();
                webservice.InsertMaSizeBanh(mabk, masize, gia);
                //webservice.InsertMaSizeBanh(
                MessageBox.Show("Thêm thành công");
            }
            even_LoadSanPham();
        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            string mota = txtMoTa.Text;
            string tenbanhkem = txtTenBanh.Text;
            string hinhanh = name;
            int masize = int.Parse(cb_Size.SelectedValue.ToString());
            int gia = int.Parse(txtGia.Text.ToString());
            imgBytes = ImageToByte(pic_AnhSP.Image);
            int maloai = int.Parse(cb_TenTheLoai.SelectedValue.ToString());
            int maGG = int.Parse(cb_GiamGia.SelectedValue.ToString());
            int magiamgia = int.Parse(cb_GiamGia.SelectedValue.ToString());

            webservice.UploadFile(imgBytes, name);

            webservice.UpdateSanPham(iDSP, hinhanh, tenbanhkem, maloai, maGG, mota);
            webservice.UpdateSizeSanPhamDangChon(iDMSB, masize, gia);

            MessageBox.Show("Cập nhật ok ");

            event_loadContentRightSanPham();

        }
    }
}
