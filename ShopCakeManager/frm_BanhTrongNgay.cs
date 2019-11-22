using ShopCakeManager.UC;
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
    public partial class frm_BanhTrongNgay : Form
    {
        private static frm_BanhTrongNgay inst;

        ConvertDataTable convert = new ConvertDataTable();

        DataTable dt = new DataTable();

        ServiceReference.WebServiceSoapClient webservice = new ServiceReference.WebServiceSoapClient();

        TTBK uc_ListBK;

        UC_ChiTetBanhKem uc_CTBK;

        int maBanhTN;
        int local;

        public delegate void delagate_CapNhatBanhTrongNgay(int idBNT);
        public static event delagate_CapNhatBanhTrongNgay event_CapNhatBTN;

        public delegate void delegate_clickChucNang(int id);
        public static event delegate_clickChucNang event_ClickChucNang;

        


        List<TTBK> lis = new List<TTBK>();
        public int mabanhdangchon;

        public frm_BanhTrongNgay()
        {
            InitializeComponent();
        }

        public static frm_BanhTrongNgay getFrom
        {
            get
            {
                if (inst == null || inst.IsDisposed)
                {
                    inst = new frm_BanhTrongNgay();
                }
                return inst;
            }
        }
        public void frm_BanhTrongNgay_Load(object sender, EventArgs e)
        {
            load_UC_BanhTrongNgay();
        }


        void load_UC_BanhTrongNgay()
        {
            dt = convert.ToDataTable(webservice.get_ListDanhSachBanhTrongNgay());

            foreach (DataRow item in dt.Rows)
            {
                uc_ListBK = new TTBK();

                uc_ListBK.MaBanh = Int32.Parse(item["maBanhTrongNgay"].ToString());

                uc_ListBK.HinhAnhBK = item["hinhAnh"].ToString();

                uc_ListBK.TenBK = item["tenBanh"].ToString();

                uc_ListBK.TenSize = item["tenSize"].ToString();

                uc_ListBK.NgaySX = DateTime.Parse(item["ngaySX"].ToString());

                uc_ListBK.WasClicked += UsersGrid_WasClicked;

                uc_ListBK.Dock = DockStyle.Top;

                fl_listBanh.Controls.Add(uc_ListBK);

                lis.Add(uc_ListBK);
            }

            for (int i = 0; i < dt.Rows.Count; i++) // cho chọn mặc định UC đầu tiên.
            {
                lis[0].IsSelected = true;

                maBanhTN = lis[0].MaBanh;
            }

            load_PanelRight(maBanhTN);
            //mabanhtrongngay = maBanhTN;
        }


        int getMaBanhTrongNgayDuocChon()
        {
            dt = convert.ToDataTable(webservice.get_ListDanhSachBanhTrongNgay());

            for (int i = 0; i < dt.Rows.Count; i++) 
            {
                lis[0].IsSelected = true;

                maBanhTN = lis[0].MaBanh;
            }
            return maBanhTN; // lấy mã bánh trong ngày
        }

        void load_PanelRight(int maBanhDuocChon)
        {
            PN_Right.Controls.Clear();

            dt = convert.ToDataTable(webservice.get_ThongTinChiTietBanhTrongNgay(maBanhDuocChon));

            uc_CTBK = new UC_ChiTetBanhKem();

            uc_CTBK.HinhAnhBK = dt.Rows[0]["hinhAnhBK"].ToString();

            uc_CTBK.TenBK = dt.Rows[0]["tenBK"].ToString() + " (Mã Bánh: " + Int32.Parse(dt.Rows[0]["maBK"].ToString()) + ")";

            uc_CTBK.TenTheLoai = dt.Rows[0]["tenTheLoai"].ToString();

            uc_CTBK.TenSize = dt.Rows[0]["tenSize"].ToString();

            uc_CTBK.NgaySX = DateTime.Parse(dt.Rows[0]["ngaySX"].ToString());

            uc_CTBK.NgayHetHan = DateTime.Parse(dt.Rows[0]["ngayHetHan"].ToString());

            uc_CTBK.SoLuong = Int32.Parse(dt.Rows[0]["soLuong"].ToString());

            uc_CTBK.DonGia = Int32.Parse(dt.Rows[0]["donGia"].ToString());

            uc_CTBK.TenGiamGia = dt.Rows[0]["tenGiamGia"].ToString();

            uc_CTBK.MoTa = dt.Rows[0]["moTa"].ToString();

            PN_Right.Controls.Add(uc_CTBK);
        }

        // hàm để sét người dùng đang click vào UC
        void UsersGrid_WasClicked(object sender, EventArgs e)
        {
            // Set IsSelected for all UCs in the FlowLayoutPanel to false. 
            foreach (Control c in fl_listBanh.Controls)
            {
                if (c is TTBK)
                {
                    ((TTBK)c).IsSelected = false;
                }
            }
            load_PanelRight( Int32.Parse((sender as TTBK).Tag.ToString()));
            mabanhdangchon = Int32.Parse((sender as TTBK).Tag.ToString());
           // MessageBox.Show(mabanhdangchon.ToString());
        }


      

        private void btn_ThemSP_Click(object sender, EventArgs e)
        {
            frm_ThemBanhTrongNgay.event_LoadBanhTrongNgay += frm_ThemBanhTrongNgay_event_LoadBanhTrongNgay;
            frm_ThemBanhTrongNgay.getForm.Show();
           // MaskedDialog.ShowDialog(frm_QuanLy.getForm, frm_ThemBanhTrongNgay.getForm);
            local = 1;
            event_ClickChucNang(local);
        }

        void frm_ThemBanhTrongNgay_event_LoadBanhTrongNgay()
        {
            fl_listBanh.Controls.Clear();
            load_UC_BanhTrongNgay();

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            if (kiemTraSuaBanhTrongNgay(mabanhdangchon)==false)
            {
                frm_ThemBanhTrongNgay.getForm.Show();
                local = 2;
                event_ClickChucNang(local);
                event_CapNhatBTN(mabanhdangchon);

                frm_ThemBanhTrongNgay.event_loadPanelRight += frm_ThemBanhTrongNgay_event_loadPanelRight;
                
            }
            else
            {
                MessageBox.Show("Chỉ được cập nhật Sản phẩm nhập vào hôm nay","Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        void frm_ThemBanhTrongNgay_event_loadPanelRight()
        {
            load_PanelRight(mabanhdangchon);
        }

        private bool kiemTraSuaBanhTrongNgay(int maBTN) // kiểm tra mã bánh đó phải là mã bánh nhập ngày hôm nay, nếu ko thì ko cho sửa
        {
            dt = convert.ToDataTable(webservice.get_ListBanhNhapTrongNgay());
            // dt = convert.ToDataTable(webservice.get_ListBanhNhapTrongNgay);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (maBTN == int.Parse(dt.Rows[i]["idBTN"].ToString()))
                {
                    return false;
                }
            }
            return true;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa bánh " + mabanhdangchon.ToString() + " không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                webservice.set_TinhTrangBanhTrongNgay(mabanhdangchon);
                fl_listBanh.Controls.Clear();
                load_UC_BanhTrongNgay();
            }
            else
            {
            }
        }



        
    }
}
