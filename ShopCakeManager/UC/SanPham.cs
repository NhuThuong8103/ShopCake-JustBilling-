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
    public partial class SanPham : UserControl
    {
        ServiceReference.WebServiceSoapClient service = new ServiceReference.WebServiceSoapClient();

        public string anhsp;

        public string maBanhTrongNgay;

        public string ten;

        public int gia;

        public string giamgia;

        public event EventHandler SP_Click; // tạo event click truyền đến form bán hàng

        public SanPham()
        {
            InitializeComponent();
        }

        private void SanPham_Load(object sender, EventArgs e)
        {
            if (anhsp == String.Empty)
            {
                anhsp = "product.png";
            }

            var imageMS = new MemoryStream(service.get_imageFile(anhsp));

            Image imageFS = Image.FromStream(imageMS);

            img_sp.Image = imageFS;
            //img_sp.Image = Image.FromFile(Path.GetFullPath(Path.Combine(Application.StartupPath, "..\\..")) + @"..\anhSP\" + anhsp);

            this.Tag = maBanhTrongNgay;

            lb_ten.Text = ten;

            lb_gia.Text = gia.ToString();

            if (giamgia.Equals("0"))
                lb_giamgia.Text = "";
            else
                lb_giamgia.Text = "-"+ giamgia.ToString()+"%";
        }

        private void img_sp_Click(object sender, EventArgs e)
        {
            if(this.SP_Click != null){
                this.SP_Click(this,e);
            }
        }
    }
}
