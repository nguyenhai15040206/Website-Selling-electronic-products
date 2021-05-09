using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLSanPhamDienTu_WebApplication.Controllers
{
    public class HttpNotFoundController : Controller
    {
        //
        // GET: /HttpNotFound/

        public ActionResult HttpNotFound_404()
        {
            return View();
        }

        public ActionResult khongCoSanPham()
        {
            return View();
        }

    }
}
