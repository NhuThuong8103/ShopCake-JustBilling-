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
    public partial class TTBK : UserControl
    {
        ServiceReference.WebServiceSoapClient webservice = new ServiceReference.WebServiceSoapClient();

        public event EventHandler<EventArgs> WasClicked;

        public TTBK()
        {
            InitializeComponent();
        }

        private void TTBK_Load(object sender, EventArgs e)
        {
            this.Tag = maBanh;
           

            if (hinhAnhBK == string.Empty)
            {
                hinhAnhBK = "product.png";
            }
            var imageMS = new MemoryStream(webservice.get_imageFile(hinhAnhBK));

            Image imageFS = Image.FromStream(imageMS);

            anhsp.Image = imageFS;

            lb_TenBanhKemVaSize.Text = this.tenBK;

            lb_TenSize.Text = this.tenSize;

            lb_LoaiBanhKem.Text = this.ngaySX.ToShortDateString();

            lbmaBTN.Text = this.maBanh.ToString();

            this.MouseClick += Control_MouseClick;

            foreach (Control control in Controls)
            {
                control.MouseClick += Control_MouseClick;
            }
        }

        private string hinhAnhBK;
        private string tenBK;
        private string tenSize;
        private DateTime ngaySX;
        private int maBanh;
        


        public int MaBanh
        {
            get { return maBanh; }
            set { maBanh = value; }
        }

        public string HinhAnhBK
        {
            get { return hinhAnhBK; }
            set { hinhAnhBK = value; }
        }

        public string TenBK
        {
            get { return tenBK; }
            set { tenBK = value; lb_TenBanhKemVaSize.Text = value; }
        }

        public string TenSize
        {
            get { return tenSize; }
            set { tenSize = value; lb_TenBanhKemVaSize.Text += value; }
        }

        public DateTime NgaySX
        {
            get { return ngaySX; }
            set { ngaySX = value; lb_LoaiBanhKem.Text = value.ToString(); }
        }


        private void Control_MouseClick(object sender, MouseEventArgs e)
        {
            //var wasClicked = WasClicked;
            if (WasClicked != null)
            {
                WasClicked(this, EventArgs.Empty);
            }
            IsSelected = true;

        }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                string recyle_white = "recycle_wh.png";
                string recycle_black = "recycle_bl.png";

                var recycle_W = new MemoryStream(webservice.get_imageFile(recyle_white));
                var recycle_B = new MemoryStream(webservice.get_imageFile(recycle_black));
                Image imageFS_W = Image.FromStream(recycle_W);
                Image imageFS_B = Image.FromStream(recycle_B);

                if (this.IsSelected)
                {
                    this.BackColor = Color.Gray;
                    lb_LoaiBanhKem.ForeColor = Color.White;
                    lb_TenBanhKemVaSize.ForeColor = Color.White;
                    btn_Xoa.Image = imageFS_W;
                    btn_Xoa.BackColor = Color.Gray;
                    lb_TenSize.ForeColor = Color.White;
                }
                else
                {
                    this.BackColor = Color.White;
                    lb_LoaiBanhKem.ForeColor = Color.Black;
                    lb_TenBanhKemVaSize.ForeColor = Color.Black;
                    btn_Xoa.Image = imageFS_B;
                    btn_Xoa.BackColor = Color.White;
                    lb_TenSize.ForeColor = Color.Black;
                }
            }
        }

        //private void btn_Xoa_Click(object sender, EventArgs e)
        //{
           
        //}
    }
}
