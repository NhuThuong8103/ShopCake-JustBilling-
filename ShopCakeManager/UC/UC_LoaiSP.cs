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

namespace ShopCakeManager.UC
{
    public partial class UC_LoaiSP : UserControl
    {
        ServiceReference.WebServiceSoapClient webservice = new ServiceReference.WebServiceSoapClient();

        public event EventHandler<EventArgs> ClickLoaiSP;

        private bool _isSelected;

        public UC_LoaiSP()
        {
            InitializeComponent();
        }
        private string tenLoai;
        public int maLoai;
        public string hinhAnhBanhKem;

        public string TenLoai { get { return tenLoai; } set { tenLoai = value; lb_TenLoai.Text = value; } }
        public int MaLoai { get { return maLoai; } set { maLoai = value; } }
        public string HinhAnhBanhKem { get { return hinhAnhBanhKem; } set { hinhAnhBanhKem = value; } }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;

                if (this.IsSelected)
                {
                    this.BackColor = Color.Gray;
                    lb_TenLoai.ForeColor = Color.White;
                }
                else
                {
                    this.BackColor = Color.White;
                    lb_TenLoai.ForeColor = Color.Black;
                }
            }
        }

        private void load_UCLoaiSP()
        {
            this.Tag = maLoai;

            if (hinhAnhBanhKem == string.Empty)
            {
                hinhAnhBanhKem = "product.png";
            }
            var imageMS = new MemoryStream(webservice.get_imageFile(hinhAnhBanhKem));

            Image imageFS = Image.FromStream(imageMS);

            anhsp.Image = imageFS;

            lb_TenLoai.Text = this.tenLoai;

            this.MouseClick += Control_MouseClick;

            foreach (Control control in Controls)
            {
                control.MouseClick += Control_MouseClick;
            }
        }

        void Control_MouseClick(object sender, MouseEventArgs e)
        {
            if (ClickLoaiSP != null)
            {
                ClickLoaiSP(this, EventArgs.Empty);
            }
            IsSelected = true;
        }

        private void UC_ListLoaiSP_Load(object sender, EventArgs e)
        {
            this.Tag = maLoai;

            if (hinhAnhBanhKem == string.Empty)
            {
                hinhAnhBanhKem = "product.png";
            }
            var imageMS = new MemoryStream(webservice.get_imageFile(hinhAnhBanhKem));

            Image imageFS = Image.FromStream(imageMS);

            anhsp.Image = imageFS;

            lb_TenLoai.Text = this.tenLoai;

            this.MouseClick += Control_MouseClick;

            foreach (Control control in Controls)
            {
                control.MouseClick += Control_MouseClick;
            }
        }


    }
}
