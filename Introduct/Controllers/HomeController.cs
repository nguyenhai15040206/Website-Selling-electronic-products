using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLySanPhamDIenTuAPI.Controller;

namespace Introduct.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            SanPhamController sanPhamController = new SanPhamController();
            return View(sanPhamController);
        }
    }
}
