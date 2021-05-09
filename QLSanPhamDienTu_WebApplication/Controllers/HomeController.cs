using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLSanPhamDienTu_WebApplication.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/


        public ActionResult HeaderPartialView()
        {
            return View();
        }

    }
}
