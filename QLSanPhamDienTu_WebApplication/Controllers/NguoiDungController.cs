using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        public static HttpClient client;
        public NguoiDungController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.1.3:5000/Home/Introduct/");
        }

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
            if (string.IsNullOrEmpty(tenDangNhap.Trim()) || kiemTraDL.isTextContainSPace(tenDangNhap.Trim())==false || (tenDangNhap.Trim().Length <5 || tenDangNhap.Trim().Length >30))
            {
                ViewData["Loi3"] = "Tên đăng nhập từ 5 đến 30 kí tự, không bao gồm khoảng trắng";
            }
            if(string.IsNullOrEmpty(matKhau.Trim()) || kiemTraDL.isTextContainSPace(matKhau.Trim())== false ||  (matKhau.Trim().Length < 5 || matKhau.Trim().Length > 30))
            {
                ViewData["Loi4"] = "Mật khẩu từ 5 đến 30 kí tự, không bao gồm khoảng trắng";
            }
            if (string.IsNullOrEmpty(reMatKHau))
            {
                ViewData["Loi5"] = "Nhập lại mật khẩu";
            }
            if (!string.IsNullOrEmpty(tenKH.Trim()) && !string.IsNullOrEmpty(email.Trim()) &&!string.IsNullOrEmpty(soDienThoai.Trim()) && !string.IsNullOrEmpty(tenDangNhap.Trim()) &&
                !string.IsNullOrEmpty(matKhau.Trim()) && !string.IsNullOrEmpty(reMatKHau.Trim()) && kiemTraDL.isTextContainSPace(tenDangNhap.Trim()) && ((tenDangNhap.Trim().Length >= 5 && tenDangNhap.Trim().Length <= 30))
                && kiemTraDL.isTextContainSPace(matKhau.Trim()) && ((matKhau.Trim().Length >= 5 && matKhau.Trim().Length <=30 )))
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
                            //db.KhachHangs.InsertOnSubmit(kh);
                            var postKH = client.PostAsJsonAsync<KhachHang>("KhachHang", kh);
                            postKH.Wait();
                            var rs = postKH.Result;
                            if(rs.IsSuccessStatusCode)
                            {
                                return RedirectToAction("dangNhap", "NguoiDung");
                            }    
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
                //KhachHang kh = db.KhachHangs.SingleOrDefault(m => m.tenDangNhap.Trim() == tenDangNhap.Trim() && m.matKhau.Trim() == matKhau.Trim());
                KhachHang kh = null;
                client.DefaultRequestHeaders.Accept.Clear();

                var responseTask = client.GetAsync("KhachHang/" + tenDangNhap+"/"+matKhau);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readObj = result.Content.ReadAsAsync<KhachHang>();
                    readObj.Wait();
                    kh = readObj.Result;
                    if (kh != null)
                    {
                        Session["TaiKhoan"] = kh;
                        return RedirectToAction("loadSanPhamDienThoai", "SanPham");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Sai tên Đăng Nhập hoặc sai Mật Khẩu, vui lòng đăng nhập lại!");
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
            //var kh = db.KhachHangs.Where(m => m.maKhachHang == maKhachHang).FirstOrDefault();
            KhachHang kh = null;
            client.DefaultRequestHeaders.Accept.Clear();

            var responseTask = client.GetAsync("KhachHang/"+maKhachHang);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readObj = result.Content.ReadAsAsync<KhachHang>();
                readObj.Wait();
                kh = readObj.Result;
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Vui lòng kiểm tra lại internet");
            }
            return View(kh);
        }

        [HttpPost]
        public ActionResult thongTinTaiKhoan(int maKhachHang,string tenKhachHang, string soDienThoai, string email, string diaChi,string matKhau ,string reMatKhau, string nhapLai, string checkBox)
       {
            string loi6 = "Cập nhật thông tin thành công!";
            KhachHang kh = null;
            client.DefaultRequestHeaders.Accept.Clear();

            var responseTask = client.GetAsync("KhachHang/" + maKhachHang);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readObj = result.Content.ReadAsAsync<KhachHang>();
                readObj.Wait();
                kh = readObj.Result;
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrEmpty(tenKhachHang) || string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(email))
                    {
                        ViewData["Loi1"] = "Các thông tin không được để trống!";
                    }
                    if (diaChi.Trim().Length < 30)
                    {
                        ViewData["Loi7"] = "Địa chỉ không hợp lệ!";
                    }
                    if (!string.IsNullOrEmpty(tenKhachHang.Trim()) && !string.IsNullOrEmpty(soDienThoai.Trim()) && !string.IsNullOrEmpty(email.Trim())
                        && !string.IsNullOrEmpty(diaChi.Trim()) && diaChi.Trim().Length >= 30)
                    {

                        if (kiemTraDL.isPhoneNumber(soDienThoai.Trim()))
                        {
                            kh.diaChi = diaChi;
                            kh.tenKhachHang = tenKhachHang;
                            kh.soDienThoai = soDienThoai;
                            kh.email = email;
                            if (checkBox == "on")
                            {
                                if (matKhau.Trim() != "")
                                {
                                    if (kiemTraDL.MD5Hash(matKhau.Trim()) == kh.matKhau)
                                    {
                                        if (reMatKhau.Trim().Length >= 5 && reMatKhau.Trim().Length <= 30 && kiemTraDL.isTextContainSPace(reMatKhau.Trim()) == true)
                                        {
                                            if (reMatKhau.Trim() == nhapLai.Trim())
                                            {
                                                kh.matKhau = kiemTraDL.MD5Hash(reMatKhau);
                                                var putTask = client.PutAsJsonAsync<KhachHang>("KhachHang/" + maKhachHang, kh);
                                                putTask.Wait();
                                                var rs = putTask.Result;
                                                if (rs.IsSuccessStatusCode)
                                                {
                                                    ViewData["thongBao"] = loi6;
                                                }
                                            }
                                            else
                                            {
                                                ViewData["Loi3"] = "Mật khẩu không khớp!";
                                            }
                                        }
                                        else
                                        {
                                            ViewData["Loi6"] = "Mật khẩu mới nhập từ 5 đến 30 kí tự, không bao gồm khoảng trắng!";
                                        }
                                    }
                                    else
                                    {
                                        ViewData["Loi5"] = "Mật khẩu cũ không chính xác";
                                    }
                                }
                                else
                                {
                                    ViewData["Loi4"] = "Vui lòng điền mật khẩu cũ";
                                }
                            }
                            else
                            {
                                //db.SubmitChanges();
                                var putTask = client.PutAsJsonAsync<KhachHang>("KhachHang/"+maKhachHang,kh);
                                putTask.Wait();
                                var rs = putTask.Result;
                                if(rs.IsSuccessStatusCode)
                                {
                                    ViewData["thongBao"] = loi6;
                                }    
                                
                            }
                        }
                        else
                        {

                            ViewData["Loi2"] = "Số điện thoại không hợp lệ";
                        }

                    }
                }
            }
            //var responseTask = client.PutAsJsonAsync<KhachHang>("KhachHang",);
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
