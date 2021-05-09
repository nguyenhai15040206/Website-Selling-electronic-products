//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLSanPhamDienTu_WebApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SanPham
    {
        public SanPham()
        {
            this.CTHoaDons = new HashSet<CTHoaDon>();
            this.NhaCungCaps = new HashSet<NhaCungCap>();
        }
    
        public int maSanPham { get; set; }
        public string tenSanPham { get; set; }
        public Nullable<int> soLuong { get; set; }
        public Nullable<decimal> donGia { get; set; }
        public string moTa { get; set; }
        public string moTaChiTiet { get; set; }
        public string khuyenMai { get; set; }
        public Nullable<decimal> giamGia { get; set; }
        public Nullable<System.DateTime> ngayCapNhat { get; set; }
        public string xuatXu { get; set; }
        public string hinhMinhHoa { get; set; }
        public string dsHinh { get; set; }
        public Nullable<bool> tinhTrang { get; set; }
        public Nullable<int> maDanhMuc { get; set; }
    
        public virtual ICollection<CTHoaDon> CTHoaDons { get; set; }
        public virtual DanhMuc DanhMuc { get; set; }
        public virtual ICollection<NhaCungCap> NhaCungCaps { get; set; }
    }
}
