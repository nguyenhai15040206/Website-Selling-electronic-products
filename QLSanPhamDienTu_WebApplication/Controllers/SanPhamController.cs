using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using QLSanPhamDienTu_WebApplication.Models;

namespace QLSanPhamDienTu_WebApplication.Controllers
{
    public class SanPhamController : Controller
    {
        //
        // GET: /SanPham/
        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();

        public static HttpClient client;
        public SanPhamController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.1.3:5000/Home/Introduct/");
        }

        #region Sản phẩm điện thoại
        public ActionResult loadSanPhamDienThoai()
        {

            //var listSPDT = db.SanPhams.Take(12).OrderBy(m => m.tenSanPham).Where(m => m.DanhMuc.ghiChu == "DienThoai").ToList();
            IEnumerable<NewSanPham> listSPDT = null;
            var responseTask = client.GetAsync("SanPham/ghiChu/DienThoai");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                
                var readObj = result.Content.ReadAsAsync<IList<NewSanPham>>();
                readObj.Wait();
                listSPDT = readObj.Result.OrderByDescending(m => m.GiamGia).OrderByDescending(m => m.DonGia).ToList();
                ViewBag.TongSPDT = readObj.Result.Count();
            }
            else
            {
                listSPDT = Enumerable.Empty<NewSanPham>();
                ModelState.AddModelError(string.Empty, "Kết nối internet không ổn định");
            }

            return View(listSPDT);
        }

        public ActionResult chiTietSanPhamDienThoai(int maSP)
        {
            NewSanPham sp = null;
            client.DefaultRequestHeaders.Accept.Clear();

            var responseTask = client.GetAsync("SanPham/"+maSP);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readObj = result.Content.ReadAsAsync<NewSanPham>();
                readObj.Wait();
                sp = readObj.Result;
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kết nối internet không ổn định");
            }
            //SanPham sp = db.SanPhams.Single(m => m.maSanPham == maSP);
            if (sp == null)
            {
                return RedirectToAction("loadSanPhamDienThoai", "SanPham");
            }
            else
                return View(sp);
        }

        public ActionResult sanPhamTheoMaLoai(int maDanhMuc)
        {
            IEnumerable<NewSanPham> sp = null;
            client.DefaultRequestHeaders.Accept.Clear();

            var responseTask = client.GetAsync("SanPham/DanhMuc/" + maDanhMuc);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readObj = result.Content.ReadAsAsync<IList<NewSanPham>>();
                readObj.Wait();
                sp = readObj.Result;
                ViewBag.TongSPDT = sp.Count();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kết nối internet không ổn định");
            }
            if (sp == null)
            {
                return RedirectToAction("DanhSachSanPhamRong", "HttpNotFound");
            }
            return View(sp);  

        }
        #endregion

        #region Sản phẩm laptop
        public ActionResult loadSanPhamLaptop()
        {

            IEnumerable<NewSanPham> listSPLaptop = null;
            var responseTask = client.GetAsync("SanPham/ghiChu/Laptop");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readObj = result.Content.ReadAsAsync<IList<NewSanPham>>();
                readObj.Wait();
                listSPLaptop = readObj.Result.OrderByDescending(m=>m.GiamGia).OrderByDescending(m => m.DonGia).ToList();
                ViewBag.TongSPLaptop = readObj.Result.Count();
            }
            else
            {
                listSPLaptop = Enumerable.Empty<NewSanPham>();
                ModelState.AddModelError(string.Empty, "Kết nối internet không ổn định");
            }
            //var listSPLaptop = db.SanPhams.Where(m => m.DanhMuc.ghiChu == "Laptop").OrderByDescending(m =>m.giamGia).Take(12).OrderByDescending(m=>m.donGia).ToList();
            return View(listSPLaptop);
        }

        public ActionResult chiTietSanPhamLaptop(int maSP)
        {
            //SanPham sp = db.SanPhams.Single(m => m.maSanPham == maSP);
            NewSanPham sp = null;
            client.DefaultRequestHeaders.Accept.Clear();

            var responseTask = client.GetAsync("SanPham/" + maSP);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readObj = result.Content.ReadAsAsync<NewSanPham>();
                readObj.Wait();
                sp = readObj.Result;
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kết nối internet không ổn định");
            }
            if (sp == null)
            {
                return RedirectToAction("DanhSachSanPhamRong", "HttpNotFound");
            }
            else
                return View(sp);
        }

        public ActionResult sanPhamTheoDanhMucLaptop(int maDanhMuc)
        {
            IEnumerable<NewSanPham> sp = null;
            client.DefaultRequestHeaders.Accept.Clear();

            var responseTask = client.GetAsync("SanPham/DanhMuc/" + maDanhMuc);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readObj = result.Content.ReadAsAsync<IList<NewSanPham>>();
                readObj.Wait();
                sp = readObj.Result;
                ViewBag.TongSPLaptop = sp.Count();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kết nối internet không ổn định");
            }
            if (sp == null)
            {
                return RedirectToAction("DanhSachSanPhamRong", "HttpNotFound");
            }    
            return View(sp);
        }
        #endregion

        #region sản phẩm phụ kiện
        public ActionResult loadSanPhamPhuKien()
        {
            //var listSanPham = db.SanPhams.Where(m => m.DanhMuc.ghiChu == "PhuKien").OrderByDescending(m=>m.donGia).Take(12).ToList();
            //ViewBag.TongSPPhuKien = db.SanPhams.Where(m => m.DanhMuc.ghiChu == "PhuKien").ToList().Count();
            IEnumerable<NewSanPham> listSanPham = null;
            var responseTask = client.GetAsync("SanPham/ghiChu/PhuKien");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readObj = result.Content.ReadAsAsync<IList<NewSanPham>>();
                readObj.Wait();
                listSanPham = readObj.Result.OrderByDescending(m => m.GiamGia).OrderByDescending(m => m.DonGia).ToList();
                ViewBag.TongSPPhuKien = readObj.Result.Count();
                if (readObj.Result.Count() == 0)
                {
                    return RedirectToAction("DanhSachSanPhamRong", "HttpNotFound");
                }
                return View(listSanPham);
            }
            else
            {
                listSanPham = Enumerable.Empty<NewSanPham>();
                ModelState.AddModelError(string.Empty, "Kết nối internet không ổn định");
                return null;
            }
        }

        public ActionResult chiTietSanPhamPhuKien(int maSP)
        {
            //SanPham sp = db.SanPhams.Single(m => m.maSanPham == maSP);
            NewSanPham sp = null;
            client.DefaultRequestHeaders.Accept.Clear();

            var responseTask = client.GetAsync("SanPham/" + maSP);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readObj = result.Content.ReadAsAsync<NewSanPham>();
                readObj.Wait();
                sp = readObj.Result;
                return View(sp);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kết nối internet không ổn định");
                return RedirectToAction("DanhSachSanPhamRong", "HttpNotFound");
            }
                
        }
        #endregion
        #region sản phẩm apple
        public ActionResult loadSanPhamApple()
        {
            return RedirectToAction("DanhSachSanPhamRong", "HttpNotFound");
        }
        #endregion
    }
}
