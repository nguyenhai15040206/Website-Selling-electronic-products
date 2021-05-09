using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLSanPhamDienTu_WebApplication.Models;

namespace QLSanPhamDienTu_WebApplication.Controllers
{
    public class DanhMucSanPhamController : Controller
    {
        //
        // GET: /DanhMucSanPham/

        QL_SanPhamEntities db = new QL_SanPhamEntities();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult LogoDanhMucDienThoai()
        {
            var dienThoai = db.DanhMucs.Where(m => m.ghiChu == "DienThoai").ToList();
            return View(dienThoai);
        }

        public ActionResult LogoDanhMucLaptop()
        {
            var laptop = db.DanhMucs.Where(m => m.ghiChu == "Laptop").ToList();
            return View(laptop);
        }



    }
}
