using System;
using System.Collections.Generic;
using System.Linq;
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


        #region Sản phẩm điện thoại
        public ActionResult loadSanPhamDienThoai()
        {
            ViewBag.TongSPDT = db.SanPhams.Where(m => m.DanhMuc.ghiChu == "DienThoai").Count();
            var listSPDT = db.SanPhams.Take(12).OrderBy(m => m.tenSanPham).Where(m => m.DanhMuc.ghiChu == "DienThoai").ToList();
            return View(listSPDT);
        }

        public ActionResult chiTietSanPhamDienThoai(int maSP)
        {
            SanPham sp = db.SanPhams.Single(m => m.maSanPham == maSP);
            if (sp == null)
            {
                return RedirectToAction("loadSanPhamDienThoai", "SanPham");
            }
            else
                return View(sp);
        }

        public ActionResult sanPhamTheoMaLoai(int maDanhMuc)
        {
            ViewBag.TongSPDT = db.SanPhams.Where(m => m.DanhMuc.ghiChu == "DienThoai" && m.maDanhMuc==maDanhMuc).Count();
            var sp = db.SanPhams.Where(m => m.maDanhMuc == maDanhMuc).ToList();
            if(sp == null)
            {
                return RedirectToAction("DanhSachSanPhamRong", "HttpNotFound");
            }
            return View(sp);  

        }
        #endregion

        #region Sản phẩm laptop
        public ActionResult loadSanPhamLaptop()
        {
            ViewBag.TongSPLaptop = db.SanPhams.Where(m => m.DanhMuc.ghiChu == "Laptop").Count();
            var listSPLaptop = db.SanPhams.Where(m => m.DanhMuc.ghiChu == "Laptop").OrderByDescending(m =>m.giamGia).Take(12).OrderByDescending(m=>m.donGia).ToList();
            return View(listSPLaptop);
        }

        public ActionResult chiTietSanPhamLaptop(int maSP)
        {
            SanPham sp = db.SanPhams.Single(m => m.maSanPham == maSP);
            if (sp == null)
            {
                return RedirectToAction("DanhSachSanPhamRong", "HttpNotFound");
            }
            else
                return View(sp);
        }

        public ActionResult sanPhamTheoDanhMucLaptop(int maDanhMuc)
        {
            var sp = db.SanPhams.Where(m => m.maDanhMuc == maDanhMuc).ToList();
            if(sp == null)
            {
                return RedirectToAction("DanhSachSanPhamRong", "HttpNotFound");
            }    
            return View(sp);
        }
        #endregion

        #region sản phẩm phụ kiện
        public ActionResult loadSanPhamPhuKien()
        {
            var listSanPham = db.SanPhams.Where(m => m.DanhMuc.ghiChu == "PhuKien").OrderByDescending(m=>m.donGia).Take(12).ToList();
            ViewBag.TongSPPhuKien = db.SanPhams.Where(m => m.DanhMuc.ghiChu == "PhuKien").ToList().Count();
            if (listSanPham.Count==0)
            {
                return RedirectToAction("DanhSachSanPhamRong", "HttpNotFound");
            }    
            return View(listSanPham);
        }
        #endregion


        #region sản phẩm apple
        public ActionResult loadSanPhamApple()
        {
            var listSanPham = db.SanPhams.Where(m => m.DanhMuc.ghiChu == "Apple").OrderByDescending(m => m.donGia).Take(12).ToList();
            ViewBag.TongSPPhuKien = db.SanPhams.Where(m => m.DanhMuc.ghiChu == "Apple").ToList().Count();
            if (listSanPham.Count == 0)
            {
                return RedirectToAction("DanhSachSanPhamRong", "HttpNotFound");
            }
            return View(listSanPham);
        }
        #endregion
    }
}
