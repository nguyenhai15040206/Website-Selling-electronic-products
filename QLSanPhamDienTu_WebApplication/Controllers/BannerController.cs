using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using QLSanPhamDienTu_WebApplication.Models;

namespace QLSanPhamDienTu_WebApplication.Controllers
{
    public class BannerController : Controller
    {
        //
        // GET: /Banner/
        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();
        public static HttpClient client;
        public BannerController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.1.3:5000/Home/Introduct/");
        }
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult loadBannerActive()
        {
            //var banner = db.Banners.Where(m => m.ghiChu == "new" && m.kichHoat == true).Take(1).ToList();
            IEnumerable<Banner> banner = null;
            var responseTask = client.GetAsync("Banner");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readObj = result.Content.ReadAsAsync<IList<Banner>>();
                readObj.Wait();
                banner = readObj.Result.Where(m => m.ghiChu == "new" && m.kichHoat == true).Take(1).ToList();
            }
            else
            {
                banner = Enumerable.Empty<Banner>();
                ModelState.AddModelError(string.Empty, "Kết nối internet không ổn định");
            }
            return View(banner);
        }

        public ActionResult loadBanner()
        {
            //var banner = db.Banners.Where(m => m.ghiChu == "new" && m.kichHoat == false).Take(2).ToList();
            IEnumerable<Banner> banner = null;
            var responseTask = client.GetAsync("Banner");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readObj = result.Content.ReadAsAsync<IList<Banner>>();
                readObj.Wait();
                banner = readObj.Result.Where(m => m.ghiChu == "new" && m.kichHoat == false).Take(3).ToList();
            }
            else
            {
                banner = Enumerable.Empty<Banner>();
                ModelState.AddModelError(string.Empty, "Kết nối internet không ổn định");
            }
            return View(banner);
        }
    }
}
