using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopCakeManager
{
    public partial class frm_QuanLy : Form
    {
        private static frm_QuanLy inst;

        public frm_QuanLy()
        {
            InitializeComponent();
        }

        public static frm_QuanLy getForm
        {
            get
            {
                if (inst == null || inst.IsDisposed)
                {
                    inst = new frm_QuanLy();
                }
                return inst;
            }
        }

        private void btn_SanPhamTrongNgay_Click(object sender, EventArgs e)
        {
            //MaskedDialog.ShowDialog(this,frm_BanhTrongNgay.getFrom);
            frm_BanhTrongNgay.getFrom.Show();
        }

        private void btn_HuyBanhHetHan_Click(object sender, EventArgs e)
        {
            MaskedDialog.ShowDialog(this,frm_CheckBanhHetHan.getFrom);
        }

        private void btn_SanPham_Click(object sender, EventArgs e)
        {
           // MaskedDialog.ShowDialog(this,frm_SanPham.getForm);
            frm_SanPham.getForm.Show();
        }

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_GiamGia_Click(object sender, EventArgs e)
        {
            frm_GiamGia.getForm.Show();
        }

        private void btn_LoaiSanPham_Click(object sender, EventArgs e)
        {
            frm_TheLoaiSanPham.getForm.Show();
        }
    }
}
