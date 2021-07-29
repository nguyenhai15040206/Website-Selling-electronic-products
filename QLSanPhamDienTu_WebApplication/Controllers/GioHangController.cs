using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using QLSanPhamDienTu_WebApplication.Models;

namespace QLSanPhamDienTu_WebApplication.Controllers
{
    public class GioHangController : Controller
    {
        //
        // GET: /GioHang/
        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();
        KiemTraDuLieu ktdl = new KiemTraDuLieu();
        public static HttpClient client;
        public GioHangController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.1.3:5000/Home/Introduct/");
        }
        public List<GioHang> layGioHang()
        {
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if (listGioHang == null)
            {
                // nếu giỏ hàng chưa tồn tại thì khởi tạo giỏ hàng
                listGioHang = new List<GioHang>();
                Session["GioHang"] = listGioHang;
            }
            return listGioHang;
        }
        //
        public ActionResult AprioriAlgorithm()
        {
            List<GioHang> listGioHangs = layGioHang();
            List<NewSanPham> listSanPham = new List<NewSanPham>();
            if(listGioHangs.Count ==0)
            {
                return null;
            }
            listSanPham = dsSanPhamGoiY();
            if(listSanPham ==null || listSanPham.Count==0)
            {
                return null;
            }    
            
            return View(listSanPham);
        }

        public List<NewSanPham> dsSanPhamGoiY()
        {
            List<GioHang> listGioHangs = layGioHang();
            List<NewSanPham> listSanPhamTmp = new List<NewSanPham>();
            List<NewSanPham> listSanPham = new List<NewSanPham>();
            List<string> listString = new List<string>();
            List<string> listSubset = new List<string>();
            if(listGioHangs==null)
            {
                return null;
            }    
            listString.AddRange(listGioHangs.AsEnumerable().Where(m=>m.ghiChu == "DienThoai"|| m.ghiChu == "Laptop").Select(m => m.ghiChu).ToArray().Distinct());
            listString.AddRange(listGioHangs.AsEnumerable().Where(m => m.ghiChu == "PhuKien").Select(m => m.tenDanhMuc).ToArray().Distinct());
            if(listString.Count==0)
            {
                return null;
            }
            else
            {
                List<string> listSubs = new List<string>();
                for(int i=0;i < listString.Count; i++)
                {
                    FindSubsets(listString[i].ToString().Trim(), listSubs);
                }
                foreach(var sub in listSubs)
                {
                    IEnumerable<NewSanPham> sp = null;
                    client.DefaultRequestHeaders.Accept.Clear();

                    var responseTask = client.GetAsync("Apriori/" + sub.Substring(0,sub.Length-1).Trim());
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readObj = result.Content.ReadAsAsync<IList<NewSanPham>>();
                        readObj.Wait();
                        sp = readObj.Result;  
                        listSanPhamTmp.AddRange(sp.AsEnumerable().OrderByDescending(m => m.DonGia).ToArray());
                        //ViewBag.TongSPLaptop = sp.Count();
                    }
                }
                listSanPham = dsSanPhamkhongTrungNhau(listSanPhamTmp);

               // var listDisstinct = listSanPhamTmp.Distinct().ToList();
                //listSanPham.AddRange(listSanPhamTmp.Union(listSanPham).Distinct());
            }
            return listSanPham;
        }

        public List<NewSanPham> dsSanPhamkhongTrungNhau(List<NewSanPham> listTmp)
        {
            List<NewSanPham> listSanPhamTmp = new List<NewSanPham>();
            List<NewSanPham> listSanPham = new List<NewSanPham>();
            List<GioHang> listGioHangs = layGioHang();
            //var rs = listTmp.AsEnumerable().Select(m => m.MaSanPham).ToArray();
            // lấy ra những sản phẩm không trung nhau
            foreach (NewSanPham item in listTmp) 
            {
                if(!listSanPhamTmp.Select(m=>m.MaSanPham).Contains(item.MaSanPham))
                {
                    listSanPhamTmp.Add(item);
                }    
            }
            listSanPham = listSanPhamTmp;
            // nếu giỏ hàng tồn tại rồi thì remove nó đi
            foreach(var itemGH in listGioHangs)
            {
                foreach(var itemSP in listSanPhamTmp)
                {
                    if(itemGH.ghiChu.Equals("DienThoai")|| itemGH.ghiChu.Equals("Laptop"))
                    {
                        if(itemGH.ghiChu.Equals(itemSP.GhiChu))
                        {
                            var sp = listSanPham.SingleOrDefault(m => m.TenDanhMuc == itemGH.tenDanhMuc);
                            listSanPham.Remove(sp);
                            break;
                        }
                    }
                    if(itemGH.ghiChu.Equals("PhuKien"))
                    {
                        if (itemGH.tenDanhMuc.Equals(itemSP.TenDanhMuc))
                        {
                            var sp = listSanPham.SingleOrDefault(m => m.TenDanhMuc == itemGH.tenDanhMuc);
                            listSanPham.Remove(sp);
                            break;
                        }
                    }
                }    
            }    
            return listSanPham;
        }
        //aa
        

        public void FindSubsets(string s, List<string> listSub)
        {
            if (listSub.Count == 0)
            {
                listSub.Add(s+",");
            }
            else
            {
                int count = listSub.Count;
                for (int i = 0; i < count; i++)
                {
                    if (!listSub.Contains(s+","))
                    {
                        listSub.Add(s+",");
                    }
                    listSub.Add(listSub[i] + s +",");
                }
            }
        }
        //

        // thêm sản phẩm vào giỏ hàng
        public ActionResult themSPVaoGioHang(int maSP, string strUrl)
        {
            // lấy ra giỏ hàng
            List<GioHang> listGioHang = layGioHang();

            // kiểm tra sản phẩm này có tồn tại trong Session["GioHang"] hay không?
            GioHang sanPham = listGioHang.Find(m => m.maSanPham == maSP);
            if (sanPham == null)
            {
                sanPham = new GioHang(maSP);
                listGioHang.Add(sanPham);
                return Redirect(strUrl);
            }
            else // đã có sản phẩm trong giỏ hàng
            {
                sanPham.soLuong++;
                return Redirect(strUrl);
            }
        }

        // tính tổng số lượng
        private int tongSoLuong()
        {
            int tong = 0;
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if (listGioHang != null)
            {
                tong = listGioHang.Sum(m => m.soLuong);
            }
            return tong;
        }

        // tính tổng thành tiền
        private double tongThanhTien()
        {
            double tong = 0;
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if (listGioHang != null)
            {
                tong += listGioHang.Sum(m => m.ThanhTien);
            }
            return tong;
        }

        private double tongTienBan()
        {
            double tong = 0;
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if (listGioHang != null)
            {
                tong += listGioHang.Sum(m => m.donGia);
            }
            return tong;
        }

        // tổng giảm giá
        private double tongGiamGia()
        {
            double tong = 0;
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if (listGioHang != null)
            {
                tong += listGioHang.Sum(m => m.giamGia);
            }
            return tong;
        }

        // Xây dựng trang giỏ hàng
        public ActionResult trangGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("HttpNotFound_404", "HttpNotFound");
            }
            List<GioHang> listGioHang = layGioHang();
            ViewBag.TongSoLuong = tongSoLuong();
            ViewBag.TongThanhTien = tongThanhTien();
            ViewBag.TongGiamGia = tongGiamGia();
            return View(listGioHang);
        }

        // giỏ hàng partial dữ lại số lượng mua mà không render tại trang
        public ActionResult gioHangPartial()
        {
            ViewBag.TongSoLuong = tongSoLuong();
            ViewBag.TongThanhTien = tongThanhTien();
            ViewBag.TongGiamGia = tongGiamGia();
            return PartialView();
        }

        // cập nhật số lượng
        
        public ActionResult capNhatGioHang(int maSP, FormCollection f)
        {
            List<GioHang> listGioHang = layGioHang();
            GioHang sp = listGioHang.Single(m => m.maSanPham == maSP);
            if (sp != null)
            {
                sp.soLuong = int.Parse(f["txtSoLuong"].ToString()); 
            }
            return RedirectToAction("trangGioHang", "GioHang");
        }

        // xóa một sản phẩm trong giỏ hàng
        public ActionResult xoaSanPhamTrongGioHang_1Sp(int maSP)
        {
            List<GioHang> listGioHang = layGioHang();
            GioHang sp = listGioHang.Single(m => m.maSanPham == maSP);
            if (sp != null)
            {
                listGioHang.RemoveAll(m => m.maSanPham == maSP);
                if (listGioHang.Count == 0)
                {
                    return RedirectToAction("HttpNotFound_404", "HttpNotFound");
                }
                else
                {
                    return RedirectToAction("trangGioHang", "GioHang");
                }
            }
            return RedirectToAction("trangGioHang", "GioHang");
        }


        // tiến hành đặt hàng
        [HttpGet]
        public ActionResult datHang()
        {
            // kiểm tra session()
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("dangNhap", "NguoiDung");
            }
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("loadSanPhamDienThoai", "SanPham");
            }
            // lấy giở hang
            List<GioHang> listGIoHang = layGioHang();
            ViewBag.tinhTongSL = tongSoLuong();
            ViewBag.tinhTongThanhTien = tongThanhTien();
            return View();
        }

        [HttpPost]
        public ActionResult datHang(string diaChi, string tenKhachHang, string soDienThoai)
        {
            HoaDon hoaDon = new HoaDon();
            KhachHang khachHang = (KhachHang)Session["TaiKhoan"];
            KhachHang kh = null;
            client.DefaultRequestHeaders.Accept.Clear();
            var responseTask = client.GetAsync("KhachHang/" + khachHang.maKhachHang);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readObj = result.Content.ReadAsAsync<KhachHang>();
                readObj.Wait();
                kh = readObj.Result;
                List<GioHang> listGioHang = layGioHang();
                kh.soDienThoai = soDienThoai;
                kh.tenKhachHang = tenKhachHang;
                kh.diaChi = diaChi;
                kh.maKhachHang = khachHang.maKhachHang;
                kh.matKhau = khachHang.matKhau;
                var putTask = client.PutAsJsonAsync<KhachHang>("KhachHang/" + kh.maKhachHang, kh);
                putTask.Wait();
                var rs = putTask.Result;
                if (rs.IsSuccessStatusCode)
                {
                    hoaDon.maKhachHang = kh.maKhachHang;
                    hoaDon.ngayBan = DateTime.Now;
                    hoaDon.ngayGiao = DateTime.Now.AddDays(4);
                    hoaDon.ghiChu = "Chờ xác nhận";
                    hoaDon.tienBan = (decimal)tongTienBan();
                    hoaDon.giamGia = tongGiamGia();
                    hoaDon.tongTien = (decimal)tongThanhTien();
                    hoaDon.maNguoiDung = null;
                    hoaDon.tinhTrang = true;
                    var postHoaDon = client.PostAsJsonAsync<HoaDon>("HoaDon", hoaDon);
                    postHoaDon.Wait();
                    var rsPost = postHoaDon.Result;
                    if (rsPost.IsSuccessStatusCode)
                    {
                        var rsHD = rsPost.Content.ReadAsAsync<HoaDon>();
                        rsHD.Wait();
                        HoaDon hoaDon1 = rsHD.Result;
                        foreach (var item in listGioHang)
                        {
                            CTHoaDon ctHD = new CTHoaDon();
                            ctHD.maHoaDon = hoaDon1.maHoaDon;
                            ctHD.maSanPham = item.maSanPham;
                            ctHD.soLuong = item.soLuong;
                            ctHD.donGia = (decimal)item.donGia;
                            ctHD.giamGia = item.giamGia;
                            ctHD.thanhTien = (decimal)item.ThanhTien;
                            ctHD.ghiChu = "Chờ xác nhận";
                            var postCTHD = client.PostAsJsonAsync<CTHoaDon>("CTHoaDon", ctHD);
                            postCTHD.Wait();
                            var rsPostCTHD = postCTHD.Result;
                            if (rsPostCTHD.IsSuccessStatusCode)
                            {
                                continue;
                            }
                            //db.CTHoaDons.InsertOnSubmit(ctHD);
                        }
                    }
                    //db.SubmitChanges();
                    listGioHang.Clear();
                }
            }
            //var kh = db.KhachHangs.Single(m => m.maKhachHang == khachHang.maKhachHang);
            return RedirectToAction("HttpNotFound_404", "HttpNotFound");
        }

    }
}
