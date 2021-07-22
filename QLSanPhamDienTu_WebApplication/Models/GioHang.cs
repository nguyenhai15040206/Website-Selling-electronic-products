using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace QLSanPhamDienTu_WebApplication.Models
{
    public class GioHang
    {
        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();
        public int maSanPham { get; set; }
        public string tenSanPham { get; set; }
        public string hinhAnh { get; set; }
        public double donGia { get; set; }
        public double giamGia { get; set; }
        public int soLuong { get; set; }
        public string ghiChu { get; set; }
        public string tenDanhMuc { get; set; }
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
            NewSanPham sp = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://192.168.1.3:5000/Home/Introduct/");
                var responseTask = client.GetAsync("SanPham/" + maSanPham);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readObj = result.Content.ReadAsAsync<NewSanPham>();
                    readObj.Wait();
                    sp = readObj.Result;
                    tenSanPham = sp.TenSanPham;
                    hinhAnh = sp.HinhMinhHoa;
                    donGia = (double.Parse(sp.DonGia.ToString()));
                    giamGia = (double.Parse(sp.GiamGia.ToString()));
                    soLuong = 1;
                    ghiChu = sp.GhiChu.Trim();
                    tenDanhMuc = sp.TenDanhMuc.Trim();
                }
                else
                {
                    return;
                }
            }    
            
        }
    }
}