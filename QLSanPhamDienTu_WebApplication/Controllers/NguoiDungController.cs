using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLSanPhamDienTu_WebApplication.Models;

namespace QLSanPhamDienTu_WebApplication.Controllers
{
    public class NguoiDungController : Controller
    {
        //
        // GET: /NguoiDung/
        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();
        KiemTraDuLieu kiemTraDL = new KiemTraDuLieu();

        [HttpGet]
        public ActionResult dangKy()
        {
            return View();
        }

        public ActionResult dangKy(KhachHang kh, FormCollection f)
        {
            var tenKH = f["HoTen"];
            var soDienThoai = f["DienThoai"];
            var email = f["Email"];
            var diaChi = f["DiaChi"];
            var tenDangNhap = f["TenDangNhap"];
            var matKhau = f["MatKhau"];
            var reMatKHau = f["ReMatKhau"];
            if (string.IsNullOrEmpty(tenKH.Trim()))
            {
                ViewData["Loi1"] = "Họ tên không được để trống";
            }
            if(string.IsNullOrEmpty(email.Trim()))
            {
                ViewData["LoiEmail"] = "Email không được để trống";
            }    
            if (string.IsNullOrEmpty(soDienThoai.Trim()))
            {
                ViewData["Loi2"] = "Số điện thoại không được bỏ trống";
            }
            if (string.IsNullOrEmpty(tenDangNhap.Trim()) || kiemTraDL.isTextContainSPace(tenDangNhap.Trim())==false || (tenDangNhap.Trim().Length <5 && tenDangNhap.Trim().Length >30))
            {
                ViewData["Loi3"] = "Tên đăng nhập từ 5 đến 30 kí tự, không bao gồm khoảng trắng";
            }
            if(string.IsNullOrEmpty(matKhau.Trim()) || kiemTraDL.isTextContainSPace(matKhau.Trim())== false ||  (matKhau.Trim().Length < 5 && matKhau.Trim().Length > 30))
            {
                ViewData["Loi4"] = "Mật khẩu từ 5 đến 30 kí tự, không bao gồm khoảng trắng";
            }
            if (string.IsNullOrEmpty(reMatKHau))
            {
                ViewData["Loi5"] = "Nhập lại mật khẩu";
            }
            if (!string.IsNullOrEmpty(tenKH.Trim()) && !string.IsNullOrEmpty(email.Trim()) &&!string.IsNullOrEmpty(soDienThoai.Trim()) && !string.IsNullOrEmpty(tenDangNhap.Trim()) &&
                !string.IsNullOrEmpty(matKhau.Trim()) && !string.IsNullOrEmpty(reMatKHau.Trim()))
            {
                var kiemTra = db.KhachHangs.Count(m => m.tenDangNhap == tenDangNhap);
                if (kiemTra == 0)
                {
                    if (kiemTraDL.isPhoneNumber(soDienThoai))
                    {
                        if (matKhau.Trim() == reMatKHau.Trim())
                        {
                            kh.tenKhachHang = tenKH;
                            
                            kh.soDienThoai = soDienThoai;
                            kh.email = email;
                            kh.diaChi = diaChi;
                            kh.tenDangNhap = tenDangNhap;
                            kh.matKhau = matKhau;
                            db.KhachHangs.InsertOnSubmit(kh);
                            db.SubmitChanges();
                            return RedirectToAction("dangNhap","NguoiDung");
                        }
                        else
                        {
                            ViewData["Loi7"] = "Mật khẩu không khớp";
                        }
                    }
                    else
                    {
                        ViewData["Loi6"] = "Số điện thoại không hợp lệ";
                    }
                }
                else
                {
                    ViewData["Loi8"] = "Tài khoản đã tồn tại!";
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult dangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult dangNhap(FormCollection f)
        {
            var tenDangNhap = f["TenDangNhap"];
            var matKhau = f["MatKhau"];
            if (string.IsNullOrEmpty(tenDangNhap))
            {
                ViewData["Loi1"] = "Tên đăng nhập không được bỏ trống";
            }
            if (string.IsNullOrEmpty(matKhau))
            {
                ViewData["Loi2"] = "Mật khẩu không được bỏ trống";
            }
            if (!string.IsNullOrEmpty(tenDangNhap) && !string.IsNullOrEmpty(matKhau))
            {
                KhachHang kh = db.KhachHangs.SingleOrDefault(m => m.tenDangNhap.Trim() == tenDangNhap.Trim() && m.matKhau.Trim() == matKhau.Trim());
                if (kh != null)
                {
                    Session["TaiKhoan"] = kh;
                    return RedirectToAction("loadSanPhamDienThoai", "SanPham");
                }
                else
                {
                    ViewData["Loi3"] = "Sai tên Đăng Nhập hoặc sai Mật Khẩu, vui lòng đăng nhập lại!";
                }
                    
            }
            return View();
        }

        public ActionResult dangXuat()
        {
            Session["TaiKhoan"] = null;
            Session["GioHang"] = null;
            return RedirectToAction("loadSanPhamDienThoai","SanPham");
        }


        // thông tin tài khoản, cập nhật thông tin
        [HttpGet]
        public ActionResult thongTinTaiKhoan(int maKhachHang)
        {
            var kh = db.KhachHangs.Where(m => m.maKhachHang == maKhachHang).FirstOrDefault();
            return View(kh);
        }

        [HttpPost]
        public ActionResult thongTinTaiKhoan(int maKhachHang,string tenKhachHang, string soDienThoai, string email, string diaChi, string reMatKhau, string nhapLai)
        {
            KhachHang kh = db.KhachHangs.Single(m => m.maKhachHang == maKhachHang);
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(tenKhachHang) || string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(email)
                    || string.IsNullOrEmpty(diaChi))
                {
                    ViewData["Loi1"] = "Các thông tin không được để trống!";
                }
                if(string.IsNullOrEmpty(reMatKhau))
                {

                }    
                if (!string.IsNullOrEmpty(tenKhachHang) && !string.IsNullOrEmpty(soDienThoai) && !string.IsNullOrEmpty(email)
                    && !string.IsNullOrEmpty(diaChi))
                {
                    
                    if (kiemTraDL.isPhoneNumber(soDienThoai))
                    {
                        kh.diaChi = diaChi;
                        kh.tenKhachHang = tenKhachHang;
                        kh.soDienThoai = soDienThoai;
                        kh.email = email;
                        if(!string.IsNullOrEmpty(reMatKhau))
                        {
                            if (reMatKhau.Trim() == nhapLai.Trim())
                            {
                                kh.matKhau = reMatKhau;
                            }
                            else
                            {
                                ViewData["Loi3"] = "Mật khẩu không khớp!";
                            }
                        }
                        db.SubmitChanges();
                        ViewData["thongBao"] = "Cập nhật thành công!";
                    }
                    else
                    {
                        ViewData["Loi2"] = "Số điện thoại không hợp lệ";
                    }

                }
            }
            return View(kh);
        }



        // load tất cả các đơn hàng của khách hàng đã đặt
        public ActionResult donHangCuaToi()
        {
            KhachHang kh = (KhachHang)Session["TaiKhoan"];
            if (kh == null)
            {
                return HttpNotFound();
            }
            var listHoaDon = db.HoaDons.Where(m => m.maKhachHang == kh.maKhachHang).ToList();
            var query = (from sp in db.SanPhams
                         join cthd in db.CTHoaDons on sp.maSanPham equals cthd.maSanPham
                         join hd in db.HoaDons on cthd.maHoaDon equals hd.maHoaDon
                         join kh1 in db.KhachHangs on hd.maKhachHang equals kh.maKhachHang
                         select new DonMua
                         {
                             maKhachHang = kh1.maKhachHang,
                             tenSanPham = sp.tenSanPham,
                             hinhMinhHoa = sp.hinhMinhHoa,
                             donGia = sp.donGia,
                             soLuong = cthd.soLuong,
                             giamGia = sp.giamGia,
                             ngayBan = hd.ngayBan,
                             maHoaDon = hd.maHoaDon

                         }).Where(m => m.maKhachHang == kh.maKhachHang).OrderByDescending(m => m.ngayBan).ToList();
            if (listHoaDon.Count == 0)
            {
                return RedirectToAction("khongCoSanPham", "HttpNotFound");
            }  
            return View(query);   
        }

        public ActionResult update(int id = 0)
        {
            return View();
        }

    }
}
