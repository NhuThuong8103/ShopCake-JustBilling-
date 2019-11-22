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
    public partial class frm_BanHang : Form
    {
        private static frm_BanHang inst;

        DataTable dt;

        ConvertDataTable c;

        public static double tongtienHD = 0;

        List<Tuple<string, int>> CTHDList = new List<Tuple<string, int>>(); // list CTHD chứa mã bánh trong ngày và số lượng

        int selectIndex = -1;

        ServiceReference.WebServiceSoapClient webservice = new ServiceReference.WebServiceSoapClient();

        public frm_BanHang()
        {
            InitializeComponent();

            loadTheLoaiBanh();

            lb_username.Text = webservice.get_username(frm_DangNhap.IDNV);
        }

        public static frm_BanHang getForm
        {
            get
            {
                if (inst == null || inst.IsDisposed)
                    inst = new frm_BanHang();
                return inst;
            }
        }

        #region // load danh sách thể loại bánh -- bánh
        public void loadTheLoaiBanh()
        {
            dt = new DataTable();

            c = new ConvertDataTable();

            dt = c.ToDataTable(webservice.get_ListTheLoaiBanh());

            foreach (DataRow item in dt.Rows)
            {
                TheLoaiSP tl = new TheLoaiSP();

                tl.matheloai = item["MaLoai"].ToString();

                tl.tentheloai = item["TenLoai"].ToString();

                tl.anhtheloai = item["HinhAnhLoai"].ToString();
                //(item["MaLoai"].ToString(),item["TenLoai"].ToString(),item["HinhAnhLoai"].ToString());

                tl.TLSP_Click += tl_TLSP_Click;

                fl_theloai.Controls.Add(tl);
            }
        }

        public void loadDSBanhKemTrongNgay()
        {
            selectIndex = cbx_phuongthuc.SelectedIndex;

            fl_sanpham.Controls.Clear();

            dt = new DataTable();

            c = new ConvertDataTable();

            dt = c.ToDataTable(webservice.get_ListBanhTrongNgay());

            SanPham sp = null;

            foreach (DataRow item in dt.Rows)
            {
                sp = new SanPham();

                sp.maBanhTrongNgay = item["maBanhTrongNgay"].ToString();

                sp.anhsp = item["anhSP"].ToString();

                sp.ten = item["tenSP"].ToString() +" ("+item["tenSizeSP"].ToString()+")";

                sp.gia =Int32.Parse(item["giaSP"].ToString());

                sp.giamgia = item["giamgia"].ToString();

                sp.SP_Click += sp_SP_Click;

                fl_sanpham.Controls.Add(sp);
            }
        }

        public void loadDSBanhKem()
        {
            selectIndex = cbx_phuongthuc.SelectedIndex;            

            fl_sanpham.Controls.Clear();

            dt = new DataTable();

            c = new ConvertDataTable();

            dt = c.ToDataTable(webservice.get_ListBanhKem());

            SanPham sp = null;

            foreach (DataRow item in dt.Rows)
            {
                sp = new SanPham();

                sp.maBanhTrongNgay = item["maSizeBanh"].ToString();

                sp.anhsp = item["anhBanhKem"].ToString();

                sp.ten = item["tenBanhKem"].ToString() + " (" + item["tenSizeBanhKem"].ToString() + ")";

                sp.gia = Int32.Parse(item["giaBanhKem"].ToString());

                sp.giamgia = item["giamgiaBanhKem"].ToString();

                sp.SP_Click += sp_SP_Click;

                fl_sanpham.Controls.Add(sp);
            }
        }
        void sp_SP_Click(object sender, EventArgs e) // click sản phẩm để thêm cthd   
        {
            fl_HD.Controls.Clear();
            tongtienHD = 0;
            string ID = (sender as SanPham).Tag.ToString();
            
            //throw new NotImplementedException();

            if (!kTTrungMaBanhCTHD(ID)) // nếu ko có trong CTHD thì  new uc
            {
                CTHDList.Add(Tuple.Create(ID, 1)); // add list chtd gồm mã bánh trong ngày và số lượng là 1
            }
            else
            {
                var index = CTHDList.FindIndex(x=>x.Item1.Equals(ID));

                int sl = CTHDList[index].Item2;

                if (webservice.get_kTraSoLuongBanhTrongNgay(Int32.Parse(ID)) == sl)
                {
                    MessageBox.Show("Đã hết số lượng bánh " + (sender as SanPham).ten + "!!!");
                }
                else
                {
                    CTHDList[index] = Tuple.Create(ID, sl + 1);
                }
            }

            loadCTHD();

            lb_tongtien.Text = tongtienHD.ToString();
        }

        public void loadCTHD()
        {
            if (cbx_phuongthuc.SelectedIndex == 0)
            {
                foreach (var item in CTHDList)
                {
                    CTHD cthditem = new CTHD();

                    dt = new DataTable();

                    dt = c.ToDataTable(webservice.get_ChiTietHD(Int32.Parse(item.Item1)));

                    cthditem.mabanhtrongngay = item.Item1;

                    cthditem.soluong = item.Item2;

                    cthditem.ten = dt.Rows[0]["tenbanhkem"].ToString() + "(" + dt.Rows[0]["tensize"].ToString() + ")";

                    cthditem.gia = Int32.Parse(dt.Rows[0]["gia"].ToString());

                    cthditem.giamgia = dt.Rows[0]["tengiamgia"].ToString();

                    cthditem.Xoa_CTHD += cthditem_Xoa_CTHD;

                    fl_HD.Controls.Add(cthditem);
                }
            }
            else
            {
                foreach (var item in CTHDList)
                {
                    CTHD cthditem = new CTHD();

                    dt = new DataTable();

                    dt = c.ToDataTable(webservice.get_ChiTietPD(Int32.Parse(item.Item1)));

                    cthditem.mabanhtrongngay = item.Item1;

                    cthditem.soluong = item.Item2;

                    cthditem.ten = dt.Rows[0]["tenbanhkem"].ToString() + "(" + dt.Rows[0]["tensize"].ToString() + ")";

                    cthditem.gia = Int32.Parse(dt.Rows[0]["gia"].ToString());

                    cthditem.giamgia = dt.Rows[0]["tengiamgia"].ToString();

                    cthditem.Xoa_CTHD += cthditem_Xoa_CTHD;

                    fl_HD.Controls.Add(cthditem);
                }
            }
        }




        void cthditem_Xoa_CTHD(object sender, EventArgs e)  // =============================== xóa cthd ===================================
        {
            //throw new NotImplementedException();
            (sender as CTHD).Visible = false;

            tongtienHD = tongtienHD-(sender as CTHD).thanhtien;

            lb_tongtien.Text = tongtienHD.ToString();

            var index = CTHDList.FindIndex(x => x.Item1.Equals((sender as CTHD).Tag));

            CTHDList.RemoveAt(index);
        }


        public bool kTTrungMaBanhCTHD(string ma)
        {
            foreach (var item in CTHDList)
            {
                if(item.Item1.Equals(ma))
                    return true;
            }
            return false;
        }

        

        void tl_TLSP_Click(object sender, EventArgs e) // click thể loại sản phẩm để show sản phẩm trong ngày
        {
            //throw new NotImplementedException();
            //frm_Alert.Alert((sender as TheLoaiSP).Tag.ToString(), frm_Alert.AlertType.success);
            fl_sanpham.Controls.Clear();

            if (cbx_phuongthuc.SelectedIndex == 0)
            {

                dt = new DataTable();

                c = new ConvertDataTable();

                dt = c.ToDataTable(webservice.get_ListBanhTrongNgayVsTheLoai(Int32.Parse((sender as TheLoaiSP).Tag.ToString())));

                SanPham sp = null;

                foreach (DataRow item in dt.Rows)
                {
                    sp = new SanPham();

                    sp.maBanhTrongNgay = item["maBanhTrongNgay"].ToString();

                    sp.anhsp = item["anhSP"].ToString();

                    sp.ten = item["tenSP"].ToString() + " (" + item["tenSizeSP"].ToString() + ")";

                    sp.gia = Int32.Parse(item["giaSP"].ToString());

                    sp.giamgia = item["giamgia"].ToString();

                    sp.SP_Click += sp_SP_Click;

                    fl_sanpham.Controls.Add(sp);
                }
            }
            else
            {
                dt = new DataTable();

                c = new ConvertDataTable();

                dt = c.ToDataTable(webservice.get_ListBanhKemvsTheLoai(Int32.Parse((sender as TheLoaiSP).Tag.ToString())));

                SanPham sp = null;

                foreach (DataRow item in dt.Rows)
                {
                    sp = new SanPham();

                    sp.maBanhTrongNgay = item["maSizeBanh"].ToString();

                    sp.anhsp = item["anhBanhKem"].ToString();

                    sp.ten = item["tenBanhKem"].ToString() + " (" + item["tenSizeBanhKem"].ToString() + ")";

                    sp.gia = Int32.Parse(item["giaBanhKem"].ToString());

                    sp.giamgia = item["giamgiaBanhKem"].ToString();

                    sp.SP_Click += sp_SP_Click;

                    fl_sanpham.Controls.Add(sp);
                }
            }
        }
        #endregion
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            frm_DangNhap.w_slide = 490;
            frm_DangNhap.getForm.Show();
            this.Hide();
        }

        private void frm_BanHang_Load(object sender, EventArgs e)
        {
            cbx_phuongthuc.SelectedIndex = 0;

            gettime.Start(); // lấy time

        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            frm_DangNhap.w_slide = 490;
            frm_DangNhap.getForm.Show();
            
            this.Hide();
        }

        private void btnTToan_Click(object sender, EventArgs e)
        {
            //MessageBox.Show((DateTime)DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss").ToString());
           
        }

        private void btnNhapKH_Click(object sender, EventArgs e)
        {
            MaskedDialog.ShowDialog(this,frm_NhapKhachHang.getForm);
            //frm_NhapKhachHang.getForm.Dispose();
        }

        private void btnCanCel_Click(object sender, EventArgs e)
        {
            fl_HD.Controls.Clear();

            CTHDList.Clear();

            tongtienHD = 0;

            lb_tongtien.Text = tongtienHD.ToString();
        }

        private void btnTToan_Click_1(object sender, EventArgs e)
        {
            if (cbx_phuongthuc.SelectedIndex == 0)
            {
                if (CTHDList.Count != 0)
                {
                    int? t = null ;
                    if(frm_NhapKhachHang.tenKH != null || frm_NhapKhachHang.sDTKH != null || frm_NhapKhachHang.diaChiKH != null){
                        webservice.insert_KhachHang(frm_NhapKhachHang.tenKH,frm_NhapKhachHang.sDTKH,frm_NhapKhachHang.diaChiKH);
                        t = webservice.get_MaxMaKhachHang();
                    }
                    else if (frm_NhapKhachHang.maKH == null)
                        t = null;
                    else
                        t = Int32.Parse(frm_NhapKhachHang.maKH.ToString());

                    webservice.insert_HoaDon(frm_DangNhap.IDNV, Int32.Parse(lb_tongtien.Text.ToString()), t,true);

                    int tmp = webservice.get_MAXMaHoaDon();

                    foreach (var item in CTHDList)
                    {
                        int thanhtien = 0;

                        dt = c.ToDataTable(webservice.get_ChiTietHD(Int32.Parse(item.Item1)));

                        //thanhtien = ((dt.Rows[0]["gia"]-(Int32.Parse(dt.Rows[0]["gia"].ToString()) * Int32.Parse(dt.Rows[0]["tengiamgia"].ToString()) / 100) * item.Item2);
                        thanhtien = (Int32.Parse(dt.Rows[0]["gia"].ToString()) - (Int32.Parse(dt.Rows[0]["gia"].ToString()) * Int32.Parse(dt.Rows[0]["tengiamgia"].ToString()) / 100)) * item.Item2;

                        webservice.insert_CTHD(tmp, Int32.Parse(item.Item1.ToString()), item.Item2, thanhtien);

                        webservice.update_soLuongBanhTrongNgaySauThanhToan(Int32.Parse(item.Item1), item.Item2);
                        // mã bánh và số lượng
                    }

                    CTHDList.Clear();
                    fl_HD.Controls.Clear();
                    tongtienHD = 0;
                    lb_tongtien.Text = tongtienHD.ToString();

                    loadDSBanhKemTrongNgay();
                    frm_Alert.Alert("Lập hóa đơn thành công", frm_Alert.AlertType.success);


                }
                else
                {
                    frm_Alert.Alert("Vui lòng chọn SP trước khi TT", frm_Alert.AlertType.warning);
                }
            }
            else
            {
                if (CTHDList.Count != 0)
                {
                    if (DateTime.Parse(frmNote.ngaynhan.ToString("yyyy/MM/dd")) < DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd")))
                    {
                        frm_Alert.Alert("Vui lòng chọn ngày nhận", frm_Alert.AlertType.warning);
                        MaskedDialog.ShowDialog(this, frmNote.getForm);
                        return;

                    }
                    int kt = 0;
                    if ((frm_NhapKhachHang.kt== 1 && frm_NhapKhachHang.maKH == null) || (frm_NhapKhachHang.kt==0 && frm_NhapKhachHang.tenKH == null))
                    {
                        frm_Alert.Alert("Vui lòng nhập TT khách hàng", frm_Alert.AlertType.warning);

                        kt = -1;

                        MaskedDialog.ShowDialog(this, frm_NhapKhachHang.getForm);
                        return;
                    }
                    else
                    {
                        if (frm_NhapKhachHang.maKH != null)
                        {
                            kt = 1;
                        }
                        else
                        {
                            kt = 2;
                        }
                        switch (kt)
                        {
                            case 1:
                                webservice.insert_PhieuDat(frm_DangNhap.IDNV, frmNote.ngaynhan, Int32.Parse(lb_tongtien.Text.ToString()),Int32.Parse(frm_NhapKhachHang.maKH.ToString()),frmNote.note,true);
                                break;
                            case 2:
                                webservice.insert_KhachHang(frm_NhapKhachHang.tenKH,frm_NhapKhachHang.sDTKH,frm_NhapKhachHang.diaChiKH);
                                webservice.insert_PhieuDat(frm_DangNhap.IDNV, frmNote.ngaynhan, Int32.Parse(lb_tongtien.Text.ToString()), webservice.get_MaxMaKhachHang(),frmNote.note,true);
                                int tmp = webservice.get_MAXMaPhieuDat();
                                foreach (var item in CTHDList)
                                {
                                    int thanhtien = 0;

                                    dt = c.ToDataTable(webservice.get_ChiTietPD(Int32.Parse(item.Item1)));

                                    //thanhtien = ((dt.Rows[0]["gia"]-(Int32.Parse(dt.Rows[0]["gia"].ToString()) * Int32.Parse(dt.Rows[0]["tengiamgia"].ToString()) / 100) * item.Item2);
                                    thanhtien = (Int32.Parse(dt.Rows[0]["gia"].ToString()) - (Int32.Parse(dt.Rows[0]["gia"].ToString()) * Int32.Parse(dt.Rows[0]["tengiamgia"].ToString()) / 100)) * item.Item2;

                                    webservice.insert_CTPD(tmp,item.Item2,thanhtien,Int32.Parse(item.Item1));
                                }

                                
                                break;
                            default:
                                break;
                        }

                        CTHDList.Clear();
                        fl_HD.Controls.Clear();
                        tongtienHD = 0;
                        lb_tongtien.Text = tongtienHD.ToString();

                        frm_Alert.Alert("Lập phiếu đặt thành công", frm_Alert.AlertType.success);
                    }
                }
                else
                {
                    frm_Alert.Alert("Vui lòng chọn SP trước khi TT", frm_Alert.AlertType.warning);
                }
            }
        }

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void cbx_phuongthuc_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (CTHDList.Count != 0 && cbx_phuongthuc.SelectedIndex != selectIndex)
            {
                if (MessageBox.Show("Bạn có muốn hủy order hiện tại không !", "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    CTHDList.Clear();
                    fl_HD.Controls.Clear();
                    tongtienHD = 0;
                    lb_tongtien.Text = tongtienHD.ToString();
                }
                else
                {
                    cbx_phuongthuc.SelectedIndex = selectIndex;
                    return;
                }
            }

            if (cbx_phuongthuc.SelectedIndex == 0)
            {
                
                loadDSBanhKemTrongNgay();
                btnNote.Visible = false;
            }
            else
            {
                loadDSBanhKem();

                btnNote.Visible = true;
            }
        }

        private void btnNote_Click(object sender, EventArgs e)
        {
            MaskedDialog.ShowDialog(this, frmNote.getForm);
            
        }

        private void btnHDChuaTT_Click(object sender, EventArgs e)
        {
            CTHDList.Clear();
            fl_HD.Controls.Clear();
            tongtienHD = 0;
            lb_tongtien.Text = tongtienHD.ToString();

            frmCatHD.loadLaiCTHD_ChuaThanhToanEvent += frmCatHD_loadLaiCTHD_ChuaThanhToanEvent;

            MaskedDialog.ShowDialog(this, frmCatHD.getForm);


        }

        void frmCatHD_loadLaiCTHD_ChuaThanhToanEvent(List<Tuple<string, int>> CTHDLists)
        {

            cbx_phuongthuc.SelectedIndex = 0;
            fl_HD.Controls.Clear();
            tongtienHD = 0;
            lb_tongtien.Text = tongtienHD.ToString();
            CTHDList = CTHDLists;

            loadCTHD();
            //throw new NotImplementedException();
        }

        private void gettime_Tick(object sender, EventArgs e)
        {
            //get current time
            int hh = webservice.getHour();
            int mm = webservice.getMinute();
            int ss = webservice.getSecond();
            //time
            string time = "";

            //padding leading zero
            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ":";

            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            time += ":";

            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }

            //update label
            label6.Text = time;
        }

        private void btnHDWeb_Click(object sender, EventArgs e)
        {
            this.Hide();

            frm_HoaDonOnLine.getForm_PhieuDat.Show();
        }

        private void btnCatHD_Click(object sender, EventArgs e) //======================== cất hóa đơn ===================================
        {
            if (MessageBox.Show("Bạn có chắc muốn tạm giữ order???", "Hỏi ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (cbx_phuongthuc.SelectedIndex == 0)
                {
                    if (CTHDList.Count != 0)
                    {
                        int? t = null;
                        if (frm_NhapKhachHang.tenKH != null || frm_NhapKhachHang.sDTKH != null || frm_NhapKhachHang.diaChiKH != null)
                        {
                            webservice.insert_KhachHang(frm_NhapKhachHang.tenKH, frm_NhapKhachHang.sDTKH, frm_NhapKhachHang.diaChiKH);
                            t = webservice.get_MaxMaKhachHang();
                        }
                        else if (frm_NhapKhachHang.maKH == null)
                            t = null;
                        else
                            t = Int32.Parse(frm_NhapKhachHang.maKH.ToString());

                        webservice.insert_HoaDon(frm_DangNhap.IDNV, Int32.Parse(lb_tongtien.Text.ToString()), t, false);

                        int tmp = webservice.get_MAXMaHoaDon();

                        foreach (var item in CTHDList)
                        {
                            int thanhtien = 0;

                            dt = c.ToDataTable(webservice.get_ChiTietHD(Int32.Parse(item.Item1)));

                            //thanhtien = ((dt.Rows[0]["gia"]-(Int32.Parse(dt.Rows[0]["gia"].ToString()) * Int32.Parse(dt.Rows[0]["tengiamgia"].ToString()) / 100) * item.Item2);
                            thanhtien = (Int32.Parse(dt.Rows[0]["gia"].ToString()) - (Int32.Parse(dt.Rows[0]["gia"].ToString()) * Int32.Parse(dt.Rows[0]["tengiamgia"].ToString()) / 100)) * item.Item2;

                            webservice.insert_CTHD(tmp, Int32.Parse(item.Item1.ToString()), item.Item2, thanhtien);

                            webservice.update_soLuongBanhTrongNgaySauThanhToan(Int32.Parse(item.Item1), item.Item2);
                            // mã bánh và số lượng
                        }

                        CTHDList.Clear();
                        fl_HD.Controls.Clear();
                        tongtienHD = 0;
                        lb_tongtien.Text = tongtienHD.ToString();

                        loadDSBanhKemTrongNgay();

                        frm_Alert.Alert("Giữ hóa đơn thành công", frm_Alert.AlertType.success);
                    }
                    else
                    {
                        frm_Alert.Alert("Vui lòng chọn SP trước khi TT", frm_Alert.AlertType.warning);
                    }
                }
                else
                {
                    if (CTHDList.Count != 0)
                    {
                        if (DateTime.Parse(frmNote.ngaynhan.ToString("yyyy/MM/dd")) < DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd")))
                        {
                            frm_Alert.Alert("Vui lòng chọn ngày nhận", frm_Alert.AlertType.warning);
                            MaskedDialog.ShowDialog(this, frmNote.getForm);
                            return;

                        }
                        int kt = 0;
                        if ((frm_NhapKhachHang.kt == 1 && frm_NhapKhachHang.maKH == null) || (frm_NhapKhachHang.kt == 0 && frm_NhapKhachHang.tenKH == null))
                        {
                            frm_Alert.Alert("Vui lòng nhập TT khách hàng", frm_Alert.AlertType.warning);

                            kt = -1;

                            MaskedDialog.ShowDialog(this, frm_NhapKhachHang.getForm);
                            return;
                        }
                        else
                        {
                            if (frm_NhapKhachHang.maKH != null)
                            {
                                kt = 1;
                            }
                            else
                            {
                                kt = 2;
                            }
                            switch (kt)
                            {
                                case 1:
                                    webservice.insert_PhieuDat(frm_DangNhap.IDNV, frmNote.ngaynhan, Int32.Parse(lb_tongtien.Text.ToString()), Int32.Parse(frm_NhapKhachHang.maKH.ToString()), frmNote.note, false);
                                    break;
                                case 2:
                                    webservice.insert_KhachHang(frm_NhapKhachHang.tenKH, frm_NhapKhachHang.sDTKH, frm_NhapKhachHang.diaChiKH);

                                    webservice.insert_PhieuDat(frm_DangNhap.IDNV, frmNote.ngaynhan, Int32.Parse(lb_tongtien.Text.ToString()), webservice.get_MaxMaKhachHang(), frmNote.note, false);
                                    
                                    int tmp = webservice.get_MAXMaPhieuDat();

                                    foreach (var item in CTHDList)
                                    {
                                        int thanhtien = 0;

                                        dt = c.ToDataTable(webservice.get_ChiTietPD(Int32.Parse(item.Item1)));

                                        //thanhtien = ((dt.Rows[0]["gia"]-(Int32.Parse(dt.Rows[0]["gia"].ToString()) * Int32.Parse(dt.Rows[0]["tengiamgia"].ToString()) / 100) * item.Item2);
                                        thanhtien = (Int32.Parse(dt.Rows[0]["gia"].ToString()) - (Int32.Parse(dt.Rows[0]["gia"].ToString()) * Int32.Parse(dt.Rows[0]["tengiamgia"].ToString()) / 100)) * item.Item2;

                                        webservice.insert_CTPD(tmp, item.Item2, thanhtien, Int32.Parse(item.Item1));
                                    }
                                    break;
                                default:
                                    break;
                            }

                            CTHDList.Clear();
                            fl_HD.Controls.Clear();
                            tongtienHD = 0;
                            lb_tongtien.Text = tongtienHD.ToString();

                            frm_Alert.Alert("Giữ phiếu đặt thành công", frm_Alert.AlertType.success);
                        }
                    }
                    else
                    {
                        frm_Alert.Alert("Vui lòng chọn SP trước khi TT", frm_Alert.AlertType.warning);
                    }
                }
            }
            
        }

    }
}
