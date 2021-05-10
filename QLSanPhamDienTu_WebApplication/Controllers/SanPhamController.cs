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
        QL_SanPhamEntities db = new QL_SanPhamEntities();


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
        #endregion

        #region Sản phẩm laptop
        public ActionResult loadSanPhamLaptop()
        {
            ViewBag.TongSPLaptop = db.SanPhams.Where(m => m.DanhMuc.ghiChu == "Laptop").Count();
            var listSPLaptop = db.SanPhams.Take(12).Where(m => m.DanhMuc.ghiChu == "Laptop").OrderBy(m => m.tenSanPham).ToList();
            return View(listSPLaptop);
        }

        public ActionResult chiTietSanPhamLaptop(int maSP)
        {
            SanPham sp = db.SanPhams.Single(m => m.maSanPham == maSP);
            if (sp == null)
            {
                return RedirectToAction("loadSanPhamLaptop", "SanPham");
            }
            else
                return View(sp);
        }
        #endregion


        //a

    }
}
