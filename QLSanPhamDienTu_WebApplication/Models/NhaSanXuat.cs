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
    
    public partial class NhaSanXuat
    {
        public NhaSanXuat()
        {
            this.DanhMucs = new HashSet<DanhMuc>();
        }
    
        public int maNhaSanXuat { get; set; }
        public string tenNhaSanXuat { get; set; }
        public string diaChi { get; set; }
        public string soDienThoai { get; set; }
        public string email { get; set; }
        public string logo { get; set; }
    
        public virtual ICollection<DanhMuc> DanhMucs { get; set; }
    }
}
