using System;
using System.Collections.Generic;

namespace QuanLySanPhamDIenTuAPI.Models
{
    public partial class Banner
    {
        public int MaBanner { get; set; }
        public string FileBanner { get; set; }
        public bool? KichHoat { get; set; }
        public string GhiChu { get; set; }
    }
}
