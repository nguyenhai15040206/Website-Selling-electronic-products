using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        public static HttpClient client;
        public TimKiemController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.1.3:5000/Home/Introduct/");
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TimKiemSanPham(string input)
        {  
            if(input=="Phụ kiện")
            {
                input = "PhuKien";
            }    
            //if(input.Trim() == "")
            //{
            //    return RedirectToAction("loadSanPhamDienThoai", "SanPham");
            //}    
            IEnumerable<NewSanPham> listSanPham = null;
            var responseTask = client.GetAsync("SanPhamFillter/"+input);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readObj = result.Content.ReadAsAsync<IList<NewSanPham>>();
                readObj.Wait();
                listSanPham = readObj.Result.OrderByDescending(m => m.GiamGia).OrderByDescending(m => m.DonGia).ToList();
                ViewBag.TongSPLaptop = readObj.Result.Count();
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
                return RedirectToAction("DanhSachSanPhamRong", "HttpNotFound");
            }
            
        }

    }
}
