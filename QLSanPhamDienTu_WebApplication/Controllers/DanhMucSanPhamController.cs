using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using QLSanPhamDienTu_WebApplication.Models;

namespace QLSanPhamDienTu_WebApplication.Controllers
{
    public class DanhMucSanPhamController : Controller
    {
        //
        // GET: /DanhMucSanPham/
        public static HttpClient client;
        public DanhMucSanPhamController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.1.3:5000/Home/Introduct/");
        }

        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult LogoDanhMucDienThoai()
        {
            //var dienThoai = db.DanhMucs.Where(m => m.ghiChu == "DienThoai").ToList();
            IEnumerable<DanhMuc> dienThoai = null;
            var responseTask = client.GetAsync("DanhMuc/DienThoai");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readObj = result.Content.ReadAsAsync<IList<DanhMuc>>();
                readObj.Wait();
                dienThoai = readObj.Result;
            }
            else
            {
                dienThoai = Enumerable.Empty<DanhMuc>();
                ModelState.AddModelError(string.Empty, "Kết nối internet không ổn định");
            }
            return View(dienThoai);
        }

        public ActionResult LogoDanhMucLaptop()
        {
            //var laptop = db.DanhMucs.Where(m => m.ghiChu == "Laptop").ToList();
            IEnumerable<DanhMuc> laptop = null;
            var responseTask = client.GetAsync("DanhMuc/Laptop");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readObj = result.Content.ReadAsAsync<IList<DanhMuc>>();
                readObj.Wait();
                laptop = readObj.Result;
            }
            else
            {
                laptop = Enumerable.Empty<DanhMuc>();
                ModelState.AddModelError(string.Empty, "Kết nối internet không ổn định");
            }
            return View(laptop);
        }

        public ActionResult LogoDanhMucPhuKien()
        {
            //var laptop = db.DanhMucs.Where(m => m.ghiChu == "Laptop").ToList();
            IEnumerable<DanhMuc> pk = null;
            var responseTask = client.GetAsync("DanhMuc/PhuKien");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readObj = result.Content.ReadAsAsync<IList<DanhMuc>>();
                readObj.Wait();
                pk = readObj.Result;
            }
            else
            {
                pk = Enumerable.Empty<DanhMuc>();
                ModelState.AddModelError(string.Empty, "Kết nối internet không ổn định");
            }
            return View(pk);
        }



    }
}
