using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLSanPhamDienTu_WebApplication.Models
{
    public partial class DonMua
    {
        public int maHoaDon { get; set; }
        public int maKhachHang { get; set; }
        public Nullable<System.DateTime> ngayBan { get; set; }
        public string tenSanPham { get; set; }
        public string hinhMinhHoa { get; set; }
        public Nullable<int> soLuong { get; set; }
        public Nullable<decimal> donGia { get; set; }
        public Nullable<decimal> giamGia { get; set; }
    }
}