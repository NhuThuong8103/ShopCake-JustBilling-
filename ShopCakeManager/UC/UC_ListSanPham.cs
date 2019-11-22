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
    public partial class UC_ListSanPham : UserControl
    {
        ServiceReference.WebServiceSoapClient webservice = new ServiceReference.WebServiceSoapClient();

        public event EventHandler<EventArgs> ClickSanPham;

        private bool _isSelected;

        public UC_ListSanPham()
        {
            InitializeComponent();
        }

        private string tenBanhKem;
        private string tenLoai;
        private string hinhAnhBanhKem;
        private int maBK;

        public string TenBanhKem { get { return tenBanhKem; } set { tenBanhKem = value; lb_TenBanhKem.Text = value; } }
        public string TenLoai { get { return tenLoai; } set { tenLoai = value; lb_Loai.Text = value; } }
        public string HinhAnhBanhKem { get { return hinhAnhBanhKem; } set { hinhAnhBanhKem = value; hinhAnhBanhKem = value; } }
        public int MaBK { get { return maBK; } set { maBK = value; } }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;

                if (this.IsSelected)
                {
                    this.BackColor = Color.Gray;
                    lb_TenBanhKem.ForeColor = Color.White;
                    lb_Loai.ForeColor = Color.White;
                }
                else
                {
                    this.BackColor = Color.White;
                    lb_TenBanhKem.ForeColor = Color.Black;
                    lb_Loai.ForeColor = Color.Black;
                }
            }
        }

        private void load_UCListSanPham()
        {
            this.Tag = maBK;

            if (hinhAnhBanhKem == string.Empty)
            {
                hinhAnhBanhKem = "product.png";
            }
            var imageMS = new MemoryStream(webservice.get_imageFile(hinhAnhBanhKem));

            Image imageFS = Image.FromStream(imageMS);

            anhsp.Image = imageFS;

            lb_TenBanhKem.Text = this.tenBanhKem;

            lb_Loai.Text = this.tenLoai;

            this.MouseClick += Control_MouseClick;

            foreach (Control control in Controls)
            {
                control.MouseClick += Control_MouseClick;
            }
        }

        void Control_MouseClick(object sender, MouseEventArgs e)
        {
            if (ClickSanPham != null)
            {
                ClickSanPham(this, EventArgs.Empty);
            }
            IsSelected = true;
        }

        private void UC_ListSanPham_Load(object sender, EventArgs e)
        {
            //load_UCListSanPham();
            this.Tag = maBK;

            if (hinhAnhBanhKem == string.Empty)
            {
                hinhAnhBanhKem = "product.png";
            }
            var imageMS = new MemoryStream(webservice.get_imageFile(hinhAnhBanhKem));

            Image imageFS = Image.FromStream(imageMS);

            anhsp.Image = imageFS;

            lb_TenBanhKem.Text = this.tenBanhKem;

            lb_Loai.Text = this.tenLoai;

            this.MouseClick += Control_MouseClick;

            foreach (Control control in Controls)
            {
                control.MouseClick += Control_MouseClick;
            }
        }

        
        
        
    }
}
