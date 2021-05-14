using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLySanPhamDIenTuAPI.Models;

namespace QuanLySanPhamDIenTuAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        QL_SanPhamContext db = new QL_SanPhamContext();

        // load tất cả sản phẩm
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sp = db.SanPham.ToList(); 
            if(sp.Count ==0)
            {
                return NotFound();
            }
            return new ObjectResult(sp);
        }


        // load sản phẩm theo mã sản phẩm
        [HttpGet("{maSanPham}")]
        public async Task<IActionResult> Get(int maSanPham)
        {
            var SanPham = db.SanPham.Where(m => m.MaSanPham == maSanPham).FirstOrDefault();
            if (SanPham == null)
            {
                return NotFound();
            }
            return new ObjectResult(SanPham);
        }

        // load sản phẩm theo ghichu
        [HttpGet("ghiChu.html({ghiChu})")]
        public async Task<IActionResult> Get(string ghiChu)
        {
            List<SanPham> sp = null;
            sp = db.SanPham.Where(m => m.MaDanhMucNavigation.GhiChu == ghiChu).ToList();
            if(sp.Count ==0)
            {
                return NotFound();
            }
            return new ObjectResult(sp);
        }

        // load sản phẩm theo danh mục
        [HttpGet("danhMuc.html({maDanhMuc})")]
        public async Task<IActionResult> Get(int? maDanhMuc)
        {
            var sp = db.SanPham.Where(m => m.MaDanhMucNavigation.MaDanhMuc == maDanhMuc).ToList();
            if(sp.Count==0)
            {
                return NotFound();
            }
            return new ObjectResult(sp);
        }
    }
}
