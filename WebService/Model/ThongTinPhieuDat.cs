using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Model
{
    public class ThongTinPhieuDat
    {

        public int maKH, tongtien, thanhtien, maNV;
        public string tenKH, diachiKH, sdt;
        public int maPD;
        public DateTime ngaydat, ngaynhan;
        public bool trangthai_online, trangthai_thanhtoan;
        public int maCTPD, maBK, soLuong, gia, maSize;
        public string tenSize, tenBK, tenGiamGia, tenNV;

    }
    
}