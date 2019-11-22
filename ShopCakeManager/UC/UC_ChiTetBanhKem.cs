using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ShopCakeManager
{
    public partial class UC_ChiTetBanhKem : UserControl
    {
        ServiceReference.WebServiceSoapClient webservice = new ServiceReference.WebServiceSoapClient();

        public UC_ChiTetBanhKem()
        {
            InitializeComponent();
        }

        private string hinhAnhBK;

        private string tenBK;

        private string tenTheLoai;

        private string tenSize;

        private string moTa;

        private string tenGiamGia;

        private DateTime ngaySX;

        private DateTime ngayHetHan;

        private int soLuong;

        private int donGia;

        private int maBK;

        private int maSB;

        //private int maSize;

        //private var img;

    #region 
        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; lb_SoLuong.Text = value.ToString(); }
        }

       

        public int MaSB
        {
            get { return maSB; }
            set { maSB = value; idSB.Text = value.ToString(); }
        }

        public int DonGia
        {
            get { return donGia; }
            set { donGia = value; lb_Gia.Text = value.ToString(); }
        }
        public int MaBK
        {
            get { return maBK; }
            set { maBK = value; /*lb_TenBanhKem.Text += value.ToString();*/}
        }

        public string HinhAnhBK
        {
            get { return hinhAnhBK; }
            set { hinhAnhBK = value; }
        }

        public string TenBK
        {
            get { return tenBK; }
            set { tenBK = value; lb_TenBanhKem.Text = value; }
        }
        public string TenTheLoai
        {
            get { return tenTheLoai; }
            set { tenTheLoai = value; lb_TenTheLoai.Text = value; }
        }
        public string TenSize
        {
            get { return tenSize; }
            set { tenSize = value; lb_TenSize.Text = value; }
        }
        public string MoTa
        {
            get { return moTa; }
            set { moTa = value; txt_MoTa.Text = value; }
        }
        public string TenGiamGia
        {
            get { return tenGiamGia; }
            set { tenGiamGia = value; lb_GiamGia.Text = value; }
        }

        public DateTime NgaySX
        {
            get { return ngaySX; }
            set { ngaySX = value; lb_NgaySX.Text = value.ToString("dd/MM/yyyy HH:mm:ss tt"); }
        }

        public DateTime NgayHetHan
        {
            get { return ngayHetHan; }
            set { ngayHetHan = value; lb_NgayHetHan.Text = value.ToString("dd/MM/yyyy HH:mm:ss tt"); }
        }
    #endregion // get set

        private void UC_ChiTetBanhKem_Load(object sender, EventArgs e)
        {
            this.Tag = maSB;

            if (hinhAnhBK == string.Empty)
            {
                hinhAnhBK = "product.png";
            }
            var imageMS = new MemoryStream(webservice.get_imageFile(hinhAnhBK));

            Image imageFS = Image.FromStream(imageMS);

            anhSanPhamChiTiet.Image = imageFS;

            lb_TenBanhKem.Text = this.tenBK;
            lb_TenSize.Text = this.tenSize;
            lb_TenTheLoai.Text = this.tenTheLoai;
            lb_SoLuong.Text = this.soLuong.ToString();
            lb_NgaySX.Text = this.ngaySX.ToString();
            lb_NgayHetHan.Text = this.ngayHetHan.ToString();
            
            lb_GiamGia.Text = this.tenGiamGia;
            lb_Gia.Text = this.donGia.ToString();
            txt_MoTa.Text = this.moTa;
           // idSize.Text = this.maSize.ToString();
            //idSB.Text = this.MaSB.ToString();
        }

        private void txt_MoTa_MouseHover(object sender, EventArgs e)
        {
           // txt_MoTa.BorderStyle = Color.Blue;
        }
    }
}
