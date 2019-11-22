using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopCakeManager
{
    public partial class CTHD : UserControl
    {
        public string mabanhtrongngay;

        public int soluong;

        public string ten;

        public int gia;

        public string giamgia;

        public event EventHandler Xoa_CTHD;

        public double thanhtien = 0;
        public CTHD()
        {
            InitializeComponent();
        }

        private void CTHD_Load(object sender, EventArgs e)
        {
            this.Tag = this.mabanhtrongngay;

            lb_soluong.Text = this.soluong.ToString();

            lb_tenbanh.Text = this.ten;

            if (this.giamgia.ToString().Equals("0"))
            {
                lb_gia.Text = this.gia.ToString();
            }
            else
                lb_gia.Text = this.gia.ToString()+"(-"+this.giamgia+"%)";
            
            thanhtien=((this.gia - ((double)(this.gia * Int32.Parse(this.giamgia)) / 100)) * this.soluong);

            lb_thanhtien.Text = thanhtien.ToString();

            frm_BanHang.tongtienHD += double.Parse(lb_thanhtien.Text);
        }

        private void imgXoa_Click(object sender, EventArgs e)
        {
            if(this.Xoa_CTHD!=null){
                this.Xoa_CTHD(this,e);
                //this.Visible = true;
            }
        }
    }
}
