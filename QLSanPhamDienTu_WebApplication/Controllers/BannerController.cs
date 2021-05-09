using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLSanPhamDienTu_WebApplication.Models;

namespace QLSanPhamDienTu_WebApplication.Controllers
{
    public class BannerController : Controller
    {
        //
        // GET: /Banner/
        QL_SanPhamEntities db = new QL_SanPhamEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult loadBannerActive()
        {
            var banner = db.Banners.Where(m => m.ghiChu == "new" && m.kichHoat == true).Take(1).ToList();
            return View(banner);
        }

        public ActionResult loadBanner()
        {
            var banner = db.Banners.Where(m => m.ghiChu == "new" && m.kichHoat == false).Take(2).ToList();
            return View(banner);
        }
    }
}
