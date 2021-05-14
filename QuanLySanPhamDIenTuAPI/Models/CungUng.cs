using System;
using System.Collections.Generic;

namespace QuanLySanPhamDIenTuAPI.Models
{
    public partial class CungUng
    {
        public int MaNhaCungCap { get; set; }
        public int MaSanPham { get; set; }

        public virtual NhaCungCap MaNhaCungCapNavigation { get; set; }
        public virtual SanPham MaSanPhamNavigation { get; set; }
    }
}
