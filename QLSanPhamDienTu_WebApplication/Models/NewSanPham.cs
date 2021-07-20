using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLSanPhamDienTu_WebApplication.Models
{
    public class NewSanPham
    {
		private int maSanPham;

		private string tenSanPham;

		private System.Nullable<int> soLuong;

		private System.Nullable<decimal> donGia;

		private string moTa;

		private string moTaChiTiet;

		private string khuyenMai;

		private System.Nullable<decimal> giamGia;

		private System.Nullable<System.DateTime> ngayCapNhat;

		private string xuatXu;

		private string hinhMinhHoa;

		private string dsHinh;

		private System.Nullable<bool> tinhTrang;

		private System.Nullable<int> maDanhMuc;
        private string ghiChu;

        public int MaSanPham { get => maSanPham; set => maSanPham = value; }
        public string TenSanPham { get => tenSanPham; set => tenSanPham = value; }
        public int? SoLuong { get => soLuong; set => soLuong = value; }
        public decimal? DonGia { get => donGia; set => donGia = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public string MoTaChiTiet { get => moTaChiTiet; set => moTaChiTiet = value; }
        public string KhuyenMai { get => khuyenMai; set => khuyenMai = value; }
        public decimal? GiamGia { get => giamGia; set => giamGia = value; }
        public DateTime? NgayCapNhat { get => ngayCapNhat; set => ngayCapNhat = value; }
        public string XuatXu { get => xuatXu; set => xuatXu = value; }
        public string HinhMinhHoa { get => hinhMinhHoa; set => hinhMinhHoa = value; }
        public string DsHinh { get => dsHinh; set => dsHinh = value; }
        public bool? TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public int? MaDanhMuc { get => maDanhMuc; set => maDanhMuc = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
    }
}