using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebService.Model;
using System.IO;

namespace WebService
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        public WebService()
        {

        }

        [WebMethod, Description("Get image content")]
        public byte[] get_imageFile(string fileName)
        {
            if (System.IO.File.Exists(System.Web.Hosting.HostingEnvironment.MapPath("~/anhSP/") + fileName))
            {
                return System.IO.File.ReadAllBytes(System.Web.Hosting.HostingEnvironment.MapPath("~/anhSP/") + fileName);
            }
            else
            {
                return new byte[] { 0 };
            }
        }
      
        [WebMethod, Description("Inser image to webservice")]
        public string UploadFile(byte[] f, string fileName) 
        {
            MemoryStream ms = new MemoryStream(f);
            FileStream fs = new FileStream(System.Web.Hosting.HostingEnvironment.MapPath("~/anhSP/") + fileName, FileMode.Create);
            ms.WriteTo(fs);
            fs.Close();
            fs.Dispose();
            return "111";
        }

        //insert ok xong
        #region

        [WebMethod]
        public void insert_CTPD(int maPD, int soLuong, int thanhTien, int maSizeBanh)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;

                ChiTietPhieuDat ctpd = new ChiTietPhieuDat();

                ctpd.MaPD = maPD;
                ctpd.SoLuong = soLuong;
                ctpd.ThanhTien = thanhTien;
                ctpd.MaSizeBanh = maSizeBanh;
                data.ChiTietPhieuDats.InsertOnSubmit(ctpd);
                data.SubmitChanges();
            }
        }

        //-1: mới đặt và chưa làm
        //0: đã làm và đang giao
        //1: đã giao
        [WebMethod]
        public void insert_PhieuDat(int maNV, DateTime ngayNhan, int tongTien, int maKH, string ghiChu, bool trangThai)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;

                PhieuDat pd = new PhieuDat();
                pd.MaNV = maNV;
                pd.NgayLap = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                // pd.NgayNhan = ngayNhan.ToString;
                pd.NgayNhan = DateTime.Parse(ngayNhan.ToString("yyyy/MM/dd"));
                pd.TongTien = tongTien;
                pd.TrangThai_Online = false;
                pd.TrangThai_ThanhToan = trangThai;
                pd.TrangThai_GiaoHang = -1;
                pd.MaKhachHang = maKH;
                pd.GhiChu = ghiChu;
                data.PhieuDats.InsertOnSubmit(pd);
                data.SubmitChanges();
            }
        }


        [WebMethod]
        public void insert_KhachHang(string tenKH, string sDT, string diaChi)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;

                data.KhachHangInsert(tenKH, sDT, diaChi, null, null, true);
            }
        }

        [WebMethod]
        public void insert_CTHD(int maHD, int maBanhTrongNgay, int soLuong, int thanhTien)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;

                ChiTietHoaDon cthd = new ChiTietHoaDon();

                cthd.MaHoaDon = maHD;
                cthd.MaBanhTrongNgay = maBanhTrongNgay;
                cthd.SoLuong = soLuong;
                cthd.ThanhTien = thanhTien;

                data.ChiTietHoaDons.InsertOnSubmit(cthd);

                data.SubmitChanges();
            }
        }

        [WebMethod]
        public void insert_HoaDon(int maNV, int tongTien, int? maKH, bool trangthai)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                HoaDon hd = new HoaDon();
                hd.NgayLap = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                hd.MaNhanVien = maNV;
                hd.MaKhachHang = maKH;
                hd.TrangThai = trangthai;
                hd.TongTien = tongTien;
                data.HoaDons.InsertOnSubmit(hd);
                data.SubmitChanges();
            }
        }



        #endregion

        //select
        #region

        [WebMethod]
        public List<ChiTietHoaDonChuaThanhToan> get_CTHDChuaThanhToan(int maHD)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;

                return (
                from a in data.ChiTietHoaDons
                where a.MaHoaDon == maHD
                select new ChiTietHoaDonChuaThanhToan
                {
                    maBanhTrongNgay = a.MaBanhTrongNgay,
                    soLuong = a.SoLuong
                }).ToList();
            }

        }

        [WebMethod]
        public List<ThongTinPhieuDatChuaThanhToan> get_phieuDatChuaThanhToan()
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;

                return (
                    from a in data.PhieuDats
                    from b in data.KhachHangs
                    from c in data.NhanViens
                    where a.MaKhachHang == b.MaKhachHang
                    where a.MaNV == c.MaNV
                    where a.TrangThai_ThanhToan == false
                    select new ThongTinPhieuDatChuaThanhToan
                    {
                        maPD = a.MaPhieuDat,
                        tenKH = b.TenKhachHang,
                        ngayLap = a.NgayLap,
                        ngayNhan = a.NgayNhan,
                        tongTien = a.TongTien,
                        tenNV = c.TenNV
                    }).ToList();
            }
        }

        [WebMethod]
        public List<ThongTinHoaDonChuaThanhToan> get_hoaDonChuaThanhToan()
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;

                return (
                from a in data.HoaDons
                join n in data.NhanViens on a.MaNhanVien equals n.MaNV
                join b in data.KhachHangs on a.MaKhachHang equals b.MaKhachHang into kh
                from tenKHang in kh.DefaultIfEmpty()
                where a.TrangThai == false
                select new ThongTinHoaDonChuaThanhToan
                {
                    maHD = a.MaHoaDon,
                    tenKH = tenKHang.TenKhachHang,
                    ngayLap = a.NgayLap,
                    tongTien = a.TongTien,
                    tenNV = n.TenNV
                }).ToList();
            }
        }

        [WebMethod]
        public int get_kTraSoLuongBanhTrongNgay(int ma_banh_trong_ngay)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;

                int kt = (from a in data.BanhTrongNgays
                          where a.MaBanhTrongNgay == ma_banh_trong_ngay
                          where a.TrangThaiBanhHetHan == true
                          select a.SoLuong).SingleOrDefault();

                return kt;
            }
        }

        [WebMethod]
        public int get_MaxMaKhachHang()
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;

                return (from a in data.KhachHangs
                        select a.MaKhachHang).Max();
            }
        }

        [WebMethod]
        public int get_MAXMaPhieuDat()
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                return (from a in data.PhieuDats
                        select a.MaPhieuDat).Max();
            }
        }

        [WebMethod]
        public int get_MAXMaHoaDon()
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                return (from a in data.HoaDons
                        select a.MaHoaDon).Max();
            }
        }

        [WebMethod]
        public bool check_MaKH(int ma)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                int dem = 0;
                dem = (from a in data.KhachHangs
                       where a.MaKhachHang.Equals(ma)
                       select a).Count();
                if (dem == 1)
                    return true;
                return false;
            }
        }

        [WebMethod]
        public List<ChiTietPD> get_ChiTietPD(int masizebanh)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;

                return (from a in data.BanhKems
                        from b in data.GiamGias
                        from c in data.SizeBanhs
                        from d in data.Sizes
                        where a.MaGiamGia == b.MaGiamGia
                        where a.MaBanhKem == c.MaBanhKem
                        where d.MaSize == c.MaSize
                        where c.MaSizeBanh == masizebanh
                        select new ChiTietPD
                        {
                            tenbanhkem = a.TenBanhKem,
                            tengiamgia = b.TenGiamGia,
                            gia = c.Gia,
                            tensize = d.TenSize
                        }).ToList();
            }
        }

        [WebMethod]
        public List<ChiTietHD> get_ChiTietHD(int mabanhtrongngay)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                return (from a in data.BanhTrongNgays
                        from b in data.SizeBanhs
                        from c in data.BanhKems
                        from d in data.GiamGias
                        from e in data.Sizes
                        where a.MaSizeBanh == b.MaSizeBanh
                        where b.MaBanhKem == c.MaBanhKem
                        where c.MaGiamGia == d.MaGiamGia
                        where b.MaSize == e.MaSize
                        where a.MaBanhTrongNgay == mabanhtrongngay
                        select new ChiTietHD
                        {
                            tenbanhkem = c.TenBanhKem,
                            gia = b.Gia,
                            tengiamgia = d.TenGiamGia,
                            tensize = e.TenSize
                        }).ToList();
            }
        }

        [WebMethod]
        public List<ThongTinBanhKem> get_ListBanhKemvsTheLoai(int variable)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;

                return (from a in data.BanhKems
                        from b in data.GiamGias
                        where a.MaGiamGia == b.MaGiamGia
                        from c in data.SizeBanhs
                        where c.MaBanhKem == a.MaBanhKem
                        from d in data.Sizes
                        where d.MaSize == c.MaSize
                        where a.MaLoaiBanh.Equals(variable)
                        select new ThongTinBanhKem
                        {
                            maSizeBanh = c.MaSizeBanh,
                            anhBanhKem = a.HinhAnh,
                            tenBanhKem = a.TenBanhKem,
                            giaBanhKem = c.Gia,
                            giamgiaBanhKem = b.TenGiamGia,
                            tenSizeBanhKem = d.TenSize
                        }).ToList();
            }
        }

        [WebMethod]
        public List<ThongTinBanhTrongNgay> get_ListBanhTrongNgayVsTheLoai(int variable)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;

                return (from a in data.BanhTrongNgays
                        from b in data.BanhKems
                        from c in data.TheLoaiBanhs
                        from d in data.SizeBanhs
                        from e in data.Sizes
                        from f in data.GiamGias
                        where a.MaSizeBanh == d.MaSizeBanh
                        where d.MaBanhKem == b.MaBanhKem
                        where c.MaLoai == b.MaLoaiBanh
                        where c.MaLoai == variable
                        where e.MaSize == d.MaSize
                        where b.MaGiamGia == f.MaGiamGia
                        where a.SoLuong > 0
                        where a.TrangThaiBanhHetHan == true
                        select new ThongTinBanhTrongNgay
                        {
                            maBanhTrongNgay = a.MaBanhTrongNgay,
                            anhSP = b.HinhAnh,
                            tenSP = b.TenBanhKem,
                            giaSP = d.Gia,
                            tenSizeSP = e.TenSize,
                            giamgia = f.TenGiamGia
                        }).ToList();
            }

        }

        [WebMethod]
        public List<ThongTinBanhKem> get_ListBanhKem()
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;

                return (from a in data.BanhKems
                        from b in data.GiamGias
                        where a.MaGiamGia == b.MaGiamGia
                        from c in data.SizeBanhs
                        where c.MaBanhKem == a.MaBanhKem
                        from d in data.Sizes
                        where d.MaSize == c.MaSize
                        select new ThongTinBanhKem
                        {
                            maSizeBanh = c.MaSizeBanh,
                            anhBanhKem = a.HinhAnh,
                            tenBanhKem = a.TenBanhKem,
                            giaBanhKem = c.Gia,
                            giamgiaBanhKem = b.TenGiamGia,
                            tenSizeBanhKem = d.TenSize
                        }).ToList();
            }
        }

        [WebMethod]
        public List<ThongTinBanhTrongNgay> get_ListBanhTrongNgay()
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                var item = (from a in data.BanhTrongNgays
                            join b in data.SizeBanhs
                            on a.MaSizeBanh equals b.MaSizeBanh
                            join c in data.BanhKems
                            on b.MaBanhKem equals c.MaBanhKem
                            join d in data.Sizes
                            on b.MaSize equals d.MaSize
                            join e in data.GiamGias
                            on c.MaGiamGia equals e.MaGiamGia
                            where a.SoLuong > 0
                            where a.TrangThaiBanhHetHan == true
                            select new ThongTinBanhTrongNgay
                            {
                                maBanhTrongNgay = a.MaBanhTrongNgay,
                                anhSP = c.HinhAnh,
                                tenSP = c.TenBanhKem,
                                giaSP = b.Gia,
                                tenSizeSP = d.TenSize,
                                giamgia = e.TenGiamGia
                            });
                return item.ToList();

            }
        }

        [WebMethod]
        public List<TheLoaiBanh> get_ListTheLoaiBanh() // lấy danh sách thể loại bánh
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                return (from u in data.TheLoaiBanhs
                        select u).ToList();
            }
        }
        [WebMethod]
        public int get_Count_UserNV(string username) // đếm số lượng username NV để phân quyền
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {

                data.DeferredLoadingEnabled = false;

                return (from u in data.NhanViens
                        where u.Username.Equals(username)
                        select u.Username).Count();
            }
        }

        [WebMethod]
        public int get_CountUser_PassNV(string username, string pass)// đếm số lượng username và pass NV để phân quyền
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;

                return (from u in data.NhanViens
                        where u.Username.Equals(username)
                        where u.Password.Equals(pass)
                        select u.Username).Count();
            }
        }

        [WebMethod]
        public int get_IDNV(string username, string pass)//lấy id nhân viên khi đăng nhập
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;

                return (from u in data.NhanViens
                        where u.Username.Equals(username)
                        where u.Password.Equals(pass)
                        select u.MaNV).Single();
            }
        }
        [WebMethod]
        public int get_MaQuyenNV(int maNV) // lấy mã quyền của nhân viên
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {

                data.DeferredLoadingEnabled = false;

                return (from u in data.NhanVien_Quyens
                        where u.MaNhanVien.Equals(maNV)
                        where u.TrangThai.Equals("True")
                        select u.MaQuyen).Single();
            }
        }

        [WebMethod]
        public List<Int32> get_MaHoatDong(int maQuyen) // lấy list hoạt động của nv
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;

                return (from u in data.Quyen_HoatDongs
                        where u.MaQuyen.Equals(maQuyen)
                        where u.TrangThai.Equals("True")
                        select u.MaHoatDong).ToList();
            }
        }

        [WebMethod]
        public string get_username(int ID)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;

                return (from u in data.NhanViens
                        where u.MaNV == ID
                        select u.Username
                            ).Single();
            }
        }

        [WebMethod]
        public int getHour()
        {
            return DateTime.Now.Hour;
        }

        [WebMethod]
        public int getMinute()
        {
            return DateTime.Now.Minute;
        }

        [WebMethod]
        public int getSecond()
        {
            return DateTime.Now.Second;
        }
        #endregion

        // update
        #region

        [WebMethod]
        public void update_soLuongBanhTrongNgaySauThanhToan(int mabanhtrongngay, int soluong)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;

                var query = (from a in data.BanhTrongNgays
                             where a.MaBanhTrongNgay == mabanhtrongngay
                             where a.TrangThaiBanhHetHan == true
                             select a).SingleOrDefault();
                query.SoLuong -= soluong;

                data.SubmitChanges();
            }
        }
        #endregion


        //thương mèo code===========================================================================================================================================
        #region 

        

        // thuong    ---- hóa đơn - phiếu đặt online

        [WebMethod]
        public List<Model.ThongTinPhieuDat> get_DanhSachPhieuDat_Online()
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                var query = (from pd in data.PhieuDats
                             join kh in data.KhachHangs on pd.MaKhachHang equals kh.MaKhachHang
                             where pd.TrangThai_Online.Equals("True")
                             where pd.TrangThai_GiaoHang.Equals("-1")
                             select new Model.ThongTinPhieuDat
                             {
                                 maPD = pd.MaPhieuDat,
                                 maKH = pd.MaKhachHang,
                                 tenKH = kh.TenKhachHang,
                                 diachiKH = kh.DiaChi_KhachHang,
                                 sdt = kh.SDT_KhachHang,
                                 ngaydat = pd.NgayLap,
                                 ngaynhan = pd.NgayNhan,
                                 trangthai_thanhtoan = pd.TrangThai_ThanhToan,
                                 tongtien = pd.TongTien
                             });

                return query.ToList();
            }
        }

        [WebMethod]
        public List<Model.ThongTinPhieuDat> get_DanhSachPhieuDat_TaiQuay()
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                var query = (from pd in data.PhieuDats
                             join kh in data.KhachHangs on pd.MaKhachHang equals kh.MaKhachHang
                             join nv in data.NhanViens on pd.MaNV equals nv.MaNV
                             where pd.TrangThai_Online.Equals("False")
                             where pd.TrangThai_GiaoHang.Equals("-1")
                             select new Model.ThongTinPhieuDat
                             {
                                 maPD = pd.MaPhieuDat,
                                 maKH = pd.MaKhachHang,
                                 tenKH = kh.TenKhachHang,
                                 diachiKH = kh.DiaChi_KhachHang,
                                 sdt = kh.SDT_KhachHang,
                                 ngaydat = pd.NgayLap,
                                 ngaynhan = pd.NgayNhan,
                                 trangthai_thanhtoan = pd.TrangThai_ThanhToan,
                                 tenNV = nv.TenNV,
                                 tongtien = pd.TongTien
                             });

                return query.ToList();
            }
        }

        [WebMethod]
        public List<Model.ThongTinPhieuDat> get_DanhSachPhieuDat_DangGiao()
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;

                var query = (
                                from pd in data.PhieuDats
                                join kh in data.KhachHangs on pd.MaKhachHang equals kh.MaKhachHang
                                join nv in data.NhanViens on pd.MaNV equals nv.MaNV into e
                                from tennv in e.DefaultIfEmpty()
                                where pd.TrangThai_GiaoHang.Equals("0")
                                select new Model.ThongTinPhieuDat
                                {
                                    tenNV = tennv == null ? "PĐ ONLINE" : tennv.TenNV,
                                    maPD = pd.MaPhieuDat,
                                    maKH = pd.MaKhachHang,
                                    tenKH = kh.TenKhachHang,
                                    diachiKH = kh.DiaChi_KhachHang,
                                    sdt = kh.SDT_KhachHang,
                                    ngaydat = pd.NgayLap,
                                    ngaynhan = pd.NgayNhan,
                                    trangthai_online = pd.TrangThai_Online,
                                    trangthai_thanhtoan = pd.TrangThai_ThanhToan,
                                    tongtien = pd.TongTien
                                }
                            );

                return query.ToList();
            }
        }

        [WebMethod]
        public List<Model.ThongTinPhieuDat> get_ChiTietPhieuDat(string mapd)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                var query = (from pd in data.PhieuDats
                             from ct in data.ChiTietPhieuDats
                             from sb in data.SizeBanhs
                             from s in data.Sizes
                             from bk in data.BanhKems
                             from gg in data.GiamGias
                             where pd.MaPhieuDat.Equals(ct.MaPD)
                             where pd.MaPhieuDat.Equals(mapd)
                             where ct.MaSizeBanh.Equals(sb.MaSizeBanh)
                             where sb.MaSize.Equals(s.MaSize)
                             where sb.MaBanhKem.Equals(bk.MaBanhKem)
                             where bk.MaGiamGia.Equals(gg.MaGiamGia)
                             select new Model.ThongTinPhieuDat
                             {
                                 tenGiamGia = gg.TenGiamGia,
                                 maBK = bk.MaBanhKem,
                                 tenBK = bk.TenBanhKem,
                                 tenSize = s.TenSize,
                                 gia = sb.Gia,
                                 soLuong = ct.SoLuong,
                                 thanhtien = ct.ThanhTien
                             }
                            );
                return query.ToList();
            }
        }

        [WebMethod]
        public List<Model.ThongTinPhieuDat> get_ThongTinPhieuDat(string mapd)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                var query = (from pd in data.PhieuDats
                             join kh in data.KhachHangs on pd.MaKhachHang equals kh.MaKhachHang
                             join nv in data.NhanViens on pd.MaNV equals nv.MaNV
                             where pd.MaPhieuDat.Equals(mapd)
                             select new Model.ThongTinPhieuDat
                             {
                                 maPD = pd.MaPhieuDat,
                                 tenKH = kh.TenKhachHang,
                                 diachiKH = kh.DiaChi_KhachHang,
                                 sdt = kh.SDT_KhachHang,
                                 ngaydat = pd.NgayLap,
                                 ngaynhan = pd.NgayNhan,
                                 tongtien = pd.TongTien
                             });

                return query.ToList();
            }
        }

        [WebMethod]
        public void set_TinhTrangDangGiaoHangPhieuDat(string mapd)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                var query = (from pd in data.PhieuDats
                             where pd.MaPhieuDat.Equals(mapd)
                             where pd.TrangThai_GiaoHang.Equals(-1)
                             select pd).SingleOrDefault();
                query.TrangThai_GiaoHang = 0;
                data.SubmitChanges();
            }
        }

        [WebMethod]
        public void set_TinhTrangGiaoHangXong(string mapd)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                var query = (from pd in data.PhieuDats
                             where pd.MaPhieuDat.Equals(mapd)
                             where pd.TrangThai_GiaoHang.Equals(0)
                             select pd).SingleOrDefault();
                query.TrangThai_GiaoHang = 1;
                data.SubmitChanges();
            }
        }

        [WebMethod]
        public List<Model.ThongTinPhieuDat> search_PhieuDatDangGiao(string chuoi)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                var query = (from pd in data.PhieuDats
                             join kh in data.KhachHangs on pd.MaKhachHang equals kh.MaKhachHang
                             join nv in data.NhanViens on pd.MaNV equals nv.MaNV into e
                             from tennv in e.DefaultIfEmpty()
                             where pd.TrangThai_GiaoHang.Equals("0") && (pd.MaPhieuDat.ToString().Equals(chuoi) || tennv.TenNV.Contains(chuoi) ||
                                                                        kh.TenKhachHang.Contains(chuoi) || kh.SDT_KhachHang.Contains(chuoi) || kh.DiaChi_KhachHang.Contains(chuoi))
                             select new Model.ThongTinPhieuDat
                             {
                                 tenNV = tennv == null ? "PĐ ONLINE" : tennv.TenNV,
                                 maPD = pd.MaPhieuDat,
                                 maKH = pd.MaKhachHang,
                                 tenKH = kh.TenKhachHang,
                                 diachiKH = kh.DiaChi_KhachHang,
                                 sdt = kh.SDT_KhachHang,
                                 ngaydat = pd.NgayLap,
                                 ngaynhan = pd.NgayNhan,
                                 trangthai_online = pd.TrangThai_Online,
                                 trangthai_thanhtoan = pd.TrangThai_ThanhToan,
                                 tongtien = pd.TongTien
                             }
                            );
                return query.ToList();
            }
        }

        [WebMethod]
        public List<Model.ThongTinPhieuDat> search_PhieuDatOnline(string chuoi)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                var query = (from pd in data.PhieuDats
                             join kh in data.KhachHangs on pd.MaKhachHang equals kh.MaKhachHang
                             where pd.TrangThai_GiaoHang.Equals("-1") && pd.TrangThai_Online.Equals("True") && (pd.MaPhieuDat.ToString().Equals(chuoi) ||
                                                                        kh.TenKhachHang.Contains(chuoi) || kh.SDT_KhachHang.Contains(chuoi) || kh.DiaChi_KhachHang.Contains(chuoi))
                             select new Model.ThongTinPhieuDat
                             {
                                 maPD = pd.MaPhieuDat,
                                 maKH = pd.MaKhachHang,
                                 tenKH = kh.TenKhachHang,
                                 diachiKH = kh.DiaChi_KhachHang,
                                 sdt = kh.SDT_KhachHang,
                                 ngaydat = pd.NgayLap,
                                 ngaynhan = pd.NgayNhan,
                                 trangthai_online = pd.TrangThai_Online,
                                 trangthai_thanhtoan = pd.TrangThai_ThanhToan,
                                 tongtien = pd.TongTien
                             }
                            );
                return query.ToList();
            }
        }

        [WebMethod]
        public List<Model.ThongTinPhieuDat> search_PhieuDatTaiQuay(string chuoi)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                var query = (from pd in data.PhieuDats
                             join kh in data.KhachHangs on pd.MaKhachHang equals kh.MaKhachHang
                             join nv in data.NhanViens on pd.MaNV equals nv.MaNV
                             where pd.TrangThai_GiaoHang.Equals("-1") && (pd.MaPhieuDat.ToString().Equals(chuoi) || nv.TenNV.Contains(chuoi) ||
                                                                        kh.TenKhachHang.Contains(chuoi) || kh.SDT_KhachHang.Contains(chuoi) || kh.DiaChi_KhachHang.Contains(chuoi))
                             select new Model.ThongTinPhieuDat
                             {
                                 tenNV = nv.TenNV,
                                 maPD = pd.MaPhieuDat,
                                 maKH = pd.MaKhachHang,
                                 tenKH = kh.TenKhachHang,
                                 diachiKH = kh.DiaChi_KhachHang,
                                 sdt = kh.SDT_KhachHang,
                                 ngaydat = pd.NgayLap,
                                 ngaynhan = pd.NgayNhan,
                                 trangthai_online = pd.TrangThai_Online,
                                 trangthai_thanhtoan = pd.TrangThai_ThanhToan,
                                 tongtien = pd.TongTien
                             }
                            );
                return query.ToList();
            }
        }

        #endregion

        // thuong   --- thống kê

        #region

        [WebMethod]
        public List<Model.ThongTinHoaDon> get_HoaDonDaBan(DateTime tuNgay, DateTime denNgay)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                var query = (from hd in data.HoaDons
                             join nv in data.NhanViens on hd.MaNhanVien equals nv.MaNV
                             where hd.TrangThai.Equals("True")
                             where hd.NgayLap >= tuNgay
                             where hd.NgayLap <= denNgay
                             select new Model.ThongTinHoaDon
                             {
                                 maHD = hd.MaHoaDon,
                                 tenNV = nv.TenNV,
                                 tongTien = hd.TongTien,
                                 ngayLap = hd.NgayLap
                             }
                            );

                return query.ToList();
            }
        }

        [WebMethod]
        public List<Model.ThongTinPhieuDat> get_ThongKePhieuDat(DateTime tuNgay, DateTime denNgay)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                var query = (from pd in data.PhieuDats
                             join nv in data.NhanViens on pd.MaNV equals nv.MaNV into e
                             from tennv in e.DefaultIfEmpty()
                             where pd.TrangThai_GiaoHang.Equals(1)
                             where pd.NgayLap >= tuNgay
                             where pd.NgayLap <= denNgay
                             select new Model.ThongTinPhieuDat
                             {
                                 maPD = pd.MaPhieuDat,
                                 ngaydat = pd.NgayLap,
                                 tongtien = pd.TongTien,
                                 tenNV = tennv == null ? "PĐ ONline" : tennv.TenNV
                             }
                            );

                return query.ToList();
            }
        }


        [WebMethod]
        public int get_ThongKeTongTien_HDDaBan(DateTime tuNgay, DateTime denNgay)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                return data.sp_ThongKeTongTien_HDBan_Null(tuNgay, denNgay);
            }
        }

        [WebMethod]
        public int get_ThongKeTongTien_PhieuDat(DateTime tuNgay, DateTime denNgay)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                return data.sp_ThongKeTongTien_PhieuDat_Null(tuNgay, denNgay);
            }
        }

        [WebMethod]
        public List<ThongTinKhachHang> get_KH_TiemNang() // trả về list khách hàng tiềm năng
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                return (from kh_tiemnang in data.KH_TiemNang_Views
                        where kh_tiemnang.solan >= 1
                        select new ThongTinKhachHang
                        {
                            maKH = kh_tiemnang.MaKhachHang,
                            tenKH = kh_tiemnang.TenKhachHang,
                            diaChi = kh_tiemnang.DiaChi_KhachHang,
                            sdt = kh_tiemnang.SDT_KhachHang
                        }
                      ).ToList();
            }
        }

        [WebMethod]
        public List<ThongTinKhachHang> get_KH_TiemNang_DatHang() // trả về list khách hàng tiềm năng
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                return (from kh_tiemnang in data.KH_TiemNangPhieuDat_Views
                        where kh_tiemnang.soLan >= 1
                        select new Model.ThongTinKhachHang
                        {
                            maKH = kh_tiemnang.MaKhachHang,
                            tenKH = kh_tiemnang.TenKhachHang,
                            diaChi = kh_tiemnang.DiaChi_KhachHang,
                            sdt = kh_tiemnang.SDT_KhachHang
                        }
                      ).ToList();
            }
        }

        [WebMethod]
        public int get_SoLieu_TongSoHD(DateTime tuNgay, DateTime denNgay)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                var query = (from hd in data.HoaDons
                             where hd.TrangThai.Equals(1)
                             where hd.NgayLap >= tuNgay
                             where hd.NgayLap <= denNgay
                             select hd).Count();
                return query;
            }
        }

        [WebMethod]
        public int get_SoLieu_TongSoPD(DateTime tuNgay, DateTime denNgay)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                var query = (from pd in data.PhieuDats
                             where pd.TrangThai_GiaoHang.Equals(1)
                             where pd.NgayLap >= tuNgay
                             where pd.NgayNhan <= denNgay // do PĐOL trả tiền sau, PĐ tại quầy trả tiền trước nên, lấy giữa 2 móc để tính.
                             select pd).Count();
                return query;
            }
        }

        [WebMethod]
        public int get_SoLieu_DoanhThuPD(DateTime tuNgay, DateTime denNgay)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                return data.sp_TongTienPhieuDat_Null(tuNgay, denNgay); // do khoảng thời gian ngày thống kê có thể ko có phiếu đặt nên phải có store
            }
        }

        [WebMethod]
        public int get_SoLieu_DoanhThuHD(DateTime tuNgay, DateTime denNgay)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;

                return data.sp_TongTienHoaDon_Null(tuNgay, denNgay);
            }
        }

        [WebMethod]
        public List<Model.ThongKeBanhTrongNgay> get_SoLieuBanhTrongNgay() // danh sách bánh trong 1 ngày gồm: còn hạn và hết hết hạn
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                var query = (from btn in data.BanhTrongNgays
                             from sb in data.SizeBanhs
                             where btn.MaSizeBanh.Equals(sb.MaSizeBanh)
                             where btn.TrangThaiBanhHetHan.Equals("True")
                             from s in data.Sizes
                             where sb.MaSize.Equals(s.MaSize)
                             from bk in data.BanhKems
                             where sb.MaBanhKem.Equals(bk.MaBanhKem)
                             from g in data.GiamGias
                             where bk.MaGiamGia.Equals(g.MaGiamGia)
                             select new Model.ThongKeBanhTrongNgay
                             {
                                 tenBanh = bk.TenBanhKem,
                                 soLuong = btn.SoLuong,
                                 donGia = sb.Gia,
                                 ngayHetHan = btn.NgayHetHan,
                                 tenGiamGia = g.TenGiamGia,
                                 tenSize = s.TenSize
                             });
                return query.ToList();
            }
        }

        [WebMethod]
        public int get_ThongKeSoBanhHienTaiTrongNgay()
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                return (from btn in data.BanhTrongNgays where btn.TrangThaiBanhHetHan.Equals("True") select btn.SoLuong).Sum();
            }
        }

        [WebMethod]
        public int get_ThongKeSoBanhDaBanTrongNgay()
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                return data.sp_ThongKeSoBanhDaBan_Null();
            }
        }

        [WebMethod]
        public int get_ThongKeSoBanhHetHanTrongNgay()
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                return data.sp_ThongKeSoBanhHetHan_Null();
            }
        }

        [WebMethod]
        public List<Model.ThongKeBanhTrongNgay> get_ListBanhHetHan() // danh sách bánh hết hạn trong 1 ngày
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                var query = (from hethan in data.DanhSachBanhHetHan_Views
                             where hethan.TrangThaiBanhHetHan.Equals("True") // bánh hết hạn mà trạng thái là true, để mình update xuống là false
                             select new Model.ThongKeBanhTrongNgay
                             {
                                 maBanhTrongNgay = hethan.MaBanhTrongNgay,
                                 maBK = hethan.MaBanhKem,
                                 tenBanh = hethan.TenBanhKem,
                                 tenSize = hethan.TenSize,
                                 donGia = hethan.Gia,
                                 tenGiamGia = hethan.TenGiamGia,
                                 hinhAnh = hethan.HinhAnh,
                                 soLuong = hethan.SoLuong,
                                 ngayHetHan = hethan.NgayHetHan,
                                 ngaySX = hethan.NgaySanXuat
                             });
                return query.ToList();
            }
        } /////////////////////////////////////////////////////////////////////

        [WebMethod]
        public int get_CountSoLoaiBanh_HetHan()
        {
            string date = DateTime.Now.ToString("yyyy/MM/dd");
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false; // cho phép truy cập và load cùng lúc nhiều dữ liệu trong 1 hàm 
                var query = (from btn in data.BanhTrongNgays
                             where btn.NgayHetHan.Equals(DateTime.Now.ToString("yyyy/MM/dd"))
                             where btn.TrangThaiBanhHetHan.Equals(1)
                             select btn).Count();
                return query;
            }
        }

        [WebMethod]
        public int get_CountBanhHetHan()
        {
            string date = DateTime.Now.ToString("yyyy/MM/dd");
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false; // cho phép truy cập và load cùng lúc nhiều dữ liệu trong 1 hàm 
                var query = data.sp_SumSoBanhHetHan();
                return query;
            }
        }


        //[WebMethod] chưa làm search bánh hết hạn
        //public List<Model.ThongKeBanhTrongNgay> search_BanhHetHan()
        //{
        //    using (DatabaseDataContext data = new DatabaseDataContext())
        //    {
        //        data.DeferredLoadingEnabled = false;
        //       // var query = (from btn in data.BanhTrongNgays);
        //    }
        //}

        //// Quản lý: bánh trong ngày

        [WebMethod]
        public void set_TinhTrangBanhTrongNgayHetHanThanhFalse(int maBanhTrongNgay)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                var query = (from btn in data.BanhTrongNgays
                             where btn.MaBanhTrongNgay.Equals(maBanhTrongNgay)
                             select btn).SingleOrDefault();
                query.TrangThaiBanhHetHan = false;
                data.SubmitChanges();
            }
        }

        #endregion


        // thêm bánh trong ngày
        #region

        [WebMethod]
        public List<Model.ThongKeBanhTrongNgay> get_ListDanhSachBanhTrongNgay() /// lấy ra ds bánh trong ngày còn hạn: đưa vào user control
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                var query = (from btn in data.BanhTrongNgays
                             from sb in data.SizeBanhs
                             from bk in data.BanhKems
                             from s in data.Sizes
                             from tl in data.TheLoaiBanhs
                             where btn.MaSizeBanh.Equals(sb.MaSizeBanh)
                             where btn.TrangThaiBanhHetHan.Equals("True")
                             where sb.MaSize.Equals(s.MaSize)
                             where btn.NgayHetHan.CompareTo(DateTime.Now.ToString("yyyy/MM/dd")) == 1
                             where sb.MaBanhKem.Equals(bk.MaBanhKem)
                             where bk.MaLoaiBanh.Equals(tl.MaLoai)
                             select new Model.ThongKeBanhTrongNgay
                             {
                                 maBanhTrongNgay = btn.MaBanhTrongNgay,
                                 tenBanh = bk.TenBanhKem,
                                 ngaySX = btn.NgaySanXuat,
                                 tenSize = s.TenSize,
                                 hinhAnh = bk.HinhAnh
                             }).ToList();
                return query;
            }
        }

        [WebMethod]
        public List<ThongTinChiTietBanhTrongNgay> get_ThongTinChiTietBanhTrongNgay(int maBanhTrongNgay)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                var query = (from btn in data.BanhTrongNgays
                             from sb in data.SizeBanhs
                             where btn.MaBanhTrongNgay == maBanhTrongNgay
                             where btn.MaSizeBanh == sb.MaSizeBanh
                             from bk in data.BanhKems
                             where sb.MaBanhKem == bk.MaBanhKem
                             from s in data.Sizes
                             where sb.MaSize == s.MaSize
                             from g in data.GiamGias
                             where bk.MaGiamGia == g.MaGiamGia
                             from tl in data.TheLoaiBanhs
                             where bk.MaLoaiBanh == tl.MaLoai
                             select new ThongTinChiTietBanhTrongNgay
                             {
                                 hinhAnhBK = bk.HinhAnh,
                                 tenBK = bk.TenBanhKem,
                                 maSB = sb.MaSizeBanh,
                                 maBK = bk.MaBanhKem,
                                 tenTheLoai = tl.TenLoai,
                                 tenSize = s.TenSize,
                                 ngaySX = btn.NgaySanXuat,
                                 ngayHetHan = btn.NgayHetHan,
                                 soLuong = btn.SoLuong,
                                 donGia = sb.Gia,
                                 tenGiamGia = g.TenGiamGia,
                                 moTa = bk.MoTa
                             }).ToList();
                return query;
            }
        }


        // Thêm bánh trong ngày
        [WebMethod]
        public List<ThongTinBanhKem_Insert> get_ListTenBanhKem()
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                var query = (from bk in data.BanhKems
                             select new ThongTinBanhKem_Insert
                             {
                                 tenBanhKem = bk.TenBanhKem,
                                 maBanhKem = bk.MaBanhKem
                             }).ToList();
                return query;
            }
        }

        [WebMethod]
        public List<SizeBanhKem> get_SizeTheoBanhKem(int maBanhKem)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                var query = (from bk in data.BanhKems
                             from sb in data.SizeBanhs
                             where bk.MaBanhKem.Equals(sb.MaBanhKem)  // kết bk và sb
                             where bk.MaBanhKem.Equals(maBanhKem)       // so sánh mã bk == biến
                             from s in data.Sizes
                             where sb.MaSize.Equals(s.MaSize) // kết s và sb
                             select new SizeBanhKem
                             {
                                 maSize = s.MaSize,
                                 tenSize = s.TenSize,
                                 gia = sb.Gia
                             }).ToList();
                return query;
            }
        }

        [WebMethod]
        public int get_MaSizeBanh(int maBanhKem,int maSize)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                return (from sb in data.SizeBanhs
                            where sb.MaBanhKem.Equals(maBanhKem)
                            where sb.MaSize.Equals(maSize)
                            select sb.MaSizeBanh).Single();
            }
        }

        [WebMethod]
        public int get_MaSizeTrongNgay(int maBanhKem, int maSizeBanh)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                return (from sb in data.SizeBanhs
                        where sb.MaBanhKem.Equals(maBanhKem)
                        where sb.MaSizeBanh.Equals(maSizeBanh)
                        from btn in data.BanhTrongNgays
                        where btn.MaSizeBanh.Equals(sb.MaSizeBanh)
                        where btn.NgaySanXuat.CompareTo(DateTime.Now.ToString("yyyy/MM/dd")) == 0
                        select sb.MaSizeBanh).Single();
            }
        }

        [WebMethod]
        public void Insert_BanhTrongNgay(int maSizeBanh, int soLuong, DateTime ngaySX, DateTime ngayHetHan)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;

                BanhTrongNgay btn = new BanhTrongNgay();
                btn.MaSizeBanh = maSizeBanh;
                btn.NgaySanXuat = DateTime.Now;
                btn.NgayHetHan = ngayHetHan;
                btn.SoLuong = soLuong;
                btn.TrangThaiBanhHetHan = true;
                data.BanhTrongNgays.InsertOnSubmit(btn);
                data.SubmitChanges();
            }
        }

        [WebMethod]
        public bool check_BanhDaInsertTrongNgay(int maSizeBanh) // đếm với mã size bánh đó ứng với ngày hôm nay đã có chưa
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                int count = data.sp_DemSoBanhCoMaSizeBanhTrongNgay(maSizeBanh);
                if (count == -1)// đã thêm mã size bánh đó vào ngày hơm nay rồi, ko dc thêm nữa
                    return false;
                else
                    return true;
            }
           
        }

        // nhu thuogget
        [WebMethod]
        public List<MaBanhTrongNgay>  get_ListBanhNhapTrongNgay() // lấy danh sách mã size bánh đã nhập trong ngày getdate()
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;

                var query = (from view in data.ListMaBanhNhapTrongNgay_Views
                             select new MaBanhTrongNgay
                             {
                                 idBTN = view.MaBanhTrongNgay
                             }).ToList();
                return query;
            }
        }

        [WebMethod]
        public List<ThongTinChiTietBanhTrongNgay> get_ThongTinBanhKemUpdate(int maBanhTrongNgay)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                var query = (from btn in data.BanhTrongNgays
                             from sb in data.SizeBanhs
                             where btn.MaSizeBanh == sb.MaSizeBanh
                             where btn.MaBanhTrongNgay == maBanhTrongNgay
                             from s in data.Sizes
                             where sb.MaSize == s.MaSize
                             from bk in data.BanhKems
                             where sb.MaBanhKem == bk.MaBanhKem
                             select new ThongTinChiTietBanhTrongNgay
                             {
                                 maBK = bk.MaBanhKem,
                                 tenBK = bk.TenBanhKem,
                                 tenSize = s.TenSize,
                                 maSize = s.MaSize,
                                 ngayHetHan = btn.NgayHetHan,
                                 soLuong = btn.SoLuong,
                                 hinhAnhBK = bk.HinhAnh
                             }).ToList();
                return query;
            }
        }

        // cập nhật thông tin bánh kem trong ngày.
        [WebMethod]
        public void set_TTCapNhatBanhTrongNgay(int maBanhTrongNgay, DateTime ngayHH, int soluong)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                var query = (from btn in data.BanhTrongNgays
                             where btn.MaBanhTrongNgay == maBanhTrongNgay
                             select btn).SingleOrDefault();
                query.NgayHetHan = ngayHH;
                query.SoLuong = soluong;
                data.SubmitChanges();
            }
        }

        [WebMethod]
        public void set_TinhTrangBanhTrongNgay(int maBanhTrongNgay) // ko được xóa, bởi vì có thể có dính khóa ngoại bảng hóa đơn. nên tốt nhất là update lại tình trạng 
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                var query = (from btn in data.BanhTrongNgays
                                 where btn.MaBanhTrongNgay == maBanhTrongNgay
                                 select btn).SingleOrDefault();
                query.TrangThaiBanhHetHan = false;
                data.SubmitChanges();
            }
        }

        #endregion


        // thêm, cập nhật sản phẩm
        #region

        [WebMethod]
        public List<ThongTinQuanLySanPham> get_ThongTinQuanLyBanhKem()
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;

                var query = (from bk in data.BanhKems
                             from tl in data.TheLoaiBanhs
                             where bk.MaLoaiBanh == tl.MaLoai
                             select new ThongTinQuanLySanPham
                             {
                                 maBK = bk.MaBanhKem,
                                 tenBanhKem = bk.TenBanhKem,
                                 tenLoai = tl.TenLoai,
                                 hinhAnhBK = bk.HinhAnh,
                             }).ToList();
                return query;
            }
        }

        [WebMethod]
        public List<ThongTinQuanLySanPham> get_ThongTinBanhKemDangChon(int maBanhKem)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;

                var query = (from bk in data.BanhKems
                             from tl in data.TheLoaiBanhs
                             where bk.MaLoaiBanh == tl.MaLoai
                             where bk.MaBanhKem == maBanhKem
                             from g in data.GiamGias
                             where g.MaGiamGia == bk.MaGiamGia
                             select new ThongTinQuanLySanPham
                             {
                                 tenBanhKem = bk.TenBanhKem,
                                 tenLoai = tl.TenLoai,
                                 hinhAnhBK = bk.HinhAnh,
                                 moTa = bk.MoTa,
                                 tenGG = g.TenGiamGia
                             }).ToList();
                return query;
            }
        }

        [WebMethod]
        public List<ThongTinSize> get_SizeSanPhamDangChon(int maBanhKem)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;

                var query = (from bk in data.BanhKems
                             where bk.MaBanhKem == maBanhKem
                             from s in data.Sizes
                             from sb in data.SizeBanhs
                             where bk.MaBanhKem == sb.MaBanhKem
                             where sb.MaSize == s.MaSize
                             select new ThongTinSize
                             {
                                 tenSize = s.TenSize,
                                 maSize = s.MaSize,
                                 gia = sb.Gia,
                                 maSB = sb.MaSizeBanh
                             }).ToList();
                return query;
            }
        }

        [WebMethod]
        public int get_GiaSanPhamTheoSize(int maSizeBanh)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;

                var query = (from sb in data.SizeBanhs
                             where sb.MaSizeBanh == maSizeBanh
                             select sb.Gia).Single();
                return query;
            }
        }

        [WebMethod]
        public List<TheLoaiBanhKem> get_TenTheLoai()
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                var query = (from tl in data.TheLoaiBanhs
                             select new TheLoaiBanhKem
                             {
                                 tenTL = tl.TenLoai,
                                maTL = tl.MaLoai
                             }).ToList();
                return query;
            }
        }

        [WebMethod]
        public List<BanhKem> get_TenBanhKem(int maTL)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                var query = (from bk in data.BanhKems
                             where bk.MaLoaiBanh == maTL
                             select new BanhKem
                             {
                                 TenBanhKem = bk.TenBanhKem,
                                 MaBanhKem = bk.MaBanhKem
                             }).ToList();
                return query;
            }
        }

        [WebMethod]
        public List<ThongTinSize> get_TenSize()
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                return (from s in data.Sizes select new ThongTinSize { tenSize = s.TenSize, maSize = s.MaSize }).ToList();
            }
        }

        [WebMethod]
        public List<ThongTinGiamGia> get_TenGiamGia()
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                return (from g in data.GiamGias select new ThongTinGiamGia{maGG = g.MaGiamGia, tenGG = g.TenGiamGia}).ToList();
            }
        }

        [WebMethod]
        public void InsertSanPham(string tenBK, string hinhAnh, string moTa, int maLoai, int maGiamGia)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                BanhKem bk = new BanhKem();
                bk.TenBanhKem = tenBK;
                bk.HinhAnh = hinhAnh;
                bk.MoTa = moTa;
                bk.MaLoaiBanh = maLoai;
                bk.MaGiamGia = maGiamGia;
                data.BanhKems.InsertOnSubmit(bk);
                data.SubmitChanges();
            }
        }

        [WebMethod]
        public int getMaxIdBanhKem()
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                return (from bk in data.BanhKems select bk.MaBanhKem).Max();
            }
        }

        [WebMethod]
        public void InsertMaSizeBanh(int maBK, int maSize, int giaTien)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                SizeBanh sb = new SizeBanh();
                sb.MaBanhKem = maBK;
                sb.MaSize = maSize;
                sb.Gia = giaTien;
                data.SizeBanhs.InsertOnSubmit(sb);
                data.SubmitChanges();
            }
        }

        [WebMethod]
        public int getMaSizeBanhDangChon(int maBK, int maSize)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                return (from bk in data.BanhKems
                        where bk.MaBanhKem == maBK
                        from sb in data.SizeBanhs
                        where sb.MaBanhKem == bk.MaBanhKem
                        from s in data.Sizes
                        where s.MaSize == sb.MaSize
                        where s.MaSize == maSize
                        select sb.MaSizeBanh).SingleOrDefault();
            }
        }

        [WebMethod]
        public void UpdateSanPham(int mabk, string hinhanh, string tenbk, int idloai, int idgiamgia, string mota) // bởi vì uc có tag là mã bánh kem, size bánh ko liên quan đến chổ này
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                var query = (from bk in data.BanhKems where bk.MaBanhKem == mabk select bk).SingleOrDefault();
                query.HinhAnh = hinhanh;
                query.TenBanhKem = tenbk;
                query.MoTa = mota;
                query.MaLoaiBanh = idloai;
                query.MaGiamGia = idgiamgia;
                data.SubmitChanges();
            }
        }

        [WebMethod]
        public void UpdateSizeSanPhamDangChon(int masizebanh, int masize, int gia)// khonong update mã bánh kem, và mã sizebasnh, bởi vì mình đang chọn bánh đó để update, ko thể update thành bánh khsc
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                var query =(from sb in data.SizeBanhs 
                                where sb.MaSizeBanh == masizebanh
                                select sb).SingleOrDefault();
                query.MaSize = masize;
                query.Gia = gia;
                data.SubmitChanges();
            }
        }

        [WebMethod]
        public List<ThongTinQuanLySanPham> get_ThongTinSanPhamUpdate(int mabanhkem)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                var query = (from bk in data.BanhKems
                             where bk.MaBanhKem == mabanhkem
                             select new ThongTinQuanLySanPham
                             {
                                 tenBanhKem = bk.TenBanhKem,
                                 hinhAnhBK = bk.HinhAnh,
                                 moTa = bk.MoTa,
                             }).ToList();
                return query;
            }
        }
        [WebMethod]
        public List<ThongTinSanPham> get_ThongTinSanPhamUpdate1(int mabanhkem)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                var query = (from bk in data.BanhKems
                             where bk.MaBanhKem == mabanhkem
                             from sb in data.SizeBanhs
                             where sb.MaBanhKem == bk.MaBanhKem
                             from s in data.Sizes
                             where s.MaSize == sb.MaSize
                             from g in data.GiamGias
                             where g.MaGiamGia == bk.MaGiamGia
                             from l in data.TheLoaiBanhs
                             where l.MaLoai == bk.MaLoaiBanh
                             select new ThongTinSanPham
                             {
                                 hinhAnhBK = bk.HinhAnh,
                                 tenLoai = l.TenLoai,
                                 maTL = bk.MaLoaiBanh,
                                 tenBanhKem = bk.TenBanhKem,
                                 gia = sb.Gia,
                                 maSize = sb.MaSize,
                                 tenSize = s.TenSize,
                                 maGG = g.MaGiamGia,
                                 tenGG = g.TenGiamGia,
                                 moTa = bk.MoTa,

                             }).ToList();
                return query;
            }
        }
       
        #endregion
        
        // giảm giá
        #region
        [WebMethod]
        public List<GiamGia> get_ListGiamGia()
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                return (from g in data.GiamGias select g).ToList();
            }
        }


        [WebMethod]
        public void InsertGiamGia(string tenGG)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                GiamGia g = new GiamGia();
                g.TenGiamGia = tenGG;
                data.GiamGias.InsertOnSubmit(g);
                data.SubmitChanges();
            }
        }

        [WebMethod]
        public void UpdateGiamGia(int maGG,string tenGG)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                var query = (from g in data.GiamGias where g.MaGiamGia == maGG select g).SingleOrDefault();
                query.TenGiamGia = tenGG;
                data.SubmitChanges();
            }
        }

        [WebMethod]
        public void DeleteGiamGia(int maGG)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;
                var query = (from g in data.GiamGias where g.MaGiamGia == maGG select g).FirstOrDefault();
                data.GiamGias.DeleteOnSubmit(query);
                data.SubmitChanges();
            }
        }
        #endregion

        #region
        [WebMethod]
        public List<TheLoaiBanh> get_ThongTinSanPham()
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;

                var query = (from tl in data.TheLoaiBanhs
                             select tl).ToList();
                return query;
            }
        }

        [WebMethod]
        public List<TheLoaiBanh> get_ThongTinLoaiSPDangChon(int maLoai)
        {
            using (DatabaseDataContext data = new DatabaseDataContext())
            {
                data.DeferredLoadingEnabled = false;

                var query = (from tl in data.TheLoaiBanhs
                             where tl.MaLoai == maLoai
                             select tl).ToList();
                return query;
            }
        }

        #endregion

    }
}
