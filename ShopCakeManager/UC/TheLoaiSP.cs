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
    public partial class TheLoaiSP : UserControl
    {
        ServiceReference.WebServiceSoapClient service = new ServiceReference.WebServiceSoapClient();

        public string matheloai;

        public string tentheloai;

        public string anhtheloai;

        public event EventHandler TLSP_Click; // tạo event click truyền đến form bán hàng

        public TheLoaiSP()
        {
            InitializeComponent();
        }

        //public TheLoaiSP(string matheloai, string tentheloai, string anhtheloai)
        //{
        //    this.matheloai = matheloai;

        //    this.tentheloai = tentheloai;

        //    this.anhtheloai = anhtheloai;
        //}
        private void TheLoaiSP_Load(object sender, EventArgs e)
        {
            this.Tag = matheloai;
            lb_tentheloai.Text = tentheloai;
            if(anhtheloai==String.Empty){
                anhtheloai = "product.png";
            }

            var imageMS = new MemoryStream(service.get_imageFile(anhtheloai));

            Image imageFS = Image.FromStream(imageMS);

            img_theloai.Image = imageFS;
            //img_theloai.Image = Image.FromFile(Path.GetFullPath(Path.Combine(Application.StartupPath, "..\\..")) + @"..\anhSP\" + anhtheloai);

        }

        private void img_theloai_Click(object sender, EventArgs e)
        {
            if(this.TLSP_Click!=null){
                this.TLSP_Click(this,e);
            }
        }
    }
}
