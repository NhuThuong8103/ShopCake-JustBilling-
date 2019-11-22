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
    public partial class frm_ThemBanhTrongNgay : Form
    {
        private static frm_ThemBanhTrongNgay inst;

        ServiceReference.WebServiceSoapClient webservice = new ServiceReference.WebServiceSoapClient();

        ConvertDataTable convert = new ConvertDataTable();

        DataTable dt;

        public delegate void delegate_LoadBanhTrongNgay();
        public static event delegate_LoadBanhTrongNgay event_LoadBanhTrongNgay;

        public delegate void delegate_loadPanelRight();
        public static event delegate_loadPanelRight event_loadPanelRight;

        public DateTime update_ngayHH;
        public int update_soluong;
        public int idbtn;
        public string img;

        public frm_ThemBanhTrongNgay()
        {
            InitializeComponent();
        }



        public static frm_ThemBanhTrongNgay getForm
        {
            get
            {
                if (inst == null || inst.IsDisposed)
                    inst = new frm_ThemBanhTrongNgay();
                return inst;
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
          
            this.Hide();
            //frm_BanhTrongNgay.frm_BanhTrongNgay_Load(sender, e);

        }

        void load_CB_BanhKem()
        {
            dt = new DataTable();

            dt = convert.ToDataTable(webservice.get_ListTenBanhKem());

            cb_TenBanhKem.DataSource = dt;

            cb_TenBanhKem.DisplayMember = "tenBanhKem";

            cb_TenBanhKem.ValueMember = "maBanhKem";

            cb_TenBanhKem.SelectedIndex = 0;
        }

        private void frm_ThemBanhTrongNgay_Load(object sender, EventArgs e)
        {
            frm_BanhTrongNgay.event_ClickChucNang += frm_BanhTrongNgay_event_ClickChucNang;
        }

        void frm_BanhTrongNgay_event_ClickChucNang(int id)
        {
            if (id == 1)
            {
                load_CB_BanhKem();
                btn_CapNhat.Visible = false;
                bunifuFlatButton2.Visible = true; // btn lưu
                cb_TenSize.Enabled = true;
                cb_TenBanhKem.Enabled = true;
            }
            else
            {
                btn_CapNhat.Visible = true;
                bunifuFlatButton2.Visible = false;
                btn_CapNhat.Location = new Point(641, 523);
                cb_TenSize.Enabled = false;
                cb_TenBanhKem.Enabled = false;

                frm_BanhTrongNgay.event_CapNhatBTN +=frm_BanhTrongNgay_event_CapNhatBTN;
            }

        }

        void frm_BanhTrongNgay_event_CapNhatBTN(int idBTN)
        {
            load_TTBanhKemUpdate(idBTN);

        }

        void load_TTBanhKemUpdate(int maBTN)
        {
            dt = new DataTable();
            cb_TenSize.Text = "";
            cb_TenBanhKem.Text = "";
            dt = convert.ToDataTable(webservice.get_ThongTinBanhKemUpdate(maBTN));
            cb_TenBanhKem.SelectedText = dt.Rows[0]["tenBK"].ToString();
            cb_TenSize.SelectedText = dt.Rows[0]["tenSize"].ToString();
            txt_SoLuong.Text = dt.Rows[0]["soLuong"].ToString();
            dtpk_NgayHetHan.Value = DateTime.Parse(dt.Rows[0]["ngayHetHan"].ToString());

            img = dt.Rows[0]["hinhAnhBK"].ToString();

            if (img == string.Empty)
            {
                img = "product.png";
            }
            var imageMS = new MemoryStream(webservice.get_imageFile(img));

            Image imageFS = Image.FromStream(imageMS);

            pic_AnhSP.Image = imageFS;

            idbtn = maBTN;
        }





        int lay_MaSizeBanh()
        {
            var bk = cb_TenBanhKem.SelectedValue;
            var s = cb_TenSize.SelectedValue;
            DataRowView da = (DataRowView)cb_TenBanhKem.SelectedItem;
            DataRowView da1 = (DataRowView)cb_TenSize.SelectedItem;

            int maSB;

            if (da != null && da1 != null)
            {
                maSB = webservice.get_MaSizeBanh((int.Parse(da[1].ToString())), (int.Parse(da1[1].ToString())));
                return maSB;
            }
            return -1;
        }

        public void ThemBanhTrongNgay()
        {
            int masb = lay_MaSizeBanh();

            if (webservice.check_BanhDaInsertTrongNgay(masb) == false)
            {
                MessageBox.Show("Sản phẩm đã có trong danh mục bánh trong ngày của ngày hơm nay!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                int sluong = int.Parse(txt_SoLuong.Text.ToString());
                DateTime ngayHH = dtpk_NgayHetHan.Value;
                int maBK = int.Parse(cb_TenBanhKem.SelectedValue.ToString());
                int maSize = int.Parse(cb_TenSize.SelectedValue.ToString());
                if (masb == -1)
                {
                    MessageBox.Show("Mã size bánh = -1");
                }
                else
                {
                    webservice.Insert_BanhTrongNgay(masb, sluong, DateTime.Now, ngayHH);
                    MessageBox.Show("Thêm ok! KT CSDL");
                }
            }         
            
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            ThemBanhTrongNgay();
            event_LoadBanhTrongNgay();
        }

        private void cb_TenBanhKem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var s = cb_TenBanhKem.SelectedValue;

            DataRowView da = (DataRowView)cb_TenBanhKem.SelectedItem;

            if (da != null)
            {
                dt = new DataTable();
                dt = convert.ToDataTable(webservice.get_SizeTheoBanhKem((int.Parse(da[1].ToString()))));
                cb_TenSize.DataSource = dt;
                cb_TenSize.DisplayMember = "tenSize";
                cb_TenSize.ValueMember = "maSize";
                cb_TenSize.SelectedIndex = 0;

            }
        }

        private void cb_TenSize_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            update_ngayHH = dtpk_NgayHetHan.Value;
            update_soluong = int.Parse(txt_SoLuong.Text.ToString());
            webservice.set_TTCapNhatBanhTrongNgay(idbtn, update_ngayHH, update_soluong);
            MessageBox.Show("Cập nhật thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            event_loadPanelRight();
        }

       
    }
}
