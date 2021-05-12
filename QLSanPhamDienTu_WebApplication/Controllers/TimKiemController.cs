using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLSanPhamDienTu_WebApplication.Models;

namespace QLSanPhamDienTu_WebApplication.Controllers
{
    public class TimKiemController : Controller
    {
        //
        // GET: /TimKiem/
        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TimKiemSanPham(string input)
        {
            string ghiChu = "";
            if(string.Compare(input,"Điện thoại",true)==0)
            {
                ghiChu = "DienThoai";
            }
            if(string.Compare(input, "Laptop", true)==0)
            {
                ghiChu = "Laptop";
            }      
                
            if(input.Trim() == "")
            {
                return RedirectToAction("loadSanPhamDienThoai", "SanPham");
            }    
            var listSanPham = db.SanPhams.Where(m => m.tenSanPham.Contains(input) || m.DanhMuc.tenDanhMuc.Contains(input) ||
             m.DanhMuc.ghiChu == ghiChu)
                .OrderByDescending(m=>m.donGia) . ToList();
            ViewBag.TongSPLaptop = listSanPham.Count();
            if (listSanPham.Count ==0)
            {
                return RedirectToAction("DanhSachSanPhamRong", "HttpNotFound");
            }    
            return View(listSanPham);
        }

    }
}
