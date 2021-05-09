using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLSanPhamDienTu_WebApplication.Models
{
    public class GioHang
    {
        QL_SanPhamEntities db = new QL_SanPhamEntities();
        public int maSanPham { get; set; }
        public string tenSanPham { get; set; }
        public string hinhAnh { get; set; }
        public double donGia { get; set; }
        public double giamGia { get; set; }
        public int soLuong { get; set; }
        public double ThanhTien
        {
            get { return soLuong * (donGia-giamGia); }
        }

        public double ThanhTienGiamGia
        {
            get { return soLuong * giamGia; }
        }
        public GioHang(int maSanPham)
        {
            this.maSanPham = maSanPham;
            SanPham sp = db.SanPhams.Single(m => m.maSanPham == maSanPham);
            tenSanPham = sp.tenSanPham;
            hinhAnh = sp.hinhMinhHoa;
            donGia = (double.Parse(sp.donGia.ToString()));
            giamGia = (double.Parse(sp.giamGia.ToString()));
            soLuong = 1;
        }
    }
}